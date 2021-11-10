using System;
using System.Collections.Generic;
using System.Text;

namespace sio_csa
{
    public class DataBaseStorageHelper
    {
        public void Save()
        {
            string tb = this.ToString().Replace("sio_csa.", "").Replace("Type", "s");
            MysqlCore.DB_Main().NewInsertOrUpdate(this, tb);
        }
        public static void CreateTable(object ExampleObject)
        {
            string tb = ExampleObject.ToString().Replace("sio_csa.", "").Replace("Type", "s");
            MysqlCore.DB_Main().CreateTable(ExampleObject, "sio_solution", "id", tb);
        }
      
        public static T Load<T>(int objectID) where T : new()
        {
            string tb = typeof(T).ToString().Replace("sio_csa.", "").Replace("Type", "s");
            return MysqlCore.DB_Main().NewGetSingleObject<T>("Select * from `" + tb + "` where id=" + objectID);
        }

        public static List<T> LoadAll<T>() where T : new()
        {
          
            string tb = typeof(T).ToString().Replace("sio_csa.", "").Replace("Type", "s");
            return MysqlCore.DB_Main().NewGetObjects<T>("Select * from `" + tb + "`;");
        }
        public static List<T> LoadWhere<T>(string where) where T : new()
        {

            string tb = typeof(T).ToString().Replace("sio_csa.", "").Replace("Type", "s");
            return MysqlCore.DB_Main().NewGetObjects<T>("Select * from `" + tb + "` WHERE " + where + ";");
        }
    }
}
