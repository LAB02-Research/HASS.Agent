using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HASS.Agent.Models.Internal;
using Serilog;

namespace HASS.Agent.Functions
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    internal static class LocalizationManager
    {
        /// <summary>
        /// Loads supported languages, and tries to set the stored language as the current UI language
        /// </summary>
        internal static void Initialize()
        {
            // load supported languages
            LoadSupportedUILanguages();

            // set stored
            SetStoredUILanguage();
        }

        /// <summary>
        /// Sets the UI culture to the provided culturecode
        /// </summary>
        // ReSharper disable once InconsistentNaming
        private static void SetStoredUILanguage()
        {
            var cultureCode = Variables.AppSettings?.InterfaceLanguage;

            try
            {
                if (string.IsNullOrWhiteSpace(cultureCode))
                {
                    // nothing set, get system culture
                    var currentCulture = CultureInfo.CurrentUICulture;
                    cultureCode = currentCulture.Name;

                    Log.Information("[LOCALIZTION] No language setting stored, falling back to the system's UI culture: {culture}", currentCulture.DisplayName);
                }

                // load the culture (and trigger a not-found exception if it's malformed)
                var culture = new CultureInfo(cultureCode);

                // check if it's supported
                if (Variables.SupportedUILanguages.All(x => x.Name != culture.Name))
                {
                    Log.Warning("[LOCALIZATION] The selected UI culture isn't yet supported, please help out by translating:");
                    Log.Warning("[LOCALIZATION] https://github.com/LAB02-Research/HASS.Agent/wiki/Translating");

                    SetDefaultUILanguage();
                    return;
                }

                // store as current
                Variables.CurrentUICulture = new SupportedUILanguage(culture);

                // set as interface
                Thread.CurrentThread.CurrentUICulture = culture;
                Thread.CurrentThread.CurrentCulture = culture;

                Log.Information("[LOCALIZATION] Selected UI culture: [{code}] {culture}", Thread.CurrentThread.CurrentUICulture.Name, Thread.CurrentThread.CurrentUICulture.DisplayName);
            }
            catch (CultureNotFoundException)
            {
                Log.Error("[LOCALIZATION] Unable to set the selected culture '{culture}': {err}", cultureCode, "culture not known");
                SetDefaultUILanguage();
            }
            catch (Exception ex)
            {
                Log.Error("[LOCALIZATION] Unable to set the selected culture '{culture}': {err}", cultureCode, ex.Message);
                SetDefaultUILanguage();
            }
        }

        /// <summary>
        /// Tries to change the interface to the provided one
        /// </summary>
        /// <param name="cultureCode"></param>
        internal static void SetNewUILanguage(string cultureCode)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cultureCode)) return;

                // load the culture (and trigger a not-found exception if it's malformed)
                var culture = new CultureInfo(cultureCode);

                // check if it's supported
                if (Variables.SupportedUILanguages.All(x => x.Name != culture.Name))
                {
                    Log.Warning("[LOCALIZATION] The new UI culture isn't yet supported, please help out by translating:");
                    Log.Warning("[LOCALIZATION] https://github.com/LAB02-Research/HASS.Agent/wiki/Translating");

                    SetStoredUILanguage();
                    return;
                }

                // store as current
                Variables.CurrentUICulture = new SupportedUILanguage(culture);

                // set as interface
                Thread.CurrentThread.CurrentUICulture = culture;
                Thread.CurrentThread.CurrentCulture = culture;

                Log.Information("[LOCALIZATION] New UI culture: [{code}] {culture}", Thread.CurrentThread.CurrentUICulture.Name, Thread.CurrentThread.CurrentUICulture.DisplayName);
            }
            catch (CultureNotFoundException)
            {
                Log.Error("[LOCALIZATION] Unable to set the new culture '{culture}': {err}", cultureCode, "culture not known");
                SetDefaultUILanguage();
            }
            catch (Exception ex)
            {
                Log.Error("[LOCALIZATION] Unable to set the new culture '{culture}': {err}", cultureCode, ex.Message);
                SetDefaultUILanguage();
            }
        }
        
        /// <summary>
        /// Sets the UI to the default language
        /// </summary>
        private static void SetDefaultUILanguage()
        {
            // set default EN
            var defaultCulture = new CultureInfo("en");
            Log.Information("[LOCALIZATION] Setting default: {default}", defaultCulture.DisplayName);
            Thread.CurrentThread.CurrentUICulture = defaultCulture;

            // store as current
            Variables.CurrentUICulture = new SupportedUILanguage(defaultCulture);
        }

        /// <summary>
        /// Loads the currently supported UI languages
        /// </summary>
        private static void LoadSupportedUILanguages()
        {
            var supportedCultureList = new List<string> { "en", "pt-BR" };

            foreach (var supportedUILanguage in supportedCultureList.Select(supportedCulture => new CultureInfo(supportedCulture)).Select(culture => new SupportedUILanguage(culture)))
            {
                Variables.SupportedUILanguages.Add(supportedUILanguage);
            }
        }
    }
}
