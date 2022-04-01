using HASS.Agent.Forms.Sensors;
using HASS.Agent.Functions;
using HASS.Agent.Resources.Localization;
using HASS.Agent.Sensors;
using HASS.Agent.Shared.Models.Config;
using Serilog;
using Syncfusion.Windows.Forms;

namespace HASS.Agent.Controls.Service
{
    public partial class ServiceSensors : UserControl
    {
        private string _deviceName;
        private readonly List<ConfiguredSensor> _sensors = new();

        private bool _storing = false;

        public ServiceSensors()
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

        private void ServiceSensors_Load(object sender, EventArgs e)
        {
            //
        }

        /// <summary>
        /// Load the provided sensors
        /// </summary>
        /// <param name="configuredSensors"></param>
        /// <param name="deviceName"></param>
        public void SetSensors(List<ConfiguredSensor> configuredSensors, string deviceName)
        {
            _deviceName = deviceName;
            foreach (var sensor in configuredSensors) _sensors.Add(sensor);

            UpdateSensorsList();
        }

        /// <summary>
        /// Reload the sensors
        /// </summary>
        private void UpdateSensorsList()
        {
            try
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
            catch (NullReferenceException)
            {
                // whatever
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "[SERVICECONFIG_COMMANDS] Error while updating: {err}", ex.Message);
            }
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
            using var sensor = new SensorsMod(selectedSensor, true, _deviceName);
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
            using var sensor = new SensorsMod(true, _deviceName);
            var res = sensor.ShowDialog();
            if (res != DialogResult.OK) return;

            // add to the temp list
            _sensors.Add(sensor.Sensor);

            // reload the gui list
            UpdateSensorsList();
        }

        private void BtnModify_Click(object sender, EventArgs e) => ModifySelectedSensor();

        private void BtnRemove_Click(object sender, EventArgs e) => DeleteSelectedSensors();

        /// <summary>
        /// Sends the current list to the service
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnStore_Click(object sender, EventArgs e)
        {
            // lock interface
            LockUi();

            // store
            var (storedOk, _) = await Task.Run(async () => await Variables.RpcClient.SetConfiguredSensorsAsync(_sensors).WaitAsync(Variables.RpcConnectionTimeout));
            if (!storedOk) MessageBoxAdv.Show(Languages.ServiceSensors_BtnStore_MessageBox1, Variables.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else await ShowStored();

            // done, unlock ui
            UnlockUi();
        }

        private void LockUi()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(LockUi));
                return;
            }

            BtnStore.Text = Languages.ServiceSensors_BtnStore_Storing;
            _storing = true;

            foreach (var button in Controls.OfType<Button>()) button.Enabled = false;
            foreach (var textBox in Controls.OfType<TextBox>()) textBox.Enabled = false;
            foreach (var checkBox in Controls.OfType<CheckBox>()) checkBox.Enabled = false;
            foreach (var numericUpDown in Controls.OfType<NumericUpDown>()) numericUpDown.Enabled = false;
        }

        private void UnlockUi()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(UnlockUi));
                return;
            }

            BtnStore.Text = Languages.ServiceSensors_BtnStore;
            _storing = false;

            foreach (var button in Controls.OfType<Button>()) button.Enabled = true;
            foreach (var textBox in Controls.OfType<TextBox>()) textBox.Enabled = true;
            foreach (var checkBox in Controls.OfType<CheckBox>()) checkBox.Enabled = true;
            foreach (var numericUpDown in Controls.OfType<NumericUpDown>()) numericUpDown.Enabled = true;
        }

        private async Task ShowStored()
        {
            Invoke(new MethodInvoker(delegate { LblStored.Visible = true; }));
            await Task.Delay(TimeSpan.FromSeconds(3));
            Invoke(new MethodInvoker(delegate { LblStored.Visible = false; }));
        }

        private void LvSensors_DoubleClick(object sender, EventArgs e) => ModifySelectedSensor();

        private void Sensors_Layout(object sender, LayoutEventArgs e)
        {
            // hide the pesky horizontal scrollbar
            ListViewTheme.ShowScrollBar(LvSensors.Handle, ListViewTheme.SB_HORZ, false);
        }
    }
}
