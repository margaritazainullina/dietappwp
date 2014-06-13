using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Collections.Generic;


namespace DietApp_
{
    [Table]
    public class Schedule
    {
        [Column(DbType = "INT NOT NULL IDENTITY", IsDbGenerated = true,
            IsPrimaryKey = true, AutoSync = AutoSync.OnInsert)]
        public int ScheduleID
        {
            get;
            set;
        }
        [Column(CanBeNull = false)]
        public string Time
        {
            get;
            set;
        }
        [Column(CanBeNull = false)]
        public int DayWeek
        {
            get;
            set;
        }
        [Column(CanBeNull = false)]
        public int Duration
        {
            get;
            set;
        }
        [Column(CanBeNull = false)]
        public int AId
        {
            get;
            set;
        }
        public EntityRef<Action> action;
        [Association(ThisKey = "AId", OtherKey = "ActionID", Storage = "action", IsForeignKey = true)]
        public Action Action
        {
            get { return action.Entity; }
            set { action.Entity = value; }
        }
    }
}
