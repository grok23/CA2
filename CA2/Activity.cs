using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2
{
    public enum ActivityType { Air, Water, Land } 

    class Activity
    {
        public string Name { get; set; }
        public DateTime ActivityDate { get; set; }
        public decimal Cost { get; set; }
        private string _Description;
        public string Description
        {
            get { return _Description + "Cost - {Cost}"; }
            set { _Description = value; }
        }
        public ActivityType TypeOfActivity { get; set; }


        }
}
