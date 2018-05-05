using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Football_Manager
{
    /// <summary>
    /// Interaction logic for OknoDruzynyTrybMenedzera.xaml
    /// </summary>
    public partial class OknoDruzynyTrybMenedzera : UserControl
    {
        public static OknoDruzynyTrybMenedzera instancja;

        public OknoDruzynyTrybMenedzera()
        {
            InitializeComponent();
        }

        Klub wybranaDruzyna;

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (IsVisible == true)
            {
                OknoTrybMenedzera.trybMenedzera = true;
                Liga.instancja = null;

                try
                {
                    listaKlubow.ItemsSource = BazaDanych.instancja.kluby;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                dalej.IsEnabled = false;
            }
        }

        private void listaKlubow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            wybranaDruzyna = (Klub)listaKlubow.SelectedItem;
            dalej.IsEnabled = true;
        }

        private void listaKlubow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            wybranaDruzyna = (Klub)listaKlubow.SelectedItem;
            Klub.wybranaDruzyna = wybranaDruzyna;
            this.Visibility = Visibility.Hidden;
            OknoTrybMenedzera.instancja.Visibility = Visibility.Visible;
        }

        private void powrot_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            OknoGlowne.instancja.Visibility = Visibility.Visible;
        }

        private void dalej_Click(object sender, RoutedEventArgs e)
        {
            Klub.wybranaDruzyna = wybranaDruzyna;
            this.Visibility = Visibility.Hidden;
            OknoTrybMenedzera.instancja.Visibility = Visibility.Visible;
        }
    }
}
