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
        public ViewModel1 _viewModel1 = new ViewModel1();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _viewModel1;
           
            Loaded += new RoutedEventHandler(ThisWindowLoaded);
            Closing += new CancelEventHandler(ThisWindowClosed);

            cbxStudiengänge.SelectionChanged += new SelectionChangedEventHandler(StudienGangChanged);

            for (int i = 1; i <= 14; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    Button b = new Button();
                    b.Name = "btn" + i.ToString() + j.ToString();
                    b.Click += AddToTable_Click;
                    b.Background = Brushes.White;
                    Grid.SetColumn(b, j);
                    Grid.SetRow(b, i);
                    Grid.SetZIndex(b, 1);
                    RegisterName(b.Name, b);
                    gStundenplan.Children.Add(b);
                }
            }
       
            //DrawTable(_viewModel1.DeineFreunde[0].Stundenplan);
        }


        /**
        * Ruft das Edit Window auf und fügt ein Fach zum Stundenplan hinzu
        **/
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
        /**
         * Updated das Fach nach einer Änderung
         **/
        public static void UpdateFach(Fach f)
        {
            if (f != null)
            {
                btn.Content = $"{f.Name.ToString()}\n{f.Raum}";
                btn.HorizontalContentAlignment = HorizontalAlignment.Center;
                btn.Background = Brushes.Orange;
                btn.BorderBrush = Brushes.Black;
                if (f.Info != "" && f.Info != null)
                {
                    btn.BorderBrush = Brushes.Red;
                }
                if (f.FälltAus)
                {
                    btn.Background = Brushes.LightGray;
                }
                Grid.SetZIndex(btn, 5);
                Grid.SetRowSpan(btn, f.Length);
            }
            else
            {
                btn.Content = "";
                btn.Background = Brushes.White;
                btn.BorderBrush = Brushes.Black;
                Grid.SetZIndex(btn, 1);
                Grid.SetRowSpan(btn,1);
            }
        }
        /**
        * Zeichnet einen kompletten Stundenplan
        **/
        private void DrawTable(Dictionary<string,Fach> dic)
        {
            foreach(KeyValuePair<string,Fach> entry in dic)
            {
                btn = (Button)FindName(entry.Key.ToString());
                btn.Content = $"{entry.Value.Name.ToString()}\n{entry.Value.Raum}";
                btn.HorizontalContentAlignment = HorizontalAlignment.Center;
                btn.Background = Brushes.Orange;
                if (entry.Value.Info != "" && entry.Value.Info != null)
                {
                    btn.BorderBrush = Brushes.Red;
                }
                if (entry.Value.FälltAus)
                {
                    btn.Background = Brushes.LightGray;
                }
                Grid.SetZIndex(btn, 5);
                Grid.SetColumn(btn, (int)entry.Value.Wochentag + 1);
                Grid.SetRow(btn, (int)entry.Value.Startzeit + 1);
                Grid.SetRowSpan(btn, entry.Value.Length);
            }
        }
        /**
         * Öffnet das AddFach window und fügt ein neues Fach und die jeweilige Übung hinzu
         **/
        private void AddFach_Click(object sender, RoutedEventArgs e)
        {
            AddFach addFach = new AddFach();
            addFach.Owner = this;
            addFach.DataContext = _viewModel1;
            addFach.ShowDialog();
        }
        /**
         * Fügt einen Freund zu deinen persönlichen freunden hinzu
         **/
        private void AddFriend_Click(object sender, RoutedEventArgs e)
        {
            AddFriend addFriend = new AddFriend(_viewModel1);
            addFriend.Owner = this;
            addFriend.DataContext = _viewModel1;
            addFriend.ShowDialog();
        }
        /**
         * zeigt dir den Stundenplan von einem Freund
         **/
        private void ChangeTimeTable_Click(object sender, RoutedEventArgs e)
        {
            ClearTable();
            User u =  ((FrameworkElement)sender).DataContext as User;
            User u2 = _viewModel1.DeineFreunde.First(x => x.Name.Equals(u.Name));
            u = u2;
            _viewModel1.CurrentUser = u;
            DrawTable(u.Stundenplan);
        }
        /**
         * setzt die komplette Tabelle zurück auf standart
         **/
        private void ClearTable()
        {
            for (int i = 1; i <= 14; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    Button btn = (Button)FindName("btn"+i.ToString()+j.ToString());
                    btn.Content = "";
                    btn.Background = Brushes.White;
                    btn.BorderBrush = Brushes.Black;
                    Grid.SetZIndex(btn, 1);
                    Grid.SetRowSpan(btn, 1);
                }
            }
        }
        /**
         * Finds Visual Child of an itemscontrol in our case the first button of icontrol
         **/
        private static T FindVisualChild<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        return (T)child;
                    }

                    T childItem = FindVisualChild<T>(child);
                    if (childItem != null)
                        return childItem;
                }
            }
            return null;
        }
        /**
         * WindowLoaded event Function is triggered when window is loaded
         **/
        private void ThisWindowLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                DataReader reader = new DataReader("data.xml");

                foreach (Fach f in reader.GetFaecher())
                {
                    _viewModel1.Other.Add(f);
                }

                _viewModel1.DeineFreunde[0].Stundenplan = reader.GetFirstStundenplan();
                if (_viewModel1.DeineFreunde[0].Stundenplan == null)
                    _viewModel1.DeineFreunde[0].Stundenplan = new Dictionary<string, Fach>();
                _viewModel1.CurrentUser = _viewModel1.DeineFreunde[0];
                DrawTable(_viewModel1.CurrentUser.Stundenplan);
            }
            catch { }


    
            var textbox = FindVisualChild<Button>(iControl.ItemContainerGenerator.ContainerFromIndex(0));
            FocusManager.SetFocusedElement(iControl, textbox);
        }

        private void ThisWindowClosed(object sender, CancelEventArgs e)
        {

            DataWriter.Create("data.xml");
            DataWriter writer = new DataWriter("data.xml");
            
            foreach(Fach f in _viewModel1.Other)
            {
                writer.AddFach(f);
            }
    
            writer.AddStundenplan("DU",_viewModel1.CurrentUser.Stundenplan);

        }

        private void StudienGangChanged(object sender, RoutedEventArgs e)
        {
            _viewModel1.Fächer.Clear();
            _viewModel1.Übungen.Clear();
            if(cbxStudiengänge.SelectedItem.ToString().Equals("B-IN"))
            {
                foreach(Fach f in _viewModel1.Inf.GetFaecherListe())
                {
                    _viewModel1.Fächer.Add(f);
                    _viewModel1.Übungen.Add(new Fach { Name = f.Name + "_Ü" });
                }
            }
            else if(cbxStudiengänge.SelectedItem.ToString().Equals("B-MC"))
            {
                foreach (Fach f in _viewModel1.Mcf.GetFaecherListe())
                {
                    _viewModel1.Fächer.Add(f);
                    _viewModel1.Übungen.Add(new Fach { Name = f.Name + "_Ü" });
                }
            }
            else if (cbxStudiengänge.SelectedItem.ToString().Equals("other"))
            {
                foreach (Fach f in _viewModel1.Other)
                {
                    _viewModel1.Fächer.Add(f);
                    _viewModel1.Übungen.Add(new Fach { Name = f.Name + "_Ü" });
                }
            }
        }

        private void Teilen_Click(object sender, RoutedEventArgs e)
        {
            Teilen t = new Teilen(_viewModel1, gStundenplan);
            t.Owner = this;
            t.DataContext = _viewModel1;
            t.ShowDialog();
        }

       
    }
}
