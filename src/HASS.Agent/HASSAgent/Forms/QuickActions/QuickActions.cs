using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using HASSAgent.Controls;
using HASSAgent.Enums;
using HASSAgent.Functions;
using HASSAgent.HomeAssistant;
using HASSAgent.Models;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;

namespace HASSAgent.Forms.QuickActions
{
    public partial class QuickActions : MetroForm
    {
        // ReSharper disable once NotAccessedField.Local
        private FlowLayout _quickActionsLayout;

        private readonly List<QuickAction> _quickActions = new List<QuickAction>();

        public QuickActions(List<QuickAction> quickActions)
        {
            foreach (var quickAction in quickActions) _quickActions.Add(quickAction);

            InitializeComponent();
        }

        private async void QuickActions_Load(object sender, System.EventArgs e)
        {
            // catch all key presses
            KeyPreview = true;

            // hide to prevent flickering
            Visible = false;

            // create our layout
            BuildLayout();

            // re-center
            CenterToScreen();

            // show ourselves
            Opacity = 100;
            Visible = true;

            // get focus (so the esc button works)
            BringToFront();
            Activate();

            // check hass status
            var hass = await CheckHassManagerAsync();
            if (!hass) CloseWindow();
        }

        /// <summary>
        /// Prepares the FlowLayout, resizes our form accordingly and load the QuickAction controls
        /// </summary>
        private void BuildLayout()
        {
            // create grid layout
            _quickActionsLayout = new FlowLayout(PnlActions)
            {
                AutoLayout = true,
                HGap = 5,
                VGap = 5,
                AutoHeight = true
            };

            // determine layout
            var (columns, rows) = HelperFunctions.DetermineRowColumnCount(_quickActions);
            if (columns == 0 && rows == 0)
            {
                CloseWindow();
                return;
            }

            // resize window
            Width = 152 * columns + 20;
            Height = 255 * rows + 30;

            if (columns > 1) Width += 5 * (columns - 1);
            if (rows > 1) Height += 5 * (rows - 1);

            // add the quickactions as controls
            foreach (var quickAction in _quickActions.Select(qA => new QuickActionControl(qA, this)))
            {
                PnlActions.Controls.Add(quickAction);
            }

            // perform layout
            PnlActions.PerformLayout();
        }

        /// <summary>
        /// Tries to close the window
        /// </summary>
        internal void CloseWindow()
        {
            if (!IsHandleCreated) return;
            if (IsDisposed) return;

            Invoke(new MethodInvoker(delegate
            {
                DialogResult = DialogResult.OK;
                Close();
            }));
        }

        /// <summary>
        /// Check whether the HASS manager is ready to process our request
        /// </summary>
        /// <returns></returns>
        private async Task<bool> CheckHassManagerAsync()
        {
            switch (HassApiManager.ManagerStatus)
            {
                case HassManagerStatus.Ready:
                    return true;

                case HassManagerStatus.ConfigMissing:
                    MessageBoxAdv.Show("Unable to fetch your entities because of missing config, please enter the required values in the config screen.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;

                case HassManagerStatus.Failed:
                    MessageBoxAdv.Show("There was an error trying to fetch your entities.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;

                case HassManagerStatus.Initialising:
                case HassManagerStatus.LoadingData:
                    SetGuiLoading(true);
                    while (HassApiManager.ManagerStatus != HassManagerStatus.Ready)
                    {
                        await Task.Delay(150);
                        if (HassApiManager.ManagerStatus != HassManagerStatus.Failed) continue;

                        MessageBoxAdv.Show("There was an error trying to fetch your entities.", "HASS.Agent", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    SetGuiLoading(false);
                    break;
            }

            return true;
        }

        /// <summary>
        /// Lock the UI while loading
        /// </summary>
        /// <param name="loading"></param>
        private void SetGuiLoading(bool loading)
        {
            if (!IsHandleCreated) return;
            if (IsDisposed) return;

            Invoke(new MethodInvoker(delegate
            {
                LblLoading.Visible = loading;
            }));
        }

        private void QuickActions_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape) return;
            Close();
        }
    }
}
