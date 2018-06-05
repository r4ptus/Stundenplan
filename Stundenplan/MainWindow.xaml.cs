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
        private readonly ViewModel1 _viewModel1 = new ViewModel1();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _viewModel1;

            _viewModel1.TimeTable.CollectionChanged += new NotifyCollectionChangedEventHandler(Items_CollectionChanged);

            for(int i = 1; i<=14;i++)
            {
                for(int j = 1;j<=5;j++)
                {
                    Button b = new Button();
                    b.Click += AddToTable_Click;
                    Grid.SetColumn(b, j);
                    Grid.SetRow(b, i);
                    gStundenplan.Children.Add(b);
                }
            }
            
        }

        private void AddToTable_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            EditFach editFach = new EditFach(Grid.GetColumn(b),Grid.GetRow(b));//Zelle des gecklickten Buttons
            editFach.Owner = this;
            editFach.DataContext = _viewModel1;
            editFach.ShowDialog();
        }

        private void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            DrawTable();
        }

        private void DrawTable()
        {
            foreach(Fach f in _viewModel1.TimeTable)
            {
                Button b = new Button();
                b.Click += AddToTable_Click;
                b.Content = $"{f.Name.ToString()}\n{f.Raum}";
                b.HorizontalContentAlignment = HorizontalAlignment.Center;
                Grid.SetColumn(b, (int)f.Wochentag + 1);
                Grid.SetRow(b, (int)f.Startzeit + 1);
                Grid.SetRowSpan(b, f.Length);
                gStundenplan.Children.Add(b);
            }
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
