using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace siosolution
{
    public class ShiftType:DataBaseStorageHelper, IDataBaseStorage, ICompanyLocation, INameCodeType
    {       
        public int Id { get; set; }
        [DisplayName("Czas rozpoczęcia")]
        public DateTime StartTime { get; set; }
        [DisplayName("Czas zakończenia")]
        public DateTime EndTime { get; set; }
        [DisplayName("ID jednostki")]
        public int OrganizationUnitID { get; set; }
        [DisplayName("ID strefy")]
        public int ZoneID { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [DisplayName("Kod")]
        public string Code { get; set; }

        public void CreateTable()
        {
           
        }
    }
}