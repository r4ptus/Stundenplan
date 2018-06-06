using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Fach : BaseNotificationClass
    {
        private string _name;
        private string _raum;
        private string _info;
        private bool _fdindesStatt = false;
        private int _lenght;


        public enum StartZeit { S0800, S0845, S0955, S1040, S1145, S1230, S1400, S1445, S1545, S1630, S1730, S1825, S1915, S2000 }
        public enum WochenTag { Mo, Di, Mi, Do, Fr}

        public string Name
        {
            get{ return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }              
        }
        public string Raum
        {
            get { return _raum; }
            set
            {
                _raum = value;
                OnPropertyChanged(nameof(Raum));
            }
        }
        public string Info
        {
            get { return _info; }
            set
            {
                _info = value;
                OnPropertyChanged(nameof(Info));
            }
        }
        public string Studiengang { get; set; }
        public int Length
        {
            get { return _lenght; }
            set
            {
                _lenght = value;
                OnPropertyChanged(nameof(Length));
            }
        }
        public StartZeit Startzeit { get; set; }
        public WochenTag Wochentag { get; set; }
        public bool FälltAus
        {
            get { return _fdindesStatt; }
            set
            {
                _fdindesStatt = value;
                OnPropertyChanged(nameof(Name));
            }
        }
    }
}
