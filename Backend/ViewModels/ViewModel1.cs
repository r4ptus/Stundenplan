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
        public User CurrentUser { get; set; }
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
        public ObservableCollection<Fach> Fächer { get; set; } //Liste von allen Fächern 
        public ObservableCollection<Fach> Übungen { get; set; } // Liste von allen Übungen
        public ObservableCollection<Fach> Alle { get; set; } //gemeinsame Liste von Fächern und Übungen
        public ObservableCollection<User> DeineFreunde { get; set; } //User die du hinzugefügt hast
        public ObservableCollection<User> AlleUser { get; set; } //Alle verfügbaren User
        public ObservableCollection<String> Studiengänge { get; set; }
        public INFaecher Inf { get; set; }
        public MCFaecher Mcf { get; set; }

        public ViewModel1()
        {
             Inf = new INFaecher();
             Mcf = new MCFaecher();

            //Initialisierung aller Collections
            Fächer = new ObservableCollection<Fach>();//wird aus Datenbank gefüllt
            Übungen = new ObservableCollection<Fach>();//wird aus Datenbank gefüllt
            Alle = new ObservableCollection<Fach>();
            AlleUser = new ObservableCollection<User>();//wird aus Datenbank gefüllt
            Studiengänge = new ObservableCollection<string>
            {
                "B-IN",
                "B-MC"
            };
            //Dein Stundenplan du bistauch ein User
            DeineFreunde = new ObservableCollection<User>
            {
                new User { Name = "Du" }
            };
            //Datumsberechnung
            DateTime startOfWeek = DateTime.Today.AddDays(
                (int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek -
                (int)DateTime.Today.DayOfWeek);

            Montag = "Montag, " + string.Join("", Enumerable.Range(0, 1).Select(i => startOfWeek.AddDays(0).ToString("dd.MM")));
            Dienstag = "Dienstag, " + string.Join("", Enumerable.Range(0, 1).Select(i => startOfWeek.AddDays(1).ToString("dd.MM")));
            Mittwoch = "Mittwoch, " + string.Join("", Enumerable.Range(0, 1).Select(i => startOfWeek.AddDays(2).ToString("dd.MM")));
            Donnerstag = "Donnerstag, " + string.Join("", Enumerable.Range(0, 1).Select(i => startOfWeek.AddDays(3).ToString("dd.MM")));
            Freitag = "Freitag, " + string.Join("", Enumerable.Range(0, 1).Select(i => startOfWeek.AddDays(4).ToString("dd.MM")));

            CurrentUser = DeineFreunde[0];
 
        }
    }
}
