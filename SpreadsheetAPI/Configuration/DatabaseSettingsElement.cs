using DevExpress.Xpo.DB;
using Persistant.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;

namespace SpreadsheetAPI.Configuration
{
    public class DatabaseSettingsElement : ConfigurationElement, IDataStoreSettings
    {
        [ConfigurationProperty(nameof(ConnectionString), IsRequired = true)]
        public string ConnectionString
        {
            get => (string)this[nameof(ConnectionString)];
            set => this[nameof(ConnectionString)] = value;
        }

        [ConfigurationProperty(nameof(CreateOption), DefaultValue = "SchemaAlreadyExists")]
        [RegexStringValidator("^DatabaseAndSchema|SchemaOnly|None|SchemaAlreadyExists$")]
        public string CreateOption
        {
            get => (string)this[nameof(CreateOption)];
            set => this[nameof(CreateOption)] = value;
        }

        [ConfigurationProperty(nameof(Assembly), IsRequired = true)]
        public string Assembly
        {
            get => (string)this[nameof(Assembly)];
            set => this[nameof(Assembly)] = value;
        }

        AutoCreateOption IDataStoreSettings.CreateOption => (AutoCreateOption)Enum.Parse(typeof(AutoCreateOption), CreateOption);

        Assembly IDataStoreSettings.AssemblyWithEntities => System.Reflection.Assembly.Load(Assembly);
    }
}