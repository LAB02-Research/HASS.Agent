using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using HASSAgent.Enums;
using HASSAgent.Forms.QuickActions;
using HASSAgent.HomeAssistant;
using HASSAgent.Models.Internal;
using HASSAgent.Properties;
using Serilog;

namespace HASSAgent.Controls
{
    /// <summary>
    /// UI Control to let the user execute a QuickAction
    /// </summary>
    public partial class QuickActionControl : UserControl
    {
        private readonly QuickAction _quickAction;
        private readonly QuickActions _quickActionsForm;

        /// <summary>
        /// Requires a QuickAction object, and a reference to the QuickActions form
        /// </summary>
        /// <param name="quickAction"></param>
        /// <param name="quickActionsForm"></param>
        public QuickActionControl(QuickAction quickAction, QuickActions quickActionsForm)
        {
            _quickAction = quickAction;
            _quickActionsForm = quickActionsForm;

            // bind to unfocus event
            quickActionsForm.ClearFocus += delegate
            {
                FocusLost();
            };

            InitializeComponent();
        }

        /// <summary>
        /// Loads the QuickAction
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuickActionControl_Load(object sender, EventArgs e)
        {
            // bind mouse enter/leave events
            foreach (Control control in Controls)
            {
                control.MouseEnter += QuickActionControl_MouseEnter;
                control.MouseLeave += QuickActionControl_MouseLeave;
            }
            
            // load values
            LblAction.Text = $"[{_quickAction.Action.ToString().ToUpper()}]";
            LblEntity.Text = string.IsNullOrEmpty(_quickAction.Description) ? _quickAction.Entity : _quickAction.Description;

            switch (_quickAction.Domain)
            {
                case HassDomain.Automation:
                    PbImage.Image = Resources.qa_automate_225;
                    break;
                case HassDomain.Script:
                    PbImage.Image = Resources.qa_script_225;
                    break;
                case HassDomain.InputBoolean:
                    PbImage.Image = Resources.qa_inputboolean_225;
                    break;
                case HassDomain.Scene:
                    PbImage.Image = Resources.qa_scene_225;
                    break;
                case HassDomain.Switch:
                    PbImage.Image = Resources.qa_switch_225;
                    break;
                case HassDomain.Light:
                    PbImage.Image = Resources.qa_light_225;
                    break;
                default:
                    PbImage.Image = Resources.hass_avatar;
                    break;
            }
        }

        /// <summary>
        /// Execute our QuickAction
        /// </summary>
        private void ExecuteCommand()
        {
            // execute the command (don't wait)
            Task.Run(() => HassApiManager.ProcessQuickActionAsync(_quickAction));

            // close our parent window
            _quickActionsForm?.CloseWindow();
        }

        private void QuickActionControl_Click(object sender, EventArgs e) => ExecuteCommand();

        private void PbImage_Click(object sender, EventArgs e) => ExecuteCommand();

        private void LblAction_Click(object sender, EventArgs e) => ExecuteCommand();

        private void LblEntity_Click(object sender, EventArgs e) => ExecuteCommand();
        
        private void QuickActionControl_MouseEnter(object sender, EventArgs e) => OnFocus();

        private void QuickActionControl_MouseLeave(object sender, EventArgs e) => FocusLost();

        /// <summary>
        /// Set backcolor
        /// </summary>
        public void OnFocus()
        {
            try
            {
                _quickActionsForm.ClearAllFocus();

                Focus();

                BackColor = Color.FromArgb(241, 241, 241);
                LblEntity.ForeColor = Color.FromArgb(45, 45, 48);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reset backcolor
        /// </summary>
        public void FocusLost()
        {
            try
            {
                BackColor = Color.FromArgb(45, 45, 48);
                LblEntity.ForeColor = Color.FromArgb(241, 241, 241);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, ex.Message);
            }
        }

        /// <summary>
        /// Triggers the command when ENTER or SPACE are pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuickActionControl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter && e.KeyCode != Keys.Space) return;
            ExecuteCommand();
        }
    }
}
