using System;
using System.Drawing;
using System.Windows.Forms;
using HASSAgent.Controls.Onboarding;
using HASSAgent.Enums;
using HASSAgent.Functions;
using HASSAgent.Models.Config;
using HASSAgent.Settings;
using Syncfusion.Windows.Forms;
using NotificationsControl = HASSAgent.Controls.Onboarding.Notifications;

namespace HASSAgent.Forms
{
    public partial class Onboarding : MetroForm
    {
        private Control _currentControl = null;

        public Onboarding()
        {
            InitializeComponent();
        }

        private void Onboarding_Load(object sender, EventArgs e)
        {
            ShowCurrentOnboardingStatus();
        }

        /// <summary>
        /// Loads the control corresponding to the current status
        /// </summary>
        private void ShowCurrentOnboardingStatus()
        {
            switch (Variables.AppSettings.OnboardingStatus)
            {
                case OnboardingStatus.NeverDone:
                case OnboardingStatus.Aborted:
                    ShowWelcome();
                    break;

                case OnboardingStatus.ScheduledTask:
                    ShowScheduledTask();
                    break;

                case OnboardingStatus.Notifications:
                    ShowNotifications();
                    break;

                case OnboardingStatus.Integration:
                    ShowIntegration();
                    break;

                case OnboardingStatus.API:
                    ShowAPI();
                    break;

                case OnboardingStatus.MQTT:
                    ShowMQTT();
                    break;

                case OnboardingStatus.HotKey:
                    ShowHotKey();
                    break;

                case OnboardingStatus.Updates:
                    ShowUpdates();
                    break;

                case OnboardingStatus.Completed:
                    ShowDone();
                    break;
            }
        }

        /// <summary>
        /// Show the next control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNext_Click(object sender, EventArgs e)
        {
            // store current values to in-memory appsettings
            // will return false if something went wrong (ie. wrong value)
            var stored = StoreCurrentControl();
            if (!stored) return;

            // switch to the next stage
            switch (Variables.AppSettings.OnboardingStatus)
            {
                case OnboardingStatus.NeverDone:
                case OnboardingStatus.Aborted:
                    ShowScheduledTask();
                    break;

                case OnboardingStatus.ScheduledTask:
                    ShowNotifications();
                    break;

                case OnboardingStatus.Notifications:
                    // only show integration info if notifications are enabled
                    if (Variables.AppSettings.NotificationsEnabled) ShowIntegration();
                    else ShowAPI();
                    break;

                case OnboardingStatus.Integration:
                    ShowAPI();
                    break;

                case OnboardingStatus.API:
                    ShowMQTT();
                    break;

                case OnboardingStatus.MQTT:
                    ShowHotKey();
                    break;

                case OnboardingStatus.HotKey:
                    ShowUpdates();
                    break;

                case OnboardingStatus.Updates:
                    ShowDone();
                    break;

                case OnboardingStatus.Completed:
                    Close();
                    break;
            }
        }

        /// <summary>
        /// Show the previous control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            // store current values to in-memory appsettings
            // will return false if something went wrong (ie. wrong value)
            var stored = StoreCurrentControl();
            if (!stored) return;

            // switch to the previous stage
            switch (Variables.AppSettings.OnboardingStatus)
            {
                case OnboardingStatus.ScheduledTask:
                    ShowWelcome();
                    break;

                case OnboardingStatus.Notifications:
                    ShowScheduledTask();
                    break;

                case OnboardingStatus.Integration:
                    ShowNotifications();
                    break;

                case OnboardingStatus.API:
                    // only show integration info if notifications are enabled
                    if (Variables.AppSettings.NotificationsEnabled) ShowIntegration();
                    else ShowNotifications();
                    break;

                case OnboardingStatus.MQTT:
                    ShowAPI();
                    break;

                case OnboardingStatus.HotKey:
                    ShowMQTT();
                    break;

                case OnboardingStatus.Updates:
                    ShowHotKey();
                    break;

                case OnboardingStatus.Completed:
                    ShowUpdates();
                    break;
            }
        }

        /// <summary>
        /// Asks the current control to store its settings (to memory)
        /// </summary>
        /// <returns></returns>
        private bool StoreCurrentControl()
        {
            switch (Variables.AppSettings.OnboardingStatus)
            {
                case OnboardingStatus.Notifications:
                {
                    var obj = (NotificationsControl)_currentControl;
                    return obj.Store();
                }

                case OnboardingStatus.API:
                {
                    var obj = (API)_currentControl;
                    return obj.Store();
                }

                case OnboardingStatus.MQTT:
                {
                    var obj = (MQTT)_currentControl;
                    return obj.Store();
                }

                case OnboardingStatus.HotKey:
                {
                    var obj = (HotKey)_currentControl;
                    return obj.Store();
                }

                case OnboardingStatus.Updates:
                {
                    var obj = (Updates)_currentControl;
                    return obj.Store();
                }
            }

            // default ok
            return true;
        }

        /// <summary>
        /// Closes the current control
        /// </summary>
        private void CloseCurrentControl()
        {
            if (_currentControl == null) return;

            GpOnboardingControl.Controls.Remove(_currentControl);
            _currentControl.Dispose();
        }

        /// <summary>
        /// Shows the current loaded control
        /// </summary>
        private void LoadCurrentControl()
        {
            if (_currentControl == null) return;

            _currentControl.Location = new Point(0, 0);

            GpOnboardingControl.SuspendLayout();
            GpOnboardingControl.Controls.Add(_currentControl);
            GpOnboardingControl.ResumeLayout(false);
        }

