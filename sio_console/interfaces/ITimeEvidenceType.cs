using System;
using System.Collections.Generic;
using System.Text;

namespace sio_console
{
    public interface ITimeEvidenceType
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreateTime { get; set; }

        public TimeSpan WorkTime()
        {
            return EndTime - StartTime;
        }
    }
}
