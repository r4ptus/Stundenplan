using Backend.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.ViewModels
{
    public class ViewModel1
    {
        public ObservableCollection<Fach> Fächer { get; set; }
        public ObservableCollection<Fach> TimeTable { get; set; }
        public Fach ToBeAdded { get; set; }

        public ViewModel1()
        {
            Fächer = new ObservableCollection<Fach>();
            TimeTable = new ObservableCollection<Fach>();
        }
    }
}
