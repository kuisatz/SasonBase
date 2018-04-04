using Antibiotic.Database.Connectors;
using Antibiotic.TableModels.TStructureModels.DatabaseTables;
using Antibiotic.TableModels.TStructureModels.ServerTables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasonBase
{
    public static class SasonConnectorManager
    {
        public static DbConnector CreateEbaConnector(string server, string user, string userPass)
        {
            return CreateEbaConnector(new TServerInfo(server), new TServerUserInfo(user, userPass));
        }

        public static DbConnector CreateEbaConnector(TServerInfo serverInfo, TServerUserInfo userInfo)
        {
            DbConnector connector = new Antibiotic.Database.Connectors.Oracle.ODPConnector();
            TDatabaseConnectionSettings connectionSettings = new TDatabaseConnectionSettings() { Server = serverInfo, User = userInfo };
            connector.ConnectionSettings = connectionSettings;
            return connector;
        }

        public static DbConnector CreateEbaConnectorFromConfiguration(Configuration config)
        {
            string serverName = GetServerName(config);
            string userName = GetUserName(config);
            string userPass = GetUserPassword(config);
            return CreateEbaConnector(serverName, userName, userPass);
        }




        public static string GetServerName(Configuration config)
        {
            return Antibiotic.Config.AppSetting.GetValue(config, "SasonBaseDbServerName");
        }

        public static string GetUserName(Configuration config)
        {
            return Antibiotic.Config.AppSetting.GetValue(config, "SasonBaseDbUserName");
        }

        public static string GetUserPassword(Configuration config)
        {
            return SasonUserPassword(Antibiotic.Config.AppSetting.GetValue(config, "SasonBaseDbUserPass"));
        }

        /// <summary>
        /// Debug or Release
        /// </summary>
        /// <returns></returns>
        public static string GetHostMode()
        {
            return Antibiotic.Config.AppSetting.GetValue(Antibiotic.Config.Configurations.FromFile(@"c:\eba.net\sasonbase.config"), "HostMode");
        }


        static String SasonUserPassword(string inConfigPass)
        {
            return Antibiotic.Helpers.Security.StringCipher.Decrypt(inConfigPass, "SasonBase");
        }

        public static String CreateCrString(string source)
        {
            return Antibiotic.Helpers.Security.StringCipher.Encrypt(source, "SasonBase");
        }

        //public static DbConnector CreateEbaConnectorFromMachineConfig()
        //{
        //    return CreateEbaConnectorFromConfiguration(Antibiotic.Config.Configurations.FromFile(ConfigurationManager.OpenMachineConfiguration().FilePath));
        //}

        /// <summary>
        /// c:\eba.net\sasonbase.config
        /// </summary>
        /// <returns></returns>
        public static DbConnector CreateEbaConnectorFromConfigFile(string configFilePath = @"c:\eba.net\sasonbase.config")
        {
            return CreateEbaConnectorFromConfiguration(Antibiotic.Config.Configurations.FromFile(configFilePath));
        }
    }
}