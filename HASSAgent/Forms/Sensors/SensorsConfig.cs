using Syncfusion.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HASSAgent.Models.Config;
using HASSAgent.Mqtt;
using HASSAgent.Sensors;
using HASSAgent.Settings;
using Serilog;
using Syncfusion.Windows.Forms.Grid;

namespace HASSAgent.Forms.Sensors
{
    public partial class SensorsConfig : MetroForm
    {
        private List<ConfiguredSensor> _sensors = new List<ConfiguredSensor>();
        private readonly List<ConfiguredSensor> _toBeDeletedSensors = new List<ConfiguredSensor>();

        public SensorsConfig()
        {
            InitializeComponent();
        }

        private void SensorsConfig_Load(object sender, EventArgs e)
        {
            // pause the sensor manager
            SensorsManager.Pause();

            // catch all key presses
            KeyPreview = true;

            // load stored sensors
            PrepareSensorsList();
        }

        /// <summary>
        /// Load the stored sensors into the grid
        /// </summary>
        private void PrepareSensorsList()
        {
            // make a copy of the current sensors
            _sensors = Variables.Sensors.Select(StoredSensors.ConvertAbstractToConfigured).Where(configuredSensor => configuredSensor != null).ToList();

            // bind to the list
            LcSensors.DataSource = _sensors;

            // hide id column
            LcSensors.Grid.HideCols["Id"] = true;

            // hide query column
            LcSensors.Grid.HideCols["Query"] = true;

            // hide windowname column
            LcSensors.Grid.HideCols["WindowName"] = true;

            // hide updateinterval column
            LcSensors.Grid.HideCols["UpdateInterval"] = true;

            // force column resize
            LcSensors.Grid.ColWidths.ResizeToFit(GridRangeInfo.Table(), GridResizeToFitOptions.IncludeHeaders);
            
            // add extra space
            for (var i = 1; i <= LcSensors.Grid.ColCount; i++) LcSensors.Grid.ColWidths[i] += 15;

            // redraw
            LcSensors.Refresh();
        }

        /// <summary>
        /// Reload the sensors
        /// </summary>
        private void UpdateSensorsList()
        {
            // reload data
            LcSensors.Grid.ResetVolatileData();

            // force column resize
            LcSensors.Grid.ColWidths.ResizeToFit(GridRangeInfo.Table(), GridResizeToFitOptions.IncludeHeaders);

            // add extra space
            for (var i = 1; i <= LcSensors.Grid.ColCount; i++) LcSensors.Grid.ColWidths[i] += 15;

            // redraw
            LcSensors.Refresh();
        }

        /// <summary>
        /// Open a new form to modify the selected sensor
        /// </summary>
        private void ModifySelectedSensor()
        {
            // find all (if any) selected rows
            var selectedRows = LcSensors.Grid.Selections.GetSelectedRows(true, true);
            if (selectedRows.Count == 0) return;

            // we can just modify one, so the first
            var selectedRow = selectedRows[0];
            var selectedSensor = (ConfiguredSensor)LcSensors.Items[selectedRow.Top - 1];

            // show modding form
            using (var sensor = new SensorsMod(selectedSensor))
            {
                var res = sensor.ShowDialog();
                if (res != DialogResult.OK) return;

                // update in temp list
                _sensors[_sensors.FindIndex(x => x.Id == sensor.Sensor.Id)] = sensor.Sensor;

                // reload the gui list
                UpdateSensorsList();
            }
        }

        /// <summary>
        /// Delete all selected sensors
        /// <para>Note: doesn't actually execute deletion, that's done after the user clicks 'store'</para>
        /// </summary>
        private void DeleteSelectedSensors()
        {
            // check for selected rows
            var selectedRows = LcSensors.Grid.Selections.GetSelectedRows(true, true);
            if (selectedRows.Count == 0) return;

            // get selected row indexes
            var rowList = new List<int>();
            for (var i = LcSensors.Grid.Model.SelectedRanges.ActiveRange.Top; i <= LcSensors.Grid.Model.SelectedRanges.ActiveRange.Bottom; i++)
            {
                rowList.Add(i - 1);
            }

            // make descending
            rowList.Sort();
            rowList.Reverse();

            foreach (var row in rowList)
            {
                // get object
                var qA = (ConfiguredSensor)LcSensors.Items[row];

                // add to to-be-deleted list
                _toBeDeletedSensors.Add(qA);

                // remove from the list
                _sensors.RemoveAt(_sensors.FindIndex(x => x.Id == qA.Id));
            }

            // reload the gui list
            UpdateSensorsList();
        }

