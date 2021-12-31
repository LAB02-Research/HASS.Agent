using Syncfusion.Windows.Forms;
using System;
using System.Linq;
using System.Windows.Forms;
using HASSAgent.Enums;
using HASSAgent.Functions;
using HASSAgent.Models.Config;
using HASSAgent.Sensors;

namespace HASSAgent.Forms.Sensors
{
    public partial class SensorsMod : MetroForm
    {
        internal readonly ConfiguredSensor Sensor;

        public SensorsMod(ConfiguredSensor sensor)
        {
            Sensor = sensor;
            InitializeComponent();
        }

        public SensorsMod()
        {
            Sensor = new ConfiguredSensor();
            InitializeComponent();
        }

        private void SensorMod_Load(object sender, EventArgs e)
        {
            // load enums
            CbType.DataSource = Enum.GetValues(typeof(SensorType));

            // load or set sensor
            if (Sensor.Id == Guid.Empty)
            {
                Sensor.Id = Guid.NewGuid();
                Text = "New Sensor";
                return;
            }

            LoadSensor();
            Text = "Mod Sensor";
        }

        /// <summary>
        /// Loads the to-be-modded sensor
        /// </summary>
        private void LoadSensor()
        {
            // load the type
            CbType.Text = Sensor.Type.ToString();
            SetType(false);

            // set the name
            TbName.Text = Sensor.Name;

            // set interval
            TbIntInterval.Text = Sensor.UpdateInterval?.ToString() ?? "10";

            // set optional setting
            var parsed = Enum.TryParse<SensorType>(CbType.SelectedValue.ToString(), out var type);
            if (!parsed) return;

            switch (type)
            {
                case SensorType.NamedWindowSensor:
                    TbSetting.Text = Sensor.WindowName;
                    break;

                case SensorType.WmiQuerySensor:
                    TbSetting.Text = Sensor.Query;
                    break;
            }

            // redraw
            Refresh();
        }

        /// <summary>
        /// Change the UI depending on the selected type
        /// </summary>
        /// <param name="setInfo"></param>
        private void SetType(bool setInfo = true)
        {
            var parsed = Enum.TryParse<SensorType>(CbType.SelectedValue.ToString(), out var type);
            if (!parsed) return;

            if (setInfo)
            {
                var (name, interval) = SensorsManager.GetSensorDefaultInfo(type);
                TbIntInterval.Text = interval.ToString();
                TbDescription.Text = name;
                TbName.Text = type.GetSensorName();
            }

            switch (type)
            {
                case SensorType.NamedWindowSensor:
                    SetWindowGui();
                    break;

                case SensorType.WmiQuerySensor:
                    SetWmiGui();
                    break;
                
                default:
                    SetEmptyGui();
                    break;
            }
        }

        /// <summary>
        /// Change the UI to a 'named window' type
        /// </summary>
        private void SetWindowGui()
        {
            Invoke(new MethodInvoker(delegate
            {
                LblSetting.Text = "window name";
                LblSetting.Visible = true;
                TbSetting.Visible = true;
            }));
        }

        /// <summary>
        /// Change the UI to a 'wmi query' type
        /// </summary>
        private void SetWmiGui()
        {
            Invoke(new MethodInvoker(delegate
            {
                LblSetting.Text = "wmi query";
                LblSetting.Visible = true;
                TbSetting.Visible = true;
            }));
        }

        /// <summary>
        /// Change the UI to a general type
        /// </summary>
        private void SetEmptyGui()
        {
            Invoke(new MethodInvoker(delegate
            {
                LblSetting.Visible = false;
                TbSetting.Visible = false;
            }));
        }

        private void CbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetType();

            // redraw
            Refresh();
        }

        /// <summary>
        /// Prepare the sensor for processing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStore_Click(object sender, EventArgs e)
        {
            // get and check type
            var typeStr = CbType.Text;
            if (string.IsNullOrEmpty(typeStr))
            {
                MessageBox.Show("Select a type first.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = CbType;
                return;
            }

            var parsed = Enum.TryParse<SensorType>(CbType.SelectedValue.ToString(), out var type);
            if (!parsed)
            {
                MessageBox.Show("Select a valid type first.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = CbType;
                return;
            }

            // get and check name
            var name = TbName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Enter a name first.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = TbName;
                return;
            }

            // name already used?
            if (Variables.SingleValueSensors.Any(x => string.Equals(x.Name, name, StringComparison.InvariantCultureIgnoreCase) && x.Id != Sensor.Id.ToString()))
            {
                var confirm = MessageBoxAdv.Show("There's already a single-value sensor with that name. Are you sure you want to continue?", "HASS.Agent", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes)
                {
                    ActiveControl = TbName;
                    return;
                }
            }

            if (Variables.MultiValueSensors.Any(x => string.Equals(x.Name, name, StringComparison.InvariantCultureIgnoreCase) && x.Id != Sensor.Id.ToString()))
            {
                var confirm = MessageBoxAdv.Show("There's already a multi-value sensor with that name. Are you sure you want to continue?", "HASS.Agent", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes)
                {
                    ActiveControl = TbName;
                    return;
                }
            }

            // get and check update interval
            var interval = (int)TbIntInterval.IntegerValue;
            if (interval < 1 || interval > 300)
            {
                MessageBox.Show("Enter an interval between 1 and 300 first.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = TbIntInterval;
                return;
            }

            // check and set optional settings
            switch (type)
            {
                case SensorType.NamedWindowSensor:
                    var window = TbSetting.Text.Trim();
                    if (string.IsNullOrEmpty(window))
                    {
                        MessageBox.Show("Enter a window name first.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ActiveControl = TbSetting;
                        return;
                    }
                    Sensor.WindowName = window;
                    break;

                case SensorType.WmiQuerySensor:
                    var query = TbSetting.Text.Trim();
                    if (string.IsNullOrEmpty(query))
                    {
                        MessageBox.Show("Enter a query first.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ActiveControl = TbSetting;
                        return;
                    }
                    Sensor.Query = query;
                    break;
            }

            // set values
            Sensor.Type = type;
            Sensor.Name = name;
            Sensor.UpdateInterval = interval;

            // done
            DialogResult = DialogResult.OK;
        }

        private void TbDescription_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.LinkText)) return;
            if (!e.LinkText.ToLower().StartsWith("http")) return;

            HelperFunctions.LaunchUrl(e.LinkText);
        }
    }
}
