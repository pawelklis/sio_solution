using System;
using System.Data;

namespace sio_csa
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ConfigType.CreateTable(new ConfigType());
            //ActionType.CreateTable(new ActionType());
            //CategoryReportType.CreateTable(new CategoryReportType());
            DelegationType.CreateTable(new DelegationType());
            //EmployeeType.CreateTable(new EmployeeType());
            OrganizationUnitType.CreateTable(new OrganizationUnitType());
            ReportType.CreateTable(new ReportType());
            ShiftType.CreateTable(new ShiftType());
            UserType.CreateTable(new UserType());
            //WorkTypeType.CreateTable(new WorkTypeType());
            //ZoneType.CreateTable(new ZoneType());
            
            //CrewItemType.CreateTable(oc);
            

            ReportConfigurationType rt = new ReportConfigurationType();
            rt.SiteId = 1;
            rt.ZoneId = 1;
            rt.Contents.Add(new ConfigurationContentsType() { CategoryID = 1, DefaultValue = "", OrderNumber = 1, TypeofContent = IContentType.ContentTypes.text, Title="Pole tekstowe 1", Description="Wpisz co chcesz" });

            ReportConfigurationType.CreateTable(rt);
            rt.Save();

            var t = rt.CreateReport(1, 1, 1);

            CrewType cr = new CrewType();
            cr.GetItems(DateTime.Parse("2021-04-07 07:00:00"), DateTime.Parse("2021-04-07 15:00:00"));

            cr.ImportExcelCSIP(@"C:\Users\klispawel\Downloads\hk.xlsx");


            UserType u = new UserType(){ Name = "Paweł", Surname = "Klis", BirthDate = DateTime.Parse("1988-06-04"), CreateTime = DateTime.Now, Login = "klispawel" };
            UserType.CreateTable(u);
            u.Save();
            u = UserType.Load<UserType>(u.Id);

            EmployeeType e = new EmployeeType() { Name = "Paweł", Surname = "Klis", CreateTime = DateTime.Now, BirthDate = DateTime.Parse("1988-06-04"), Address = new AddressType() { City = "Stróża", Street = "Kolejowa", HouseNumber = "10", Country = "Polska", PostCode = "55-081" } };
            EmployeeType.CreateTable(e);
            e.Save();
            e = EmployeeType.Load<EmployeeType>(e.Id);


            ReportConfigurationType RC = new ReportConfigurationType
            {
                Id = 0,
                ZoneId = 0,
                SiteId = 0
            };
            RC.Contents.Add(new ConfigurationContentsType() { TypeofContent = IContentType.ContentTypes.table, DefaultValue = new DataTable(), OrderNumber = 0 });
            RC.Contents.Add(new ConfigurationContentsType() { TypeofContent = IContentType.ContentTypes.text, DefaultValue = "Test 1", OrderNumber = 1 });

            


            ReportType newReport = RC.CreateReport(1,2,3);
            newReport.Crew.AddEmployee(0);
            newReport.Crew.Item(0).SetWorkStartTime(DateTime.Now);
            newReport.Crew.Item(0).AddAction(1, DateTime.Now);


            DelegationType d = new DelegationType();
            DelegationType.CreateTable(new DelegationType());



            ReportType o = ReportType.Load<ReportType>(1);

            o.CreateReport(1,1,1);
            o.CloseReport();

MysqlCore.DB_Main().CreateTable(o, "sio_solution", "id", "testrc");
            MysqlCore.DB_Main().NewInsert(o, "testrc");
            

            o.AddContent(IContentType.ContentTypes.text);

            MysqlCore.DB_Main().NewUpdate(o, "testrc");


            ReportType ino = MysqlCore.DB_Main().NewGetSingleObject<ReportType>("select * from testrc where id=1");

            o.EditContent(o.Contents[0].Id, "nowa wartość", 0);

            o.AddContent(IContentType.ContentTypes.checkboxes);
            ContentCheckBoxesType co =(ContentCheckBoxesType)o.Contents[1];
            co.Items.Add("Wartość 1", false);
            co.Items.Add("Wartość 2", false);
            o.EditContent(co.Id, true, 0, "Wartość 2");
           

            o.AddContent(IContentType.ContentTypes.number);
            o.EditContent(o.Contents[2].Id, 199, 0);

            o.AddContent(IContentType.ContentTypes.dropdownlist);
            o.EditContent(o.Contents[3].Id, "123-456-789", 0);

            o.AddContent(IContentType.ContentTypes.table);
            ContentTableType ct = (ContentTableType)o.Contents[3];
            ct.Table = new System.Data.DataTable();
            ct.Table.Columns.Add("col1");
            ct.Table.Columns.Add("col2");
            ct.Table.Rows.Add("0", "0");
            ct.EditCell(0, 1, 9);

            
            

            Console.ReadKey();
        }
    }
}
