using System;
using System.Collections.Generic;
using System.Text;

namespace sio_console
{
    public class DelegationType: DataBaseStorageHelper, ITimeEvidenceType
    {
        public int Id { get; set; }
        public int FromZoneID { get; set; }
        public int ToZoneID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
