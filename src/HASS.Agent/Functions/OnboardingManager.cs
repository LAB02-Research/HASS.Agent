using HASS.Agent.Controls.Onboarding;
using HASS.Agent.Enums;
using HASS.Agent.Forms;
using HASS.Agent.Models.Config;
using HASS.Agent.Notifications;
using HASS.Agent.Resources.Localization;
using HASS.Agent.Settings;
using Syncfusion.Windows.Forms;

namespace HASS.Agent.Functions
{
    internal class OnboardingManager
    {
        private readonly Onboarding _onboarding;
        private Control _currentControl;

        private const int TOTAL_ONBOARDING_STEPS = 9;

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
                        var obj = (OnboardingWelcome)_currentControl;
                        var stored = obj.Store(out var languageChanged);
                        if (!stored) return false;

                        // reload ui?
                        if (languageChanged)  _onboarding.ReloadControlLanguage();

                        // done
                        return true;
                    }

                case OnboardingStatus.Notifications:
                    {
                        var obj = (OnboardingNotifications)_currentControl;
                        return obj.Store();
                    }

                case OnboardingStatus.API:
                    {
                        var obj = (OnboardingApi)_currentControl;
                        return obj.Store();
                    }

                case OnboardingStatus.MQTT:
                    {
                        var obj = (OnboardingMqtt)_currentControl;
                        return obj.Store();
                    }

                case OnboardingStatus.HotKey:
                    {
                        var obj = (OnboardingHotKey)_currentControl;
                        return obj.Store();
                    }

                case OnboardingStatus.Updates:
                    {
                        var obj = (OnboardingUpdates)_currentControl;
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

            const int onboardingStep = 1;

            _onboarding.Text = string.Format(Languages.OnboardingManager_OnboardingTitle_Start, onboardingStep, TOTAL_ONBOARDING_STEPS);
            Variables.AppSettings.OnboardingStatus = OnboardingStatus.NeverDone;

            _currentControl = new OnboardingWelcome();

            _onboarding.BtnPrevious.Visible = false;
            _onboarding.BtnNext.Text = Languages.Onboarding_BtnNext;

            LoadCurrentControl();
        }

        /// <summary>
        /// Show Scheduled Task page
        /// </summary>
        private void ShowStartup()
        {
            CloseCurrentControl();

            const int onboardingStep = 2;

            _onboarding.Text = string.Format(Languages.OnboardingManager_OnboardingTitle_Startup, onboardingStep, TOTAL_ONBOARDING_STEPS);
            Variables.AppSettings.OnboardingStatus = OnboardingStatus.Startup;

            _currentControl = new OnboardingStartup();

            _onboarding.BtnPrevious.Visible = true;
            _onboarding.BtnNext.Text = Languages.Onboarding_BtnNext;

            LoadCurrentControl();
        }

        /// <summary>
        /// Show Notifications page
        /// </summary>
        private void ShowNotifications()
        {
            CloseCurrentControl();

            const int onboardingStep = 3;

            _onboarding.Text = string.Format(Languages.OnboardingManager_OnboardingTitle_Notifications, onboardingStep, TOTAL_ONBOARDING_STEPS);
            Variables.AppSettings.OnboardingStatus = OnboardingStatus.Notifications;

            _currentControl = new OnboardingNotifications();

            _onboarding.BtnPrevious.Visible = true;
            _onboarding.BtnNext.Text = Languages.Onboarding_BtnNext;

            LoadCurrentControl();
        }

        /// <summary>
        /// Show Integration page
        /// </summary>
        private void ShowIntegration()
        {
            CloseCurrentControl();

            const int onboardingStep = 4;

            _onboarding.Text = string.Format(Languages.OnboardingManager_OnboardingTitle_Integration, onboardingStep, TOTAL_ONBOARDING_STEPS);
            Variables.AppSettings.OnboardingStatus = OnboardingStatus.Integration;

            _currentControl = new OnboardingIntegration();

            _onboarding.BtnPrevious.Visible = true;
            _onboarding.BtnNext.Text = Languages.Onboarding_BtnNext;

            LoadCurrentControl();
        }

        /// <summary>
        /// Show API page
        /// </summary>
        // ReSharper disable once InconsistentNaming
        private void ShowAPI()
        {
            CloseCurrentControl();

            const int onboardingStep = 5;

            _onboarding.Text = string.Format(Languages.OnboardingManager_OnboardingTitle_Api, onboardingStep, TOTAL_ONBOARDING_STEPS);
            Variables.AppSettings.OnboardingStatus = OnboardingStatus.API;

            _currentControl = new OnboardingApi();

            _onboarding.BtnPrevious.Visible = true;
            _onboarding.BtnNext.Text = Languages.Onboarding_BtnNext;

            LoadCurrentControl();
        }

        /// <summary>
        /// Show MQTT page
        /// </summary>
        // ReSharper disable once InconsistentNaming
        private void ShowMQTT()
        {
            CloseCurrentControl();

            const int onboardingStep = 6;

            _onboarding.Text = string.Format(Languages.OnboardingManager_OnboardingTitle_Mqtt, onboardingStep, TOTAL_ONBOARDING_STEPS);
            Variables.AppSettings.OnboardingStatus = OnboardingStatus.MQTT;

            _currentControl = new OnboardingMqtt();

            _onboarding.BtnPrevious.Visible = true;
            _onboarding.BtnNext.Text = Languages.Onboarding_BtnNext;

            LoadCurrentControl();
        }

        /// <summary>
        /// Show HotKey page
        /// </summary>
        private void ShowHotKey()
        {
            CloseCurrentControl();

            const int onboardingStep = 7;

            _onboarding.Text = string.Format(Languages.OnboardingManager_OnboardingTitle_HotKey, onboardingStep, TOTAL_ONBOARDING_STEPS);
            Variables.AppSettings.OnboardingStatus = OnboardingStatus.HotKey;

            _currentControl = new OnboardingHotKey();

            _onboarding.BtnPrevious.Visible = true;
            _onboarding.BtnNext.Text = Languages.Onboarding_BtnNext;

            LoadCurrentControl();
        }

        /// <summary>
        /// Show Updates page
        /// </summary>
        private void ShowUpdates()
        {
            CloseCurrentControl();

            const int onboardingStep = 8;

            _onboarding.Text = string.Format(Languages.OnboardingManager_OnboardingTitle_Updates, onboardingStep, TOTAL_ONBOARDING_STEPS);
            Variables.AppSettings.OnboardingStatus = OnboardingStatus.Updates;

            _currentControl = new OnboardingUpdates();

            _onboarding.BtnPrevious.Visible = true;
            _onboarding.BtnNext.Text = Languages.Onboarding_BtnNext;

            _onboarding.BtnClose.Visible = true;

            LoadCurrentControl();
        }

        /// <summary>
        /// Show Completed page
        /// </summary>
        private void ShowDone()
        {
            CloseCurrentControl();

            const int onboardingStep = 9;

            _onboarding.Text = string.Format(Languages.OnboardingManager_OnboardingTitle_Completed, onboardingStep, TOTAL_ONBOARDING_STEPS);
            Variables.AppSettings.OnboardingStatus = OnboardingStatus.Completed;

            _currentControl = new OnboardingDone();

            _onboarding.BtnPrevious.Visible = true;
            _onboarding.BtnNext.Text = Languages.OnboardingManager_BtnNext_Finish;

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
            var q = MessageBoxAdv.Show(Languages.OnboardingManager_ConfirmBeforeClose_MessageBox1, Variables.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
