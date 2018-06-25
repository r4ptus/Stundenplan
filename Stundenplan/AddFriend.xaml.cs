﻿using Backend.Models;
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
    /// Interaction logic for AddFriend.xaml
    /// </summary>
    public partial class AddFriend : Window
    {
        private ViewModel1 vm;
        public AddFriend(ViewModel1 v)
        {
            InitializeComponent();
            vm = v;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cbxFreunde.SelectedItem != null)
            {
                vm.DeineFreunde.Add((User)cbxFreunde.SelectedItem);
                Close();
            }
        }
    }
}
