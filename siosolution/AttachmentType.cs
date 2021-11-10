using System;

namespace siosolution
{
    public class AttachmentType
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
        public string Path { get; set; }

        public AttachmentType()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}