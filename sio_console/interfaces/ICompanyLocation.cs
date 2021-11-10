using System;
using System.Collections.Generic;
using System.Text;

namespace sio_console
{
    public    interface ICompanyLocation
    {
        public int OrganizationUnitID { get; set; }
        public int ZoneID { get; set; }
    }
}
