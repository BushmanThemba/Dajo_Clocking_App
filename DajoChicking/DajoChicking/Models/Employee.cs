using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DajoChicking.Models
{

    public class Employee
    {
        public string emp_id { get; set; }

        public string name { get; set; }

        public string surname { get; set; }

        public string phone { get; set; }

        public string email { get; set; }

        public string job_title { get; set; }

        public string image { get; set; }

        public string password { get; set; }

        public string role { get; set; }      

        public Employee()
        {

        }

        public Employee(string Email, string Password)
        {
            this.email = Email;
            this.password = Password;
        }

        public Employee(string emp_id, string name, string surname, string phone,  
                        string Email, string job_title, string image, string Password, string role)
        {
            this.emp_id = emp_id;
            this.name = name;
            this.surname = surname;
            this.phone = phone;
            this.email = Email;
            this.job_title = job_title;
            this.image = image;
            this.password = Password;
            this.role = role;
        }
    }
}
