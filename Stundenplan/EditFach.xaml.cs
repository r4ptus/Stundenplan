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

        public ViewModel1 ViewModel => DataContext as ViewModel1;

        public EditFach( int c,int r)//Tag und uhrzeit
        {
            InitializeComponent();
            col = c;
            row = r;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.TimeTable.Add(new Fach {
                Name = cbxFächer.SelectedValue.ToString(),
                Raum = tbRaum.Text, Info = tbInfo.Text,
                Length = Int32.Parse(tbLänge.Text), //Anzahl der Stunden
                FindetStatt = (bool)rbFaelltAus.IsChecked,
                Startzeit = (Fach.StartZeit)row-1,
                Wochentag = (Fach.WochenTag)col-1});
            Close();
        }
    }
}
