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
            if(ViewModel.FachDictionary.ContainsKey(b.Name))
            {
                f = ViewModel.FachDictionary[b.Name];
            }
            if(f!=null)
            {
                cbxFächer.SelectedValue = f.Name;
                tbRaum.Text = f.Raum;
                tbInfo.Text = f.Info;
                tbLänge.Text = f.Length.ToString();
            }
            if (tbLänge.Text == null || tbLänge.Text == "")
                tbLänge.Text = "2";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            f = new Fach
            {
                Name = cbxFächer.SelectedValue.ToString(),
                Raum = tbRaum.Text,
                Info = tbInfo.Text,
                Length = Int32.Parse(tbLänge.Text), //Anzahl der Stunden
                FälltAus = (bool)rbFaelltAus.IsChecked,
                Startzeit = (Fach.StartZeit)row - 1,
                Wochentag = (Fach.WochenTag)col - 1
            };
            ViewModel.FachDictionary[b.Name] = f;
            MainWindow.UpdateFach(f);
            Close();
        }

        private void Löschen_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.FachDictionary.Remove(b.Name);
            MainWindow.UpdateFach(null);
            Close();
        }
    }
}
