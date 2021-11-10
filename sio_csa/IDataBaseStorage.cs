using System;
using System.Collections.Generic;
using System.Text;

namespace sio_csa
{
    public interface IDataBaseStorage
    {

        
        public void Save();
        public static T Load<T>()
        {

            return (T)new object();
        }
        
        public void CreateTable()
        {
            MysqlCore.DB_Main().CreateTable(this, "sio_solution", "id", this.GetType().Name);            
        }

    }
}
