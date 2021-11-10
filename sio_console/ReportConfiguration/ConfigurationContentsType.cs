using System;

namespace sio_console
{
    public class ConfigurationContentsType: ITitleType
    {
        public string Id { get; set; }
        public IContentType.ContentTypes TypeofContent { get; set; }
        public object DefaultValue { get; set; }
        public int OrderNumber { get; set; }
        public int CategoryID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ConfigurationContentsType()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}