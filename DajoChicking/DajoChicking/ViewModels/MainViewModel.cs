using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DajoChicking.ViewModels
{
    public class MainViewModel : System.ComponentModel.INotifyPropertyChanged
    {
        public List<Person> peopleList { get; set; }
       public List<Person> PersonList {
            get { return peopleList; }
            set { peopleList = value;
                OnProprtyChanced();
            }
        }

        public MainViewModel()
        {
            //var peopleService = new Services.PeopleServices();
            //peopleList = peopleService.getPeople();
            //getPersonAsync();


        }

       


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnProprtyChanced([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
