using System;
using System.Collections.Generic;
using System.Text;

namespace sio_console
{
    public class OrganizationUnitType: DataBaseStorageHelper, IGeolocationType, INameCodeType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public AddressType Address { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }

    }
}
