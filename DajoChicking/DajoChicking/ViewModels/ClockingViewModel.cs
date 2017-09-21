using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DajoChicking.ViewModels
{
    class ClockingViewModel : System.ComponentModel.INotifyPropertyChanged
    {
        public List<Clocking> clockingLinsList { get; set; }
        public List<Clocking> PersonList
        {
            get { return clockingLinsList; }
            set
            {
                clockingLinsList = value;
                OnProprtyChanced();
            }
        }

        public ClockingViewModel()
        {
          
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnProprtyChanced([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
