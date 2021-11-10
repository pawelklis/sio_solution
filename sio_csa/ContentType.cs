using System;
using System.Collections.Generic;

namespace sio_csa
{
    public class ContentType :  IContentType, ITitleType
    {
        public string Id { get ; set ; }
        public string ConfigurationId { get; set; }
        public int IdReport { get ; set ; }
        public DateTime CreateTime { get ; set ; }
        public List<ModifiedItemType> Modifieds { get ; set ; }
        public IContentType.ContentTypes Types { get ; set ; }
        public string Title { get; set; }
        public string Description { get; set; }
        public CategoryReportType Category { get; set; }

        public ContentType()
        {
            this.CreateTime = DateTime.Now;
            this.Id = Guid.NewGuid().ToString();
            this.Modifieds = new List<ModifiedItemType>();
            
        }

    }
}