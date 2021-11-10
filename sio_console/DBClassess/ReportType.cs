using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace sio_console
{
    public class ReportType :DataBaseStorageHelper, IReportType, IReportCrewType, ICompanyLocation
    {
        public int Id { get; private set; }
        public string ReportNumber { get;private set; }
        public int OrganizationUnitID { get; set; }
        public int ZoneID { get; set; }
        public int IdWorkShift { get;private set; }
        public List<ContentType> Contents { get;private set; }
        public List<AttachmentType> Attachments { get; set; }
        public UserType Creator { get; set; }
        public DateTime CreateTime { get;private set; }
        public DateTime CloseTime { get;private set; }
        public ReportConfigurationType Configuration { get; set; }
        public CrewType Crew { get; set; }
        

        public ReportType()
        {
            Contents = new List<ContentType>();
        }

        public void SaveAsync()
        {
            Task.Run(new Action( ()=>this.Save()));
        }

        public void CloseReport()
        {
            this.CloseTime = DateTime.Now;
        }

        public ZoneType zone()
        {
            return ZoneType.Load<ZoneType>(this.ZoneID);
        }
        public WorkTypeType workshift()
        {
            return WorkTypeType.Load<WorkTypeType>(this.IdWorkShift);
        }
        /// <summary>
        /// Ta metoda jest wywoływana z ReportConfigurationType.CreateReport, Nie używać jej nigdzie indziej
        /// </summary>
        /// <param name="idworkshift"></param>
        /// <param name="idzone"></param>
        /// <param name="idcreator"></param>
        /// <param name="idconfiguration"></param>
        public void CreateReport(
            int idworkshift,
            int idzone,
            int idcreator            
            )
        {


            this.CreateTime = DateTime.Now;
            this.Attachments = new List<AttachmentType>();
         
            this.ZoneID = idzone;
            this.IdWorkShift = idworkshift;
          
            this.Creator = UserType.Load<UserType>(idcreator);

            this.Crew = new CrewType();

            int rc = MysqlCore.DB_Main().GetCount("select count(*) from reports where zoneid=" + this.ZoneID + " and createtime like'" + this.CreateTime.Year + "-" + this.CreateTime.Month + "%';");
            this.ReportNumber = rc + 1 + "/" + this.CreateTime.Month + "/" + this.CreateTime.Year + "/" + this.zone().Code + "/" + this.workshift().Code;
            SaveAsync();
        }


        public void AddAtachment(string path,string name,string description)
        {
            if (System.IO.File.Exists(path))
            {
                string destinationPath = ConfigType.Load(ConfigType.ConfigParameters.ReportAttachmentsPath).Val + System.IO.Path.GetFileName(path);
                
                System.IO.File.Copy(path,destinationPath );
                AttachmentType a = new AttachmentType();
                a.Path = destinationPath;
                a.Name = name;
                a.Description = description;
                this.Attachments.Add(a);
                SaveAsync();
            }
        }
        public void EditContent(string ContentID, object value,int UserId, string checkboxesitemid = null)
        {
            ContentType o=null;
          foreach(var c in this.Contents)
            {
                if (c.Id == ContentID)
                    o = c;
            }

            o.Modifieds.Add(new ModifiedItemType { IdModifierUser =UserId, ModifiedTime = DateTime.Now });
            SetValue(o, value,checkboxesitemid);

            SaveAsync();
        }


        private ContentType SetValue(ContentType o,object value,string checkboxesitemid=null,int rowindex=-1,int columnindex=-1)
        {
            switch (o.Types)
            {
                case IContentType.ContentTypes.text:
                    ContentTextType c= (ContentTextType)o;
                    c.Text = (string)value;
                    SaveAsync();
                    return c;
                    

                case IContentType.ContentTypes.number:
                    ContentNumberType n = (ContentNumberType)o;
                    n.Number = double.Parse(value.ToString());
                    SaveAsync();
                    return (ContentNumberType)o;
                    

                case IContentType.ContentTypes.checkboxes:
                    ContentCheckBoxesType cb = (ContentCheckBoxesType)o;
                    cb.Items[checkboxesitemid] = (bool)value;
                    SaveAsync();
                    return (ContentCheckBoxesType)o;
                    

                case IContentType.ContentTypes.dropdownlist:
                    ContentDropDownType cd = (ContentDropDownType)o;
                    cd.SelectedItemId = (string)value;
                    SaveAsync();
                    return (ContentDropDownType)o;

                case IContentType.ContentTypes.table:
                    ContentTableType cdt = (ContentTableType)o;
                    cdt.EditCell(rowindex, columnindex, value);
                    SaveAsync();
                    return (ContentTableType)o;
                    
            }

            return o;
        }

        public void AddContent(IContentType.ContentTypes contenttypes)
        {
            ContentType o=new ContentType();
            switch (contenttypes)
            {
                case IContentType.ContentTypes.text:
                    o = new ContentTextType();

                    break;

                case IContentType.ContentTypes.number:
                    o = new ContentNumberType();
                    break;

                case IContentType.ContentTypes.checkboxes:
                    o = new ContentCheckBoxesType();
                    break;

                case IContentType.ContentTypes.dropdownlist:
                    o = new ContentDropDownType();
                    break;

                case IContentType.ContentTypes.table:
                    o = new ContentTableType();
                    break;
            }

            o.IdReport = this.Id;
            o.Types = contenttypes;

            this.Contents.Add(o);
            SaveAsync();

        }



    

  
    }
}
