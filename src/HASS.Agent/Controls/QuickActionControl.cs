﻿using HASS.Agent.Commands;
using HASS.Agent.Enums;
using HASS.Agent.Forms.QuickActions;
using HASS.Agent.HomeAssistant;
using HASS.Agent.Models.Internal;
using HASS.Agent.Properties;
using HASS.Agent.Shared.Enums;
using Serilog;

namespace HASS.Agent.Controls
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
            quickActionsForm.ClearFocus += delegate { FocusLost(); };

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

            PbImage.Image = _quickAction.Domain switch
            {
                HassDomain.Automation => Properties.Resources.qa_automate_225,
                HassDomain.Cover => Properties.Resources.qa_cover_225,
                HassDomain.Climate => Properties.Resources.qa_climate_225,
                HassDomain.Script => Properties.Resources.qa_script_225,
                HassDomain.InputBoolean => Properties.Resources.qa_inputboolean_225,
                HassDomain.MediaPlayer => Properties.Resources.qa_mediaplayer_225,
                HassDomain.Scene => Properties.Resources.qa_scene_225,
                HassDomain.Switch => Properties.Resources.qa_switch_225,
                HassDomain.Light => Properties.Resources.qa_light_225,
                HassDomain.HASSAgentCommands => Properties.Resources.logo_256,
                _ => Properties.Resources.hass_avatar
            };
        }

        /// <summary>
        /// Execute our QuickAction
        /// </summary>
        private void ExecuteCommand()
        {
            // is it an internal command?
            if (_quickAction.Domain == HassDomain.HASSAgentCommands)
            {
                // execute local command
                Task.Run(() => CommandsManager.ExecuteCommandByName(_quickAction.Entity));
            }
            else
            {
                // execute the command through HA
                Task.Run(() => HassApiManager.ProcessQuickActionAsync(_quickAction));
            }
            
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
