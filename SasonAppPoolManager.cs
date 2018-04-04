//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Configuration;
//using Antibiotic.Extensions;
//using Antibiotic.Database.Connectors;
//using Antibiotic.TableModels.TStructureModels.ServerTables;
//using Antibiotic.TableModels.TStructureModels.DatabaseTables;

//namespace SasonBase
//{
//    public static class SasonAppPoolManager
//    {
//        //public static DbConnector CreateEbaConnector(string server, string user, string userPass)
//        //{
//        //    return CreateEbaConnector(new TServerInfo(server), new TServerUserInfo(user, userPass));
//        //}

//        //public static DbConnector CreateEbaConnector(TServerInfo serverInfo, TServerUserInfo userInfo)
//        //{
//        //    DbConnector connector = new Antibiotic.Database.Connectors.Oracle.ODPConnector();
//        //    TDatabaseConnectionSettings connectionSettings = new TDatabaseConnectionSettings() { Server = serverInfo, User = userInfo };
//        //    connector.ConnectionSettings = connectionSettings;
//        //    return connector;
//        //}

//        //public static T CreateAppPool<T>(string server, string user, string pass) where T : SasonBaseApplicationPool
//        //{
//        //    DbConnector connector = new Antibiotic.Database.Connectors.Oracle.ODPConnector();
//        //    TDatabaseConnectionSettings connectionSettings = new TDatabaseConnectionSettings()
//        //    {
//        //        Server = new TServerInfo(server),
//        //        User = new TServerUserInfo(user, pass),
//        //    };
//        //    connector.ConnectionSettings = connectionSettings;
//        //    T appPool = typeof(T)._create<T>();
//        //    appPool.EbaTestConnector = connector;
//        //    return appPool;
//        //}

//        //public static T CreateAppPool<T>(string server, string user, string pass) where T : SasonBaseApplicationPool
//        //{
//        //    DbConnector connector = new Antibiotic.Database.Connectors.Oracle.ODPConnector();
//        //    TDatabaseConnectionSettings connectionSettings = new TDatabaseConnectionSettings()
//        //    {
//        //        Server = new TServerInfo(server),
//        //        User = new TServerUserInfo(user, pass),
//        //    };
//        //    connector.ConnectionSettings = connectionSettings;
//        //    T appPool = typeof(T)._create<T>();
//        //    appPool.EbaTestConnector = connector;
//        //    return appPool;
//        //}
//    }
//}