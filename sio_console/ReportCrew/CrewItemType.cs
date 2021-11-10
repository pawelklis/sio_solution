using System;
using System.Collections.Generic;
using System.Text;

namespace sio_console
{
    public class CrewItemType:DataBaseStorageHelper, IDataBaseStorage
    {
        public int Id { get; private set; }
        public DateTime PlanWorkStart { get; set; }
        public DateTime PlanWorkEnd { get; set; }
        public int PlanWorkTypeId { get; set; }
        public DateTime WorkStartTime { get;private  set; }
        public DateTime WorkEndTime { get;private  set; }
        public int EmployeeId { get; private set; }
        public int WorkTypeId { get;private set; }
        public int ZoneID { get; set; }
        public List<ActionType> Actions { get; set; }



        public void SetWorktypeID(int worktypeid,List<WorkTypeType>l=null)
        {
            WorkTypeType wt = null;
            if (l == null)
                wt = WorkTypeType.Load<WorkTypeType>(worktypeid);
            else
                wt = l.Find(x => x.Id == worktypeid);

            if (wt.Present == 0)
            {
                this.WorkStartTime =DateTime.Parse( this.WorkStartTime.ToShortDateString() + " 00:00:00");
                this.WorkEndTime= DateTime.Parse(this.WorkEndTime.ToShortDateString() + " 00:00:00");
            }
        }
        public TimeSpan WorkTime()
        {
            return WorkEndTime - WorkStartTime;
        }

        public bool IsPresent(List<WorkTypeType> l = null)
        {
            WorkTypeType wt = null;
            if (l == null)
                wt = WorkTypeType.Load<WorkTypeType>(this.WorkTypeId);
            else
                wt = l.Find(x => x.Id == this.WorkTypeId);

            if (wt.Present == 1)
                return true;

            return false;
        }
        public void AddAction(int actionID, DateTime ActionStartTime)
        {
            ActionType a = ActionType.Load<ActionType>(actionID);
            if (a != null)
            {
                a.StartTime = ActionStartTime;
                a.CreateTime = DateTime.Now;            
                this.Actions.Add(a);
            }

        }
        public void EndAction(int actionID, DateTime ActionEndTime)
        {
            this.Actions.Find(x => x.Id == actionID).EndTime = ActionEndTime;
        }
        public void SetWorkStartTime(DateTime WorkStart)
        {
            this.WorkStartTime = WorkStart;
        }
        public void SetWorkEndTime(DateTime WorkStart)
        {
            this.WorkStartTime = WorkStart;
        }





        public CrewItemType(int EmployeeID)
        {
            
            this.EmployeeId = EmployeeID;
            this.Actions = new List<ActionType>();
        }

        public CrewItemType() { }


        public WorkTypeType WorkType()
        {
            return WorkTypeType.Load<WorkTypeType>(this.WorkTypeId);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }


        public bool IsWorkingBetweenDates(DateTime starttime,DateTime endtime)
        {
            if (this.WorkStartTime < starttime && this.WorkEndTime > starttime)
                return true;
      
      
            if (this.WorkStartTime < endtime && this.WorkStartTime >= starttime )
                return true;


            if (this.WorkStartTime >= starttime && this.WorkEndTime < endtime )
                return true;

            return false;
        }
    }
}
