using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DajoChicking.Models
{
    public class ClockingObject
    {
        public string emp_id { get; set; }

        public string date { get; set; }

        public string in_time { get; set; }

        public string out_time { get; set; }

        public string in_location { get; set; }

        public string out_location { get; set; }

        public string in_confirmed { get; set; }

        public string out_confirmed { get; set; }
    }
}
