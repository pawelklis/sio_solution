using System;
using System.Collections.Generic;
using System.Text;

namespace sio_csa
{
    public interface IAddressType
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Local { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }


    }
}
