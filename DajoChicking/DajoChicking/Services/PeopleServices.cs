using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DajoChicking.Services
{
    public class PeopleServices
    {
        public List<Person>getPeople()
        {
            var list = new List<Person>
            {
                 new Person {
                    Name = "Patrick",
                    Surname = "Mthombeni",
                    ID = "93697845263",
                    Status = "Clocked In"
                },

                new Person {
                    Name = "Themba",
                    Surname = "sibiya",
                    ID = "93697845263",
                    Status = "Clocked In"
                },

                new Person {
                    Name = "Owami",
                    Surname = "Mthombeni",
                    ID = "93697845263",
                    Status = "Clocked In"
                },

                new Person {
                    Name = "Oupa",
                    Surname = "Mthombeni",
                    ID = "93697845263",
                    Status = "Clocked In"
                },

                new Person {
                    Name = "Bafana",
                    Surname = "Bafana",
                    ID = "93697845263",
                    Status = "Clocked In"
                },

                new Person {
                    Name = "Chriss",
                    Surname = "Sibiya",
                    ID = "93697845263",
                    Status = "Clocked In"
                }
            };

            return list;
        }
    }
}
