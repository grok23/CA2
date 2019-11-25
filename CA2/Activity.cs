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


        //method to compare list dates and order lists
        public int CompareTo(object obj) 
        {
            //get reference to next object in list
            Activity objectToCompareTo = obj as Activity;

            //compare to is set to compare the ActivityDate
            int returnValue = this.ActivityDate.CompareTo(objectToCompareTo.ActivityDate);
            return returnValue;
        }

        public override string ToString()
        {
            return $"{Name} - {ActivityDate.ToShortDateString()}";
        }

    }
}
