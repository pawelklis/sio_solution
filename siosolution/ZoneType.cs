using System;
using System.Collections.Generic;
using System.Text;

namespace siosolution
{
    public class ZoneType : DataBaseStorageHelper, INameCodeType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
