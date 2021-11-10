using System;
using System.Collections.Generic;
using System.Text;

namespace siosolution
{
    public class ConfigType: DataBaseStorageHelper, IDataBaseStorage
    {
        public int Id { get; set; }
        public ConfigParameters Parameter { get; set; }
        public string Val { get; set; }


        public static ConfigType Load(ConfigParameters parameter)
        {
            ConfigType o= MysqlCore.DB_Main().NewGetSingleObject<ConfigType>("select * from configs where parameter=" + parameter);
            if (o == null)
            {
                o = new ConfigType();
                o.Parameter = parameter;
                o.Val = "";
                o.Save();
            }
            return o;
        }


        public enum ConfigParameters
        {
            ReportAttachmentsPath
        }


    }
}
