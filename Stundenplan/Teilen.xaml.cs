using Backend.Models;
using Backend.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for Teilen.xaml
    /// </summary>
    public partial class Teilen : Window
    {
        private ViewModel1 vm;
        private Grid grid;
        public Teilen( ViewModel1 v, Grid g)
        {
            InitializeComponent();
            vm = v;
            grid = g;
        }

        private void Teilen_Click(object sender, RoutedEventArgs e)
        {
            User user = new User
            {
                Name = tbName.Text,
                Stundenplan = vm.CurrentUser.Stundenplan
            };
            vm.AlleUser.Add(user);
            Close();
        }

        private void Exportieren_Click(object sender, RoutedEventArgs e)
        {
            RenderTargetBitmap rtb = new RenderTargetBitmap(800, 425, 96, 96, PixelFormats.Pbgra32);
            rtb.Render(grid);
            var enc = new System.Windows.Media.Imaging.PngBitmapEncoder();
            enc.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(rtb));

            using (var stm = System.IO.File.Create(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\"+tbName.Text+".png"))
            {
                enc.Save(stm);
            }
            Close();
        }
    }
}
