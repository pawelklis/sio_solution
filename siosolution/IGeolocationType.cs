using System;
using System.Collections.Generic;
using System.Text;

namespace siosolution
{
    public interface IGeolocationType
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
