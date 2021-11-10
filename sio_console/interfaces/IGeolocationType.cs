using System;
using System.Collections.Generic;
using System.Text;

namespace sio_console
{
    public interface IGeolocationType
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}
