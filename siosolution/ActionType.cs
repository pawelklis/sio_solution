using System;
using System.Collections.Generic;
using System.Text;

namespace siosolution
{
    public class ActionType : DataBaseStorageHelper, INameCodeType, ITimeEvidenceType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
