using System;
using System.ComponentModel.DataAnnotations;

namespace sio_console
{
    public class ShiftType:DataBaseStorageHelper, IDataBaseStorage, ICompanyLocation, INameCodeType
    {       
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int OrganizationUnitID { get; set; }
        public int ZoneID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}