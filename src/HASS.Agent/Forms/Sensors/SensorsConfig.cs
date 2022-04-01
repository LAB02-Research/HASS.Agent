using HASS.Agent.Extensions;
using HASS.Agent.Functions;
using HASS.Agent.Resources.Localization;
using Syncfusion.Windows.Forms;
using HASS.Agent.Sensors;
using HASS.Agent.Settings;
using HASS.Agent.Shared.Models.Config;
using Syncfusion.Windows.Forms.Grid;

namespace HASS.Agent.Forms.Sensors
{
    public partial class SensorsConfig : MetroForm
    {
        private List<ConfiguredSensor> _sensors = new();
        private readonly List<ConfiguredSensor> _toBeDeletedSensors = new();

        private bool _storing = false;
        
        public SensorsConfig()
        {
            InitializeComponent();

            BindListViewTheme();
        }

        private void BindListViewTheme()
        {
            LvSensors.DrawItem += ListViewTheme.DrawItem;
            LvSensors.DrawSubItem += ListViewTheme.DrawSubItem;
            LvSensors.DrawColumnHeader += ListViewTheme.DrawColumnHeader;
        }

        private void SensorsConfig_Load(object sender, EventArgs e)
        {
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
            _sensors = Variables.SingleValueSensors.Select(StoredSensors.ConvertAbstractSingleValueToConfigured).Where(configuredSensor => configuredSensor != null).ToList();
            _sensors = _sensors.Concat(Variables.MultiValueSensors.Select(StoredSensors.ConvertAbstractMultiValueToConfigured).Where(configuredSensor => configuredSensor != null)).ToList();

            // show them
            UpdateSensorsList();
        }

        /// <summary>
        /// Reload the sensors
        /// </summary>
        private void UpdateSensorsList()
        {
            LvSensors.BeginUpdate();

            // reload data
            LvSensors.Items.Clear();

            foreach (var sensor in _sensors)
            {
                var lviSensor = new ListViewItem(sensor.Id.ToString());
                lviSensor.SubItems.Add(sensor.Name);
                lviSensor.SubItems.Add(SensorsManager.SensorInfoCards[sensor.Type].Name);
                lviSensor.SubItems.Add(sensor.UpdateInterval.ToString());

                LvSensors.Items.Add(lviSensor);
            }

            LvSensors.EndUpdate();
        }

        /// <summary>
        /// Open a new form to modify the selected sensor
        /// </summary>
        private void ModifySelectedSensor()
        {
            // are we currently storing them?
            if (_storing) return;

            // check for selected rows
            if (LvSensors.SelectedItems.Count == 0) return;

            // we can just modify one, so the first
            var guid = Guid.Parse(LvSensors.SelectedItems[0].Text);
            var selectedSensor = _sensors.Find(x => x.Id == guid);

            // show modding form
            using var sensor = new SensorsMod(selectedSensor);
            var res = sensor.ShowDialog();
            if (res != DialogResult.OK) return;

            // update in temp list
            _sensors[_sensors.FindIndex(x => x.Id == sensor.Sensor.Id)] = sensor.Sensor;

            // reload the gui list
            UpdateSensorsList();
        }

        /// <summary>
        /// Delete all selected sensors
        /// <para>Note: doesn't actually execute deletion, that's done after the user clicks 'store'</para>
        /// </summary>
        private void DeleteSelectedSensors()
        {
            // check for selected rows
            if (LvSensors.SelectedItems.Count == 0) return;

            // iterate them
            foreach (ListViewItem row in LvSensors.SelectedItems)
            {
                // get object
                var guid = Guid.Parse(row.Text);
                var selectedSensor = _sensors.Find(x => x.Id == guid);

                // add to to-be-deleted list
                _toBeDeletedSensors.Add(selectedSensor);

                // remove from the list
                _sensors.RemoveAt(_sensors.FindIndex(x => x.Id == guid));
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
            using var sensor = new SensorsMod();
            var res = sensor.ShowDialog();
            if (res != DialogResult.OK) return;

            // add to the temp list
            _sensors.Add(sensor.Sensor);

            // reload the gui list
            UpdateSensorsList();
        }

        /// <summary>
        /// Stores our temporary list, and syncs it to HASS through MQTT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnStore_Click(object sender, EventArgs e)
        {
            // prevent user from opening sensors
            _storing = true;

            // lock interface
            BtnRemove.Enabled = false;
            BtnModify.Enabled = false;
            BtnAdd.Enabled = false;
            BtnStore.Enabled = false;
            BtnStore.Text = Languages.SensorsConfig_BtnStore_Storing;

            // store
            var stored = await Task.Run(async () => await SensorsManager.StoreAsync(_sensors, _toBeDeletedSensors));
            if (!stored) MessageBoxAdv.Show(Languages.SensorsConfig_BtnStore_MessageBox1, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);

            // done
            Close();
        }

        private void BtnModify_Click(object sender, EventArgs e) => ModifySelectedSensor();

        private void BtnRemove_Click(object sender, EventArgs e) => DeleteSelectedSensors();

        private void SensorsConfig_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape) return;
            Close();
        }

        private void SensorsConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            //
        }

        private void LvSensors_DoubleClick(object sender, EventArgs e) => ModifySelectedSensor();

        private void SensorsConfig_ResizeEnd(object sender, EventArgs e)
        {
            if (Variables.ShuttingDown) return;
            if (!IsHandleCreated) return;
            if (IsDisposed) return;

            try
            {
                // show the listview
                LvSensors.Visible = true;

                // hide the pesky horizontal scrollbar
                ListViewTheme.ShowScrollBar(LvSensors.Handle, ListViewTheme.SB_HORZ, false);

                Refresh();
            }
            catch
            {
                // best effort
            }
        }

        private void SensorsConfig_ResizeBegin(object sender, EventArgs e)
        {
            if (Variables.ShuttingDown) return;
            if (!IsHandleCreated) return;
            if (IsDisposed) return;

            try
            {
                // hide the listview to prevent flickering
                LvSensors.Visible = false;
            }
            catch
            {
                // best effort
            }
        }

        private void SensorsConfig_Layout(object sender, LayoutEventArgs e)
        {
            // hide the pesky horizontal scrollbar
            ListViewTheme.ShowScrollBar(LvSensors.Handle, ListViewTheme.SB_HORZ, false);
        }
    }
}
