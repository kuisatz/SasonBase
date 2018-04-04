using Antibiotic.Database.Connectors;
using Antibiotic.Database.Table;
using Antibiotic.Extensions;
using Antibiotic.TableModels.TStructureModels.DatabaseTables;
using Antibiotic.TableModels.TStructureModels.ServerTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SasonBase
{
    public class SasonBaseApplicationPool : Antibiotic.App.ApplicationPool
    {
        #region Get
        public new static SasonBaseApplicationPool Get
        {
            get { return R.AppPool as SasonBaseApplicationPool; }
        } 
        #endregion

        #region [public] property (DbConnector): EbaTestConnector
        /// <summary>
        /// açıklama yok (DbConnector)
        /// </summary>
        public DbConnector EbaTestConnector
        {
            get { return Connectors.GetConnector("EbaTestConnector"); }
            set { Connectors.SetConnector("EbaTestConnector", value); }
        }
        #endregion

        #region InitItemConnector
        public override void InitItemConnector(Type itemTableType, Type baseTableInheritedType, DbTableInfoAttribute tableInfo)
        {
            //string schemaName = EbaTestConnector.ConnectionSettings.User.SF_UserName;
            switch (tableInfo.Group)
            {
                case "Antibiotic.Tables":
                    SetItemConnector(itemTableType, EbaTestConnector);
                    break;
                case "":
                    {
                        SetItemConnector(itemTableType, EbaTestConnector);
                    }
                    break;
                case "Eba":
                    SetItemConnector(itemTableType, EbaTestConnector);
                    break;
                case "EbaTest.Tables":
                    SetItemConnector(itemTableType, EbaTestConnector);
                    break;
                case "Sason":
                case "Sason.Tables":
                    SetItemConnector(itemTableType, EbaTestConnector, "SASON");
                    break;
                default:
                    {
                        throw new Exception("Yok");
                    }
            }
        }
        #endregion

        #region Create
        /// <summary>
        /// Web Tarafından Kullanılmak İçin Hazırlandı (SASON Gerçek Bağlantı Bilgileri)
        /// </summary>
        public static SasonBaseApplicationPool Create
        {
            get
            {
                //return CreateSasonAppPool<SasonBaseApplicationPool>();
                SasonBaseApplicationPool appPool = new SasonBaseApplicationPool();
                appPool.EbaTestConnector = SasonBase.SasonConnectorManager.CreateEbaConnectorFromConfigFile();
                return appPool;
            }
        }

        public static AppPoolMask<SasonBaseApplicationPool> CreateMask
        {
            get
            {
                AppPoolMask<SasonBaseApplicationPool> ret = new AppPoolMask<SasonBaseApplicationPool>();
                if (ret.Custom)
                    ret.AppPool = Create;
                return ret;
            }
        }

        public static string ServerName
        {
            get {
                string configFilePath = @"c:\eba.net\sasonbase.config";
                return SasonBase.SasonConnectorManager.GetServerName(Antibiotic.Config.Configurations.FromFile(configFilePath));
            }
        }

        public static string UserName
        {
            get
            {
                string configFilePath = @"c:\eba.net\sasonbase.config";
                return SasonBase.SasonConnectorManager.GetUserName(Antibiotic.Config.Configurations.FromFile(configFilePath));
            }
        }

        public static string UserPassword
        {
            get
            {
                string configFilePath = @"c:\eba.net\sasonbase.config";
                return SasonBase.SasonConnectorManager.GetUserPassword(Antibiotic.Config.Configurations.FromFile(configFilePath));
            }
        }


        public static SasonBaseApplicationPool CreateCustom(string server, string user, string pass)
        {
            SasonBaseApplicationPool appPool = new SasonBaseApplicationPool();
            appPool.EbaTestConnector = SasonBase.SasonConnectorManager.CreateEbaConnector(server, user, pass);
            return appPool;
        }
        #endregion


        public static T CreateSasonAppPool<T>(string configFilePath = @"c:\eba.net\sasonbase.config") where T:SasonBaseApplicationPool
        {
            T appPool = typeof(T)._create<T>();
            appPool.EbaTestConnector = SasonBase.SasonConnectorManager.CreateEbaConnectorFromConfigFile(configFilePath);
            return appPool;
        }

        

    }
}