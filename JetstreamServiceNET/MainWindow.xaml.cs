using JetstreamServiceNET.ViewModels;
using JetstreamServiceNET.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace JetstreamServiceNET
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ContentArea.Content = new HomeView();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            HomeView home = new HomeView();
            ContentArea.Content = home;
        }

        private void btnErstellung_Click(object sender, RoutedEventArgs e)
        {
            ErstellungView erstellung = new ErstellungView();
            ContentArea.Content = erstellung;
        }

        private void btnVerwaltung_Click(object sender, RoutedEventArgs e)
        {
            VerwaltungView verwaltung = new VerwaltungView();
            ContentArea.Content = verwaltung;
        }

        private void btnBenutzer_Click(object sender, RoutedEventArgs e)
        {
            BenutzerView benutzer = new BenutzerView();
            ContentArea.Content = benutzer;
        }
    }
}
