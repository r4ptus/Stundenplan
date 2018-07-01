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
    /// Interaction logic for AddFach.xaml
    /// </summary>
    public partial class AddFach : Window
    {
        public ViewModel1 ViewModel => DataContext as ViewModel1;
        public AddFach()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(tbName.Text!=null)
            {
                ViewModel.Fächer.Add(new Backend.Models.Fach { Name = tbName.Text, Pflichtfach = (bool)cbPflichtfach.IsChecked });
                ViewModel.Übungen.Add(new Backend.Models.Fach { Name = tbName.Text + "_Ü", Pflichtfach = false });
                Close();
            }
        }
    }
}
