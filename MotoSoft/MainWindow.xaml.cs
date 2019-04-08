﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MotoSoft
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region NavigationButtonClick

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MenuNavigation.Visibility = Visibility.Visible;
            MenuInventory.Visibility = Visibility.Hidden;
            MenuListParts.Visibility = Visibility.Hidden;
            MenuGarage.Visibility = Visibility.Hidden;
            MenuSettings.Visibility = Visibility.Hidden;
        }

        private void Inventory_Click(object sender, RoutedEventArgs e)
        {
            MenuInventory.Visibility = Visibility.Visible;
            MenuListParts.Visibility = Visibility.Hidden;
            MenuNavigation.Visibility = Visibility.Hidden;
            MenuGarage.Visibility = Visibility.Hidden;
            MenuSettings.Visibility = Visibility.Hidden;
        }

        private void ListParts_Click(object sender, RoutedEventArgs e)
        {
            MenuListParts.Visibility = Visibility.Visible;
            MenuNavigation.Visibility = Visibility.Hidden;
            MenuInventory.Visibility = Visibility.Hidden;
            MenuGarage.Visibility = Visibility.Hidden;
            MenuSettings.Visibility = Visibility.Hidden;
        }

        private void Garage_Click(object sender, RoutedEventArgs e)
        {
            MenuGarage.Visibility = Visibility.Visible;
            MenuListParts.Visibility = Visibility.Hidden;
            MenuNavigation.Visibility = Visibility.Hidden;
            MenuInventory.Visibility = Visibility.Hidden;
            MenuSettings.Visibility = Visibility.Hidden;
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            MenuSettings.Visibility = Visibility.Visible;
            MenuGarage.Visibility = Visibility.Hidden;
            MenuListParts.Visibility = Visibility.Hidden;
            MenuNavigation.Visibility = Visibility.Hidden;
            MenuInventory.Visibility = Visibility.Hidden;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        #endregion NavigationButtonClick

        
    }
}
