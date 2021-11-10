using System;
using System.Collections.Generic;
using System.Text;

namespace siosolution
{
    public class ContentCheckBoxesType:ContentType
    {
        public Dictionary<string,bool> Items { get; set; }


        public ContentCheckBoxesType()
        {
            Items = new Dictionary<string, bool>();
        }
    }
}
