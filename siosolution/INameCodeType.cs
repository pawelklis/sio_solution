﻿using System;
using System.Collections.Generic;
using System.Text;

namespace siosolution
{
    public interface INameCodeType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
