using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DajoChicking
{
    public class Person
    {
        public string Person_Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string ID { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Status { get; set; }

        public string Role { get; set; }

        public string Job_Title { get; set; }

        public string Image { get; set; }

        public Person()
        {

        }

        public Person(string Email, string Password)
        {
            this.Email = Email;
            this.Password = Password;
        }
    }
}
