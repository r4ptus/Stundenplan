using Backend.Models;
using Backend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Stundenplan
{
    /// <summary>
    /// Interaction logic for EditFach.xaml
    /// </summary>
    public partial class EditFach : Window
    {
        int row = 1; //Startzeit der Stunde 
        int col = 1; //Wochentag

        Button b;
        Fach f;

        public ViewModel1 ViewModel;

        public EditFach( int c,int r,Button b,ViewModel1 v)//Tag und uhrzeit
        {
            InitializeComponent();
            ViewModel = v;
            DataContext = ViewModel;
            List<Fach> l = new List<Fach>();
            l.AddRange(ViewModel.Fächer);
            l.AddRange(ViewModel.Übungen);
            ViewModel.Alle = new System.Collections.ObjectModel.ObservableCollection<Fach>(l);
            col = c;
            row = r;
            this.b = b;
            if(ViewModel.CurrentUser.Stundenplan.ContainsKey(b.Name))
            {
                f = ViewModel.CurrentUser.Stundenplan[b.Name];
            }
            if(f!=null)//Setzt die vorhanden Properies
            {
                cbxFächer.SelectedValue = f.Name;
                tbRaum.Text = f.Raum;
                tbInfo.Text = f.Info;
                tbLänge.Text = f.Length.ToString();
            }
            if (tbLänge.Text == null || tbLänge.Text.Equals(""))//
                tbLänge.Text = "2";
        }
        /**
         * Fügt das Fach zum Dictionary hinzu und schließt das fenster
         **/
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cbxFächer.SelectedItem != null)
            {
                f = new Fach
                {
                    Name = cbxFächer.SelectedValue.ToString(),
                    Raum = tbRaum.Text,
                    Info = tbInfo.Text,
                    FälltAus = (bool)rbFaelltAus.IsChecked,
                    Startzeit = (Fach.StartZeit)row - 1,
                    Wochentag = (Fach.WochenTag)col - 1
                };
                if (tbLänge.Text == null )//checking for userinput
                {
                    f.Length = 2;
                }
                else
                    f.Length = Int32.Parse(tbLänge.Text);
                ViewModel.CurrentUser.Stundenplan[b.Name] = f;
                MainWindow.UpdateFach(f);
                Close();
            }
        }
        /**
         * Löscht das jeweilige Fach
         **/
        private void Löschen_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.CurrentUser.Stundenplan.Remove(b.Name);
            MainWindow.UpdateFach(null);
            Close();
        }

    }
}
