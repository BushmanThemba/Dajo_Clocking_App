using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DajoChicking.Models
{
    class Timesheet 
    {
        public string Fk_Employee_Id { get; set; }

        public string Date { get; set; }

        public string Start_Time { get; set; }

        public string End_Time { get; set; }

        public string Activity { get; set; }

        public string Location { get; set; }

        public string Confirmation { get; set; }
    }
}
