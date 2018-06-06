using Backend;
using Backend.Models;
using Backend.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Stundenplan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Button btn;

        private readonly ViewModel1 _viewModel1 = new ViewModel1();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _viewModel1;

            for(int i = 1; i<=14;i++)
            {
                for(int j = 1;j<=5;j++)
                {
                    Button b = new Button();
                    b.Name = "btn" + i.ToString() + j.ToString();
                    b.Click += AddToTable_Click;
                    b.Background = Brushes.White;
                    Grid.SetColumn(b, j);
                    Grid.SetRow(b, i);
                    Grid.SetZIndex(b, 1);
                    gStundenplan.Children.Add(b);
                }
            }        
        }

        private void AddToTable_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            btn = b;
            EditFach editFach = new EditFach(Grid.GetColumn(b), Grid.GetRow(b), b,_viewModel1)
            {
                Owner = this,
            }; //Zelle des gecklickten Buttons
            editFach.ShowDialog();
        }

        public static void UpdateFach(Fach f)
        {
            btn.Content = $"{f.Name.ToString()}\n{f.Raum}";
            btn.HorizontalContentAlignment = HorizontalAlignment.Center;
            btn.Background = Brushes.Orange;
            if(f.Info!=""&&f.Info!=null)
            {
                btn.BorderBrush = Brushes.Red;
            }
            if(f.FälltAus)
            {
                btn.Background = Brushes.LightGray;
            }
            Grid.SetZIndex(btn, 5);
            Grid.SetColumn(btn, (int)f.Wochentag + 1);
            Grid.SetRow(btn, (int)f.Startzeit + 1);
            Grid.SetRowSpan(btn, f.Length);
        }

        private void AddFach_Click(object sender, RoutedEventArgs e)
        {
            AddFach addFach = new AddFach();
            addFach.Owner = this;
            addFach.DataContext = _viewModel1;
            addFach.ShowDialog();
        }
    }
}
