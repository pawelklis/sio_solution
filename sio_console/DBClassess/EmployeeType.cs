using System;
using System.Collections.Generic;
using System.Text;

namespace sio_console
{
    public class EmployeeType : DataBaseStorageHelper, IPerson
    {
        public int Id { get; set; }
        public string Name { get ; set ; }
        public string Surname { get ; set ; }
        public DateTime BirthDate { get ; set ; }
        public DateTime CreateTime { get ; set ; }
        public string Code { get; set; }
     
        public AddressType Address { get; set; }

        public EmployeeType()
        {
            this.Address = new AddressType();
        }

        public string NameSurname()
        {
            throw new NotImplementedException();
        }


        public static EmployeeType GetOrCreateEmployee(string namesurname, string employeecode) 
        {
            EmployeeType o = MysqlCore.DB_Main().NewGetSingleObject<EmployeeType>("select * from employees where code='" + employeecode + "';");

            if (o == null)
            {
                string[] n = namesurname.Split(' ');
                o = new EmployeeType();
                o.Name = n?[0];
                o.Surname = n?[1];
                o.Code = employeecode;
                o.Save();
            }



            return o;
        }
    }
}
