using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2
{
    //declare Activity types as enum
    public enum ActivityType { Air, Water, Land } 

    public class Activity: IComparable
    {
        //properties
        public string Name { get; set; }
        public DateTime ActivityDate { get; set; }
        public decimal Cost { get; set; }
        private string _Description;
        public string Description
        {
            get { return _Description
                         + $"  Cost - {Cost:C}"; }
            set { _Description = value; }
        }
        public ActivityType TypeOfActivity { get; set; }

        //constructors
        public Activity()  //base constructor
        {
        }

        public Activity(string name, object dt, object cst, string desc) 
        {
            
        }
        public Activity(string name) : this(name, null, null, "")  //chained constructor that takes name only
        {

        }

        public Activity(string name, DateTime date, decimal cost, string description)  //fully paramaterised constructor
        {
            this.Name = name;
            this.ActivityDate = date;
            this.Cost = cost;
            this.Description = description;
        }

        //method to compare list dates and order lists
        public int CompareTo(object obj) 
        {
            //get reference to next object in list
            Activity objectToCompareTo = obj as Activity;

            //compare to is set to compare the ActivityDate
            int returnValue = this.ActivityDate.CompareTo(objectToCompareTo.ActivityDate);
            return returnValue;
        }

        //override to return the name and date (short form) of the activity
        public override string ToString()   
        {
            return $"{Name} - {ActivityDate.ToShortDateString()}";
        }
    }
}
