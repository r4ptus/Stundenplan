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
    }
}
