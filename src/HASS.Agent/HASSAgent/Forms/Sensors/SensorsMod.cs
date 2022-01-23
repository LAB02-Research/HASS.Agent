using Syncfusion.Windows.Forms;
using System;
using System.Drawing;
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

            // catch all key presses
            KeyPreview = true;

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
                    TbSetting1.Text = Sensor.WindowName;
                    break;

                case SensorType.WmiQuerySensor:
                    TbSetting1.Text = Sensor.Query;
                    break;

                case SensorType.PerformanceCounterSensor:
                    TbSetting1.Text = Sensor.Category;
                    TbSetting2.Text = Sensor.Counter;
                    TbSetting3.Text = Sensor.Instance;
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

                case SensorType.PerformanceCounterSensor:
                    SetPerformanceCounterGui();
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
                SetEmptyGui();

                LblSetting1.Text = "window name";
                LblSetting1.Visible = true;
                TbSetting1.Visible = true;
            }));
        }

        /// <summary>
        /// Change the UI to a 'wmi query' type
        /// </summary>
        private void SetWmiGui()
        {
            Invoke(new MethodInvoker(delegate
            {
                SetEmptyGui();

                LblSetting1.Text = "wmi query";
                LblSetting1.Visible = true;
                TbSetting1.Visible = true;
            }));
        }

        /// <summary>
        /// Change the UI to a 'performance counter' type
        /// </summary>
        private void SetPerformanceCounterGui()
        {
            Invoke(new MethodInvoker(delegate
            {
                LblSetting1.Text = "category";
                LblSetting1.Visible = true;
                TbSetting1.Text = string.Empty;
                TbSetting1.Visible = true;

                LblSetting2.Text = "counter";
                LblSetting2.Visible = true;
                TbSetting2.Text = string.Empty;
                TbSetting2.Visible = true;

                LblSetting3.Text = "instance (optional)";
                LblSetting3.Visible = true;
                TbSetting3.Text = "";
                TbSetting3.Visible = true;
            }));
        }

        /// <summary>
        /// Change the UI to a general type
        /// </summary>
        private void SetEmptyGui()
        {
            Invoke(new MethodInvoker(delegate
            {
                LblSetting1.Visible = false;
                TbSetting1.Text = string.Empty;
                TbSetting1.Visible = false;

                LblSetting2.Visible = false;
                TbSetting2.Text = string.Empty;
                TbSetting2.Visible = false;

                LblSetting3.Visible = false;
                TbSetting3.Text = string.Empty;
                TbSetting3.Visible = false;
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
            if (interval < 1 || interval > 43200)
            {
                MessageBox.Show("Enter an interval between 1 and 43200 (12 hours) first.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveControl = TbIntInterval;
                return;
            }

            // check and set optional settings
            switch (type)
            {
                case SensorType.NamedWindowSensor:
                    var window = TbSetting1.Text.Trim();
                    if (string.IsNullOrEmpty(window))
                    {
                        MessageBox.Show("Enter a window name first.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ActiveControl = TbSetting1;
                        return;
                    }
                    Sensor.WindowName = window;
                    break;

                case SensorType.WmiQuerySensor:
                    var query = TbSetting1.Text.Trim();
                    if (string.IsNullOrEmpty(query))
                    {
                        MessageBox.Show("Enter a query first.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ActiveControl = TbSetting1;
                        return;
                    }
                    Sensor.Query = query;
                    break;

                case SensorType.PerformanceCounterSensor:
                    var category = TbSetting1.Text.Trim();
                    var counter = TbSetting2.Text.Trim();
                    var instance = TbSetting3.Text.Trim();
                    if (string.IsNullOrEmpty(category) || string.IsNullOrEmpty(counter))
                    {
                        MessageBox.Show("Enter a category and instance first.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ActiveControl = TbSetting1;
                        return;
                    }
                    Sensor.Category = category;
                    Sensor.Counter = counter;
                    Sensor.Instance = instance;
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

        private void SensorsMod_ResizeEnd(object sender, EventArgs e)
        {
            if (Variables.ShuttingDown) return;
            if (!IsHandleCreated) return;
            if (IsDisposed) return;

            try
            {
                Refresh();
            }
            catch
            {
                // best effort
            }
        }

        /// <summary>
        /// Makes sure our combobox has the right colors
        /// <para>Source: https://stackoverflow.com/a/60421006 </para>
        /// <para>Source: https://stackoverflow.com/a/11650321 </para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbType_DrawItem(object sender, DrawItemEventArgs e)
        {
            // only if there are items
            if (CbType.Items.Count <= 0) return;

            // fetch the index
            var index = e.Index >= 0 ? e.Index : 0;
            
            // draw the control's background
            e.DrawBackground();

            // check if we have an item to process
            if (index != -1)
            {
                // optionally set the item's background color as selected
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(241, 241, 241)), e.Bounds);
                }

                // draw the string
                var brush = (e.State & DrawItemState.Selected) > 0 ? new SolidBrush(Color.FromArgb(63, 63, 70)) : new SolidBrush(CbType.ForeColor);
                e.Graphics.DrawString(CbType.Items[index].ToString(), e.Font, brush, e.Bounds, StringFormat.GenericDefault);
            }

            // draw focus rectangle
            e.DrawFocusRectangle();
        }

        private void SensorsMod_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape) return;
            Close();
        }
    }
}
