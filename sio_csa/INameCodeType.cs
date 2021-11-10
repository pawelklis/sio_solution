using System;
using System.Collections.Generic;
using System.Text;

namespace sio_csa
{
    public interface INameCodeType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
