using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SpreadsheetAPI.Configuration
{
    public class ApplicationSection : ConfigurationSection
    {
        [ConfigurationProperty(nameof(DatabaseSettings), IsRequired = true)]
        public DatabaseSettingsElement DatabaseSettings
        {
            get => (DatabaseSettingsElement)this[nameof(DatabaseSettings)];
            set => this[nameof(DatabaseSettings)] = value;
        }

        public static ApplicationSection GetApplicationSettings(string sectionName = "ApplicationSettings")
        {
            return (ApplicationSection)ConfigurationManager.GetSection(sectionName);
        }
    }
}