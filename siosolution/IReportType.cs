using System;
using System.Collections.Generic;
using System.Text;

namespace siosolution
{
    public interface IReportType: IDataBaseStorage
    {
        public int Id { get;  }
        public string ReportNumber { get; }
        public int IdWorkShift { get; }
        public List<ContentType> Contents { get;  }
        public List<AttachmentType> Attachments { get; set; }
        public UserType Creator { get;  }
        public DateTime CreateTime { get;  }
        public DateTime CloseTime { get;  }

        public ReportConfigurationType Configuration { get; set; }


        public void CreateReport(
            int idworkshift,
            int idzone,
            int idcreator
            );
        public void CloseReport();


    }
}