        /// <summary>
        /// Show a form to add a new sensor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (var sensor = new SensorsMod())
            {
                var res = sensor.ShowDialog();
                if (res != DialogResult.OK) return;

                // add to the temp list
                _sensors.Add(sensor.Sensor);

                // reload the gui list
                UpdateSensorsList();
            }
        }

        /// <summary>
        /// Stores our temporary list, and syncs it to HASS through MQTT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnStore_Click(object sender, EventArgs e)
        {
            // lock interface
            LcSensors.Enabled = false;
            BtnRemove.Enabled = false;
            BtnModify.Enabled = false;
            BtnAdd.Enabled = false;
            BtnStore.Enabled = false;
            BtnStore.Text = "storing and registering, please wait .. ";

            await Task.Run(async delegate
            {
                try
                {
                    // process the to-be-removed
                    if (_toBeDeletedSensors.Any())
                    {
                        foreach (var abstractSensor in _toBeDeletedSensors.Select(StoredSensors.ConvertConfiguredToAbstract).Where(abstractSensor => abstractSensor != null))
                        {
                            // remove and unregister
                            await abstractSensor.UnPublishAutoDiscoveryConfigAsync();
                            Variables.Sensors.RemoveAt(Variables.Sensors.FindIndex(x => x.Id == abstractSensor.Id));

                            Log.Information("[SENSORS] Removed sensor: {sensor}", abstractSensor.Name);
                        }
                    }

                    // copy our list to the main one
                    foreach (var abstractSensor in _sensors.Select(StoredSensors.ConvertConfiguredToAbstract).Where(abstractSensor => abstractSensor != null))
                    {
                        if (Variables.Sensors.All(x => x.Id != abstractSensor.Id))
                        {
                            // new, add and register
                            Variables.Sensors.Add(abstractSensor);
                            await abstractSensor.PublishAutoDiscoveryConfigAsync();
                            await abstractSensor.PublishStateAsync(false);

                            Log.Information("[SENSORS] Added sensor: {sensor}", abstractSensor.Name);
                            continue;
                        }

                        // existing, update and re-register
                        var currentSensorIndex = Variables.Sensors.FindIndex(x => x.Id == abstractSensor.Id);
                        if (Variables.Sensors[currentSensorIndex].Name != abstractSensor.Name)
                        {
                            // name changed, unregister
                            Log.Information("[SENSORS] Sensor changed name, re-registering as new entity: {old} to {new}", Variables.Sensors[currentSensorIndex].Name, abstractSensor.Name);

                            await Variables.Sensors[currentSensorIndex].UnPublishAutoDiscoveryConfigAsync();
                        }

                        Variables.Sensors[currentSensorIndex] = abstractSensor;
                        await abstractSensor.PublishAutoDiscoveryConfigAsync();
                        await abstractSensor.PublishStateAsync(false);

                        Log.Information("[SENSORS] Modified sensor: {sensor}", abstractSensor.Name);
                    }

                    // annouce ourselves
                    await MqttManager.AnnounceAvailabilityAsync("sensor");

                    // store to file
                    StoredSensors.Store();
                }
                catch (Exception ex)
                {
                    Log.Fatal(ex, "[SENSORS] Error while saving: {err}", ex.Message);
                    Variables.FrmM?.ShowMessageBox("An error occured while saving the sensors, check the logs for more info.", true);
                }
            });

            // done
            DialogResult = DialogResult.OK;
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            ModifySelectedSensor();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            DeleteSelectedSensors();
        }

        private void SensorsConfig_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape) return;
            Close();
        }

        private void SensorsConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            // unpause the sensors manager
            SensorsManager.Unpause();
        }

        private void LcSensors_DoubleClick(object sender, EventArgs e)
        {
            ModifySelectedSensor();
        }
    }
}
