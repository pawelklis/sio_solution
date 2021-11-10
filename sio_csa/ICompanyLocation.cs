using System;
using System.Collections.Generic;
using System.Text;

namespace sio_csa
{
    public    interface ICompanyLocation
    {
        public int OrganizationUnitID { get; set; }
        public int ZoneID { get; set; }
    }
}
