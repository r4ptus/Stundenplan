using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Fach : BaseNotificationClass, IComparable<Fach>
    {
        private string _name = "";
        private string _raum = "";
        private string _info = "";
        private bool _fdindesStatt = false;
        private int _lenght = 0;
        private bool _pflichtfach = true;
        private int _id = -1;

        public Fach()
        {
        }
        public Fach(String name, bool pflicht)
        {
            this._name = name;
            this._pflichtfach = pflicht;
        }

        public enum StartZeit { S0800, S0845, S0955, S1040, S1145, S1230, S1400, S1445, S1545, S1630, S1730, S1825, S1915, S2000,None }
        public enum WochenTag { Mo, Di, Mi, Do, Fr,None}

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

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
        public int Length
        {
            get { return _lenght; }
            set
            {
                _lenght = value;
                OnPropertyChanged(nameof(Length));
            }
        }
        public StartZeit Startzeit { get; set; } = StartZeit.None;
        public WochenTag Wochentag { get; set; } = WochenTag.None;
        public bool FälltAus
        {
            get { return _fdindesStatt; }
            set
            {
                _fdindesStatt = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public bool Pflichtfach
        {
            get { return _pflichtfach; }
            set
            {
               _pflichtfach = value;
            }
        }

        int IComparable<Fach>.CompareTo(Fach other)
        {
           int comp = other._pflichtfach.CompareTo(_pflichtfach);
           if(comp == 0)
            {
                return _name.CompareTo(other._name);
            }
            return comp;
        }
    }
}
