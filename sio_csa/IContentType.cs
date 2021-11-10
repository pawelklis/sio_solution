using System;
using System.Collections.Generic;
using System.Text;

namespace sio_csa
{
    public interface IContentType
    {

        public string Id { get; set; }
        public int IdReport { get; set; }
        public DateTime CreateTime { get; set; }
        public List<ModifiedItemType> Modifieds { get; set;}
        public ContentTypes Types { get; set; }

        public enum ContentTypes
        {
            text,
            number,
            checkboxes,
            dropdownlist,
            table
        }

    }
}
