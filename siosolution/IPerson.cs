﻿using System;
using System.Collections.Generic;
using System.Text;

namespace siosolution
{
    public interface IPerson
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreateTime { get; set; }

        public string NameSurname();
    }
}
