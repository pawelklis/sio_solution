using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace sio_csa
{
    public class ReportConfigurationType :DataBaseStorageHelper, IDataBaseStorage
    {

        public int Id { get; set; }       
        public int SiteId { get; set; }
        public int ZoneId { get; set; }
        public List<ConfigurationContentsType> Contents { get; set; }



        /// <summary>
        /// Ta metoda Tworzy nowy raport
        /// </summary>
        /// <param name="idworkshift"></param>
        /// <param name="idzone"></param>
        /// <param name="idcreator"></param>
        /// <returns></returns>
        public ReportType CreateReport(
            int idworkshift,
            int idzone,
            int idcreator)
        {
            ReportType r = new ReportType
            {
                Configuration = this
            };
            r.CreateReport(idworkshift, idzone, idcreator);

            foreach (var c in this.Contents.OrderBy(x => x.OrderNumber))
            {               
                switch (c.TypeofContent)
                {                    
                    case IContentType.ContentTypes.text:
                        ContentTextType newcontent = new ContentTextType
                        {
                            ConfigurationId = c.Id,
                            IdReport = r.Id,
                            Types = c.TypeofContent,
                            Text = c.DefaultValue.ToString(),
                            Category =CategoryReportType.Load<CategoryReportType>( c.CategoryID),
                            Title=c.Title,
                            Description=c.Description 
                        };
                        r.Contents.Add(newcontent);

                        break;
                    case IContentType.ContentTypes.number:
                        ContentNumberType ncn = new ContentNumberType
                        {
                            ConfigurationId = c.Id,
                            IdReport = r.Id,
                            Types = c.TypeofContent,
                            Number = double.Parse(c.DefaultValue.ToString()),
                            Category = CategoryReportType.Load<CategoryReportType>(c.CategoryID),
                            Title = c.Title,
                            Description = c.Description
                        };
                        r.Contents.Add(ncn);

                        break;
                    case IContentType.ContentTypes.checkboxes:
                        ContentCheckBoxesType cnc = new ContentCheckBoxesType
                        {
                            ConfigurationId = c.Id,
                            IdReport = r.Id,
                            Types = c.TypeofContent,
                            Items = (Dictionary<string, bool>)c.DefaultValue,
                            Category = CategoryReportType.Load<CategoryReportType>(c.CategoryID),
                            Title = c.Title,
                            Description = c.Description
                        };
                        r.Contents.Add(cnc);

                        break;
                    case IContentType.ContentTypes.dropdownlist:
                        ContentDropDownType cnd = new ContentDropDownType
                        {
                            ConfigurationId = c.Id,
                            IdReport = r.Id,
                            Types = c.TypeofContent,
                            SelectedItemId = c.DefaultValue.ToString(),
                            Category = CategoryReportType.Load<CategoryReportType>(c.CategoryID),
                            Title = c.Title,
                            Description = c.Description
                        };
                        r.Contents.Add(cnd);

                        break;
                    case IContentType.ContentTypes.table:
                        ContentTableType cnt = new ContentTableType
                        {
                            ConfigurationId = c.Id,
                            IdReport = r.Id,
                            Types = c.TypeofContent,
                            Table = (DataTable)c.DefaultValue,
                            Category = CategoryReportType.Load<CategoryReportType>(c.CategoryID),
                            Title = c.Title,
                            Description = c.Description
                        };
                        r.Contents.Add(cnt);

                        break;
                    default:
                        break;
                }
            }

            r.SaveAsync();
            return r;
        }

        public ReportConfigurationType()
        {
            this.Contents = new List<ConfigurationContentsType>();
        }


    }
}