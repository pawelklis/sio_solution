using System;
using System.Collections.Generic;
using System.Text;

namespace sio_csa
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
