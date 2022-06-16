using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using HASS.Agent.Functions;
using HASS.Agent.Managers;
using HASS.Agent.Resources.Localization;
using HASS.Agent.Shared.Functions;
using Microsoft.VisualBasic.Logging;
using Syncfusion.Windows.Forms;
using DialogResult = System.Windows.Forms.DialogResult;

namespace HASS.Agent.Controls.Onboarding
{
    public partial class OnboardingWelcome : UserControl
    {
        private ComponentResourceManager _resourceManager;
        private readonly string _previousCulture = Variables.CurrentUICulture.Name;

        public OnboardingWelcome()
        {
            InitializeComponent(); 
            
            BindComboBoxTheme();

            _resourceManager = new ComponentResourceManager(GetType());
        }

        private void BindComboBoxTheme() => CbLanguage.DrawItem += ComboBoxTheme.DrawItem;

        private void OnboardingWelcome_Load(object sender, EventArgs e)
        {
            // load all languages
            foreach (var lang in Variables.SupportedUILanguages) CbLanguage.Items.Add(lang.DisplayName);

            // select the current one
            CbLanguage.SelectedItem = Variables.CurrentUICulture.DisplayName;

            // set devicename
            TbDeviceName.Text = Variables.AppSettings.DeviceName;

            // focus on devicename
            ActiveControl = TbDeviceName;
        }

        internal bool Store(out bool languageChanged)
        {
            languageChanged = false;

            // make sure there's a device name
            if (string.IsNullOrWhiteSpace(TbDeviceName.Text)) TbDeviceName.Text = SharedHelperFunctions.GetSafeDeviceName();

            // sanitize devicename
            var deviceName = SharedHelperFunctions.GetSafeValue(TbDeviceName.Text);

            // different?
            if (deviceName != TbDeviceName.Text)
            {
                var q = MessageBoxAdv.Show(string.Format(Languages.OnboardingWelcome_Store_MessageBox1, deviceName),
                    Variables.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (q != DialogResult.Yes) return false;
            }

            // store devicename
            Variables.AppSettings.DeviceName = deviceName;

            // store ui language
            var uiLanguage = Variables.SupportedUILanguages.Find(x => x.DisplayName == CbLanguage.Text);
            Variables.AppSettings.InterfaceLanguage = uiLanguage?.Name ?? "en";

            if (uiLanguage?.Name != _previousCulture)
            {
                // ui language changed
                languageChanged = true;
            }

            // done
            return true;
        }

        private void CbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            var uiLanguage = Variables.SupportedUILanguages.Find(x => x.DisplayName == CbLanguage.Text);
            if (uiLanguage == null) return;

            if (uiLanguage.Name == _previousCulture) return;

            // set the new language
            LocalizationManager.SetNewUILanguage(uiLanguage.Name);

            // language changed
            ReloadUi();
        }

        private void ReloadUi()
        {
            LblInfo1.Text = Languages.OnboardingWelcome_LblInfo1;
            LblInfo2.Text = Languages.OnboardingWelcome_LblInfo2;
            LblDeviceName.Text = Languages.OnboardingWelcome_LblDeviceName;
            LblInterfaceLangauge.Text = Languages.OnboardingWelcome_LblInterfaceLangauge;
        }
    }
}