        /// <summary>
        /// Show Welcome page
        /// </summary>
        private void ShowWelcome()
        {
            CloseCurrentControl();

            Text = "HASS.Agent Onboarding: Start [1/9]";
            Variables.AppSettings.OnboardingStatus = OnboardingStatus.NeverDone;

            _currentControl = new Welcome();

            BtnPrevious.Visible = false;
            BtnNext.Text = "next";

            LoadCurrentControl();
        }

        /// <summary>
        /// Show Scheduled Task page
        /// </summary>
        private void ShowScheduledTask()
        {
            CloseCurrentControl();

            Text = "HASS.Agent Onboarding: Scheduled Task [2/9]";
            Variables.AppSettings.OnboardingStatus = OnboardingStatus.ScheduledTask;

            _currentControl = new ScheduledTask();

            BtnPrevious.Visible = true;
            BtnNext.Text = "next";

            LoadCurrentControl();
        }

        /// <summary>
        /// Show Notifications page
        /// </summary>
        private void ShowNotifications()
        {
            CloseCurrentControl();

            Text = "HASS.Agent Onboarding: Notifications [3/9]";
            Variables.AppSettings.OnboardingStatus = OnboardingStatus.Notifications;

            _currentControl = new NotificationsControl();

            BtnPrevious.Visible = true;
            BtnNext.Text = "next";

            LoadCurrentControl();
        }

        /// <summary>
        /// Show Integration page
        /// </summary>
        private void ShowIntegration()
        {
            CloseCurrentControl();

            Text = "HASS.Agent Onboarding: Integration [4/9]";
            Variables.AppSettings.OnboardingStatus = OnboardingStatus.Integration;

            _currentControl = new Integration();

            BtnPrevious.Visible = true;
            BtnNext.Text = "next";

            LoadCurrentControl();
        }

        /// <summary>
        /// Show API page
        /// </summary>
        // ReSharper disable once InconsistentNaming
        private void ShowAPI()
        {
            CloseCurrentControl();

            Text = "HASS.Agent Onboarding: API [5/9]";
            Variables.AppSettings.OnboardingStatus = OnboardingStatus.API;

            _currentControl = new API();

            BtnPrevious.Visible = true;
            BtnNext.Text = "next";

            LoadCurrentControl();
        }

        /// <summary>
        /// Show MQTT page
        /// </summary>
        // ReSharper disable once InconsistentNaming
        private void ShowMQTT()
        {
            CloseCurrentControl();

            Text = "HASS.Agent Onboarding: MQTT [6/9]";
            Variables.AppSettings.OnboardingStatus = OnboardingStatus.MQTT;

            _currentControl = new MQTT();

            BtnPrevious.Visible = true;
            BtnNext.Text = "next";

            LoadCurrentControl();
        }

        /// <summary>
        /// Show HotKey page
        /// </summary>
        private void ShowHotKey()
        {
            CloseCurrentControl();

            Text = "HASS.Agent Onboarding: HotKey [7/9]";
            Variables.AppSettings.OnboardingStatus = OnboardingStatus.HotKey;

            _currentControl = new HotKey();

            BtnPrevious.Visible = true;
            BtnNext.Text = "next";

            LoadCurrentControl();
        }

        /// <summary>
        /// Show Updates page
        /// </summary>
        private void ShowUpdates()
        {
            CloseCurrentControl();

            Text = "HASS.Agent Onboarding: Updates [8/9]";
            Variables.AppSettings.OnboardingStatus = OnboardingStatus.Updates;

            _currentControl = new Updates();

            BtnPrevious.Visible = true;
            BtnNext.Text = "next";

            BtnClose.Visible = true;

            LoadCurrentControl();
        }

        /// <summary>
        /// Show Completed page
        /// </summary>
        private void ShowDone()
        {
            CloseCurrentControl();

            Text = "HASS.Agent Onboarding: Completed [9/9]";
            Variables.AppSettings.OnboardingStatus = OnboardingStatus.Completed;

            _currentControl = new Done();

            BtnPrevious.Visible = true;
            BtnNext.Text = "finish";

            BtnClose.Visible = false;

            LoadCurrentControl();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (!ConfirmBeforeClose()) return;
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Checks to see if we need confirmation (and get it)
        /// </summary>
        /// <returns></returns>
        private static bool ConfirmBeforeClose()
        {
            // if we're completed, store and close
            if (Variables.AppSettings.OnboardingStatus == OnboardingStatus.Completed)
            {
                SettingsManager.StoreAppSettings();
                HelperFunctions.Restart();
                return true;
            }

            // if user is aborting, always ok
            if (Variables.AppSettings.OnboardingStatus == OnboardingStatus.Aborted) return true;

            // ask the user
            var q = MessageBoxAdv.Show("Are you sure you want to abort the onboarding process?\r\n\r\nYour progress will not be saved, and it will not be shown again on next launch.", "HASS.Agent", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (q != DialogResult.Yes) return false;

            // abort, we're done - load blanco settings and store
            Variables.AppSettings = new AppSettings();
            Variables.AppSettings.OnboardingStatus = OnboardingStatus.Aborted;
            SettingsManager.StoreAppSettings();
            return true;
        }

        private void Onboarding_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ConfirmBeforeClose()) e.Cancel = true;
        }
    }
}
