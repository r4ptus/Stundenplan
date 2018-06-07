using Backend.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.ViewModels
{
    public class ViewModel1 : BaseNotificationClass
    {
        private string _mo;
        private string _di;
        private string _mi;
        private string _do;
        private string _fr;

        public string Montag
        {
            get { return _mo; }
            set
            {
                _mo = value;
                OnPropertyChanged(nameof(Montag));
            }
        }
        public string Dienstag
        {
            get { return _di; }
            set
            {
                _di = value;
                OnPropertyChanged(nameof(Dienstag));
            }
        }
        public string Mittwoch
        {
            get { return _mi; }
            set
            {
                _mi = value;
                OnPropertyChanged(nameof(Mittwoch));
            }
        }
        public string Donnerstag
        {
            get { return _do; }
            set
            {
                _do = value;
                OnPropertyChanged(nameof(Donnerstag));
            }
        }
        public string Freitag
        {
            get { return _fr; }
            set
            {
                _fr = value;
                OnPropertyChanged(nameof(Freitag));
            }
        }
        public ObservableCollection<Fach> Fächer { get; set; }
        public ObservableCollection<Fach> Übungen { get; set; }
        public ObservableCollection<User> Freunde{ get; set; }
        public Dictionary<string,Fach> FachDictionary { get; set; }
        public Fach ToBeAdded { get; set; }

        public ViewModel1()
        {
            Fächer = new ObservableCollection<Fach>();
            Übungen = new ObservableCollection<Fach>();
            FachDictionary = new Dictionary<string, Fach>();
            DateTime startOfWeek = DateTime.Today.AddDays(
                (int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek -
                (int)DateTime.Today.DayOfWeek);

            Montag = "Montag, " + string.Join("", Enumerable.Range(0, 1).Select(i => startOfWeek.AddDays(0).ToString("dd.MM")));
            Dienstag = "Dienstag, " + string.Join("", Enumerable.Range(0, 1).Select(i => startOfWeek.AddDays(1).ToString("dd.MM")));
            Mittwoch = "Mittwoch, " + string.Join("", Enumerable.Range(0, 1).Select(i => startOfWeek.AddDays(2).ToString("dd.MM")));
            Donnerstag = "Donnerstag, " + string.Join("", Enumerable.Range(0, 1).Select(i => startOfWeek.AddDays(3).ToString("dd.MM")));
            Freitag = "Freitag, " + string.Join("", Enumerable.Range(0, 1).Select(i => startOfWeek.AddDays(4).ToString("dd.MM")));
        }
    }
}
