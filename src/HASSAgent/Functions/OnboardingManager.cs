using HASSAgent.Controls.Onboarding;
using HASSAgent.Enums;
using HASSAgent.Forms;
using HASSAgent.Models.Config;
using HASSAgent.Notifications;
using HASSAgent.Settings;
using Syncfusion.Windows.Forms;
using NotificationsControl = HASSAgent.Controls.Onboarding.Notifications;

namespace HASSAgent.Functions
{
    internal class OnboardingManager
    {
        private readonly Onboarding _onboarding;
        private Control _currentControl;

        internal OnboardingManager(Onboarding onboarding)
        {
            _onboarding = onboarding;
        }

        /// <summary>
        /// Loads the control corresponding to the current status
        /// </summary>
        internal void ShowCurrentOnboardingStatus()
        {
            switch (Variables.AppSettings.OnboardingStatus)
            {
                case OnboardingStatus.NeverDone:
                case OnboardingStatus.Aborted:
                    ShowWelcome();
                    break;

                case OnboardingStatus.Startup:
                    ShowStartup();
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
        /// Show the previous control (if any)
        /// </summary>
        internal void ShowPrevious()
        {
            // store current values to in-memory appsettings
            // will return false if something went wrong (ie. wrong value)
            var stored = StoreCurrentControl();
            if (!stored) return;

            // switch to the previous stage
            switch (Variables.AppSettings.OnboardingStatus)
            {
                case OnboardingStatus.Startup:
                    ShowWelcome();
                    break;

                case OnboardingStatus.Notifications:
                    ShowStartup();
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
        /// Show the next control (if any)
        /// </summary>
        internal void ShowNext()
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
                    ShowStartup();
                    break;

                case OnboardingStatus.Startup:
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
                    _onboarding.Close();
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
                case OnboardingStatus.NeverDone:
                {
                    var obj = (Welcome)_currentControl;
                    return obj.Store();
                    }

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
                        var obj = (Controls.Onboarding.MQTT)_currentControl;
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

            _onboarding.GpOnboardingControl.Controls.Remove(_currentControl);
            _currentControl.Dispose();
        }

        /// <summary>
        /// Shows the current loaded control
        /// </summary>
        private void LoadCurrentControl()
        {
            if (_currentControl == null) return;

            _currentControl.Location = new Point(0, 0);

            _onboarding.GpOnboardingControl.SuspendLayout();
            _onboarding.GpOnboardingControl.Controls.Add(_currentControl);
            _onboarding.GpOnboardingControl.ResumeLayout(false);
        }

        /// <summary>
        /// Show Welcome page
        /// </summary>
        private void ShowWelcome()
        {
            CloseCurrentControl();

            _onboarding.Text = "HASS.Agent Onboarding: Start [1/9]";
            Variables.AppSettings.OnboardingStatus = OnboardingStatus.NeverDone;

            _currentControl = new Welcome();

            _onboarding.BtnPrevious.Visible = false;
            _onboarding.BtnNext.Text = "next";

            LoadCurrentControl();
        }

        /// <summary>
        /// Show Scheduled Task page
        /// </summary>
        private void ShowStartup()
        {
            CloseCurrentControl();

            _onboarding.Text = "HASS.Agent Onboarding: Startup [2/9]";
            Variables.AppSettings.OnboardingStatus = OnboardingStatus.Startup;

            _currentControl = new Startup();

            _onboarding.BtnPrevious.Visible = true;
            _onboarding.BtnNext.Text = "next";

            LoadCurrentControl();
        }

        /// <summary>
        /// Show Notifications page
        /// </summary>
        private void ShowNotifications()
        {
            CloseCurrentControl();

            _onboarding.Text = "HASS.Agent Onboarding: Notifications [3/9]";
            Variables.AppSettings.OnboardingStatus = OnboardingStatus.Notifications;

            _currentControl = new NotificationsControl();

            _onboarding.BtnPrevious.Visible = true;
            _onboarding.BtnNext.Text = "next";

            LoadCurrentControl();
        }

        /// <summary>
        /// Show Integration page
        /// </summary>
        private void ShowIntegration()
        {
            CloseCurrentControl();

            _onboarding.Text = "HASS.Agent Onboarding: Integration [4/9]";
            Variables.AppSettings.OnboardingStatus = OnboardingStatus.Integration;

            _currentControl = new Integration();

            _onboarding.BtnPrevious.Visible = true;
            _onboarding.BtnNext.Text = "next";

            LoadCurrentControl();
        }

        /// <summary>
        /// Show API page
        /// </summary>
        // ReSharper disable once InconsistentNaming
        private void ShowAPI()
        {
            CloseCurrentControl();

            _onboarding.Text = "HASS.Agent Onboarding: API [5/9]";
            Variables.AppSettings.OnboardingStatus = OnboardingStatus.API;

            _currentControl = new API();

            _onboarding.BtnPrevious.Visible = true;
            _onboarding.BtnNext.Text = "next";

            LoadCurrentControl();
        }

        /// <summary>
        /// Show MQTT page
        /// </summary>
        // ReSharper disable once InconsistentNaming
        private void ShowMQTT()
        {
            CloseCurrentControl();

            _onboarding.Text = "HASS.Agent Onboarding: MQTT [6/9]";
            Variables.AppSettings.OnboardingStatus = OnboardingStatus.MQTT;

            _currentControl = new Controls.Onboarding.MQTT();

            _onboarding.BtnPrevious.Visible = true;
            _onboarding.BtnNext.Text = "next";

            LoadCurrentControl();
        }

        /// <summary>
        /// Show HotKey page
        /// </summary>
        private void ShowHotKey()
        {
            CloseCurrentControl();

            _onboarding.Text = "HASS.Agent Onboarding: HotKey [7/9]";
            Variables.AppSettings.OnboardingStatus = OnboardingStatus.HotKey;

            _currentControl = new HotKey();

            _onboarding.BtnPrevious.Visible = true;
            _onboarding.BtnNext.Text = "next";

            LoadCurrentControl();
        }

        /// <summary>
        /// Show Updates page
        /// </summary>
        private void ShowUpdates()
        {
            CloseCurrentControl();

            _onboarding.Text = "HASS.Agent Onboarding: Updates [8/9]";
            Variables.AppSettings.OnboardingStatus = OnboardingStatus.Updates;

            _currentControl = new Updates();

            _onboarding.BtnPrevious.Visible = true;
            _onboarding.BtnNext.Text = "next";

            _onboarding.BtnClose.Visible = true;

            LoadCurrentControl();
        }

        /// <summary>
        /// Show Completed page
        /// </summary>
        private void ShowDone()
        {
            CloseCurrentControl();

            _onboarding.Text = "HASS.Agent Onboarding: Completed [9/9]";
            Variables.AppSettings.OnboardingStatus = OnboardingStatus.Completed;

            _currentControl = new Done();

            _onboarding.BtnPrevious.Visible = true;
            _onboarding.BtnNext.Text = "finish";

            _onboarding.BtnClose.Visible = false;

            LoadCurrentControl();
        }

        /// <summary>
        /// Checks to see if we need confirmation (and get it)
        /// </summary>
        /// <returns></returns>
        internal bool ConfirmBeforeClose()
        {
            // if we're completed, finalize and close
            if (Variables.AppSettings.OnboardingStatus == OnboardingStatus.Completed)
            {
                FinalizeOnboarding();
                return true;
            }

            // if user is aborting, always ok
            if (Variables.AppSettings.OnboardingStatus == OnboardingStatus.Aborted) return true;

            // ask the user
            var q = MessageBoxAdv.Show("Are you sure you want to abort the onboarding process?\r\n\r\nYour progress will not be saved, and it will not be shown again on next launch.", "HASS.Agent", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (q != DialogResult.Yes) return false;

            // abort, we're done - load blanco settings and store
            // we're disabling notifications because we didn't reserve the port
            Variables.AppSettings = new AppSettings
            {
                OnboardingStatus = OnboardingStatus.Aborted,
                NotificationsEnabled = false
            };
            SettingsManager.StoreAppSettings();
            return true;
        }

        /// <summary>
        /// Finalizes the onboarding process
        /// </summary>
        private void FinalizeOnboarding()
        {
            // lock interface
            _onboarding.BtnClose.Enabled = false;
            _onboarding.BtnNext.Enabled = false;
            _onboarding.BtnPrevious.Enabled = false;

            // write all settings to disk
            SettingsManager.StoreAppSettings();

            // if the notification api's activated, execute port binding
            if (Variables.AppSettings.NotificationsEnabled) NotifierManager.ExecuteElevatedPortReservation();

            // done, restart
            HelperFunctions.Restart(true);
        }
    }
}
