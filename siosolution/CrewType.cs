using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace siosolution
{
    public class CrewType
    {
        public int Id { get; private set; }
        private List<CrewItemType> Items { get; set; }

        public CrewType()
        {
            this.Items = new List<CrewItemType>();
        }

        public void GetItems(DateTime startdate, DateTime enddate)
        {
            List<CrewItemType> l = CrewItemType.LoadWhere<CrewItemType>("workstarttime like'" + startdate.ToShortDateString() +"%'");
            Items = new List<CrewItemType>();
            foreach(var o in l)
            {
                if (o.IsWorkingBetweenDates(startdate, enddate))
                    Items.Add(o);
            }
        }

        public void ImportExcelCSIP(string path)
        {
            string csvPAth = FileOperations.SaveExceltoCSV(path);
            DataTable dt = FileOperations.csvToDatatable(csvPAth, '^', -1, 0);
            Items = new List<CrewItemType>();

            List<ZoneType> zones = ZoneType.LoadAll<ZoneType>();
            List<WorkTypeType> works = WorkTypeType.LoadAll<WorkTypeType>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string zonename = dt.Rows[i][0].ToString();
                string employeenumber = dt.Rows[i][1].ToString();
                string employeefullname = dt.Rows[i][2].ToString();
                string data = dt.Rows[i][3].ToString();
                string starttime = dt.Rows[i][4].ToString();
                string stoptime = dt.Rows[i][5].ToString();
                string workcode = dt.Rows[i][6].ToString();

                ZoneType zone = zones.Find(x => x.Name == zonename);
                EmployeeType employee = EmployeeType.GetOrCreateEmployee(employeefullname, employeenumber);
                WorkTypeType workType = works.Find(x => x.Code == workcode);

                if (workType == null)
                {
                    workType = new WorkTypeType();
                    workType.Code = workcode;
                    workType.Name = "Do uzupełnienia";
                    workType.Save();
                    works = WorkTypeType.LoadAll<WorkTypeType>();
                }

                if (zone == null)
                {
                    zone = new ZoneType();
                    zone.Name = zonename;
                    zone.Code = zone.Name.Substring(0, 3);
                    zone.Save();
                    zones = ZoneType.LoadAll<ZoneType>();
                }


                DateTime ST=DateTime.Parse("0001-01-01 00:00");
                DateTime ET=ST;

                bool ok1 = false;
                bool ok2 = false;
                if (string.IsNullOrEmpty(starttime))
                {
                    ok1 = true;
                    ST = DateTime.Parse(data);
                }
                if (string.IsNullOrEmpty(stoptime))
                {
                    ok2 = true;
                    ET = DateTime.Parse(data);
                }

                if (ok1 == false)
                {
                    if (starttime.Contains(","))
                    {
                        ok1 = true;
                        ST = DateTime.Parse(data + " " + starttime.Split(',')[0] + ":" + 60 * (double.Parse(starttime) % 1));
                    }
                }
                if (ok1 == false)
                {
                    if (!starttime.Contains(","))
                    {
                        ok1 = true;
                        ST = DateTime.Parse(data + " " + starttime + ":00");
                    }
                }

                if (ok2 == false)
                {
                    if (stoptime.Contains(","))
                    {
                        ok2 = true;
                        double wt =(Math.Round(double.Parse(stoptime),0)*60) + ( 60 * (double.Parse(stoptime) % 1));
                        ET = ST.AddMinutes(wt);
                    }
                }
                if (ok2 == false)
                {
                    if (!stoptime.Contains(","))
                    {
                        ok2 = true;
                        double wt = double.Parse(stoptime);
                        ET = ST.AddMinutes(wt * 60); 
                    }
                }

                CrewItemType item = new CrewItemType(employee.Id);
                item.PlanWorkStart = ST;
                item.PlanWorkEnd = ET;
                item.PlanWorkTypeId = workType.Id;
                item.ZoneID = zone.Id;

                item.SetWorkStartTime(item.PlanWorkStart);
                item.SetWorkEndTime(item.PlanWorkEnd);
                item.SetWorktypeID(item.PlanWorkTypeId, works);

                Items.Add(item);
            }


            MysqlCore.DB_Main().NewInsertList<CrewItemType>(Items);
        }

        public CrewItemType Item(int EmployeeID)
        {
            return Items.Find(x => x.EmployeeId == EmployeeID);
        }
        public List<CrewItemType> Employees()
        {
            return Items;
        }
        public void AddEmployee(int EmployeeID)
        {
            CrewItemType item = new CrewItemType(EmployeeID);
            this.Items.Add(item);
        }



    }
}
