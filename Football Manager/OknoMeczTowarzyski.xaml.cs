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
using System.Data;

namespace Football_Manager
{
    /// <summary>
    /// Interaction logic for OknoMeczTowarzyski.xaml
    /// </summary>
    public partial class OknoMeczTowarzyski : UserControl
    {
        public static OknoMeczTowarzyski instancja;

        public OknoMeczTowarzyski()
        {
            InitializeComponent();
        }

        Klub wybranyGospodarz;
        Klub wybranyGosc;

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (IsVisible == true)
            {
                OknoTrybMenedzera.trybMenedzera = false;

                try
                {

                    gbDruzyny.Visibility = Visibility.Visible;
                    gbDruzyny2.Visibility = Visibility.Hidden;

                    listaKlubow.Items.Clear();
                    for (int i = 0; i < BazaDanych.instancja.iloscKlubow; i++)
                    {
                        listaKlubow.Items.Add(BazaDanych.instancja.kluby[i]);
                    }

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
            wybranyGospodarz = (Klub)listaKlubow.SelectedItem;
            dalej.IsEnabled = true;
        }

        private void listaKlubow2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            wybranyGosc = (Klub)listaKlubow2.SelectedItem;
            dalej2.IsEnabled = true;
        }

        private void powrot_Click_1(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            OknoGlowne.instancja.Visibility = Visibility.Visible;
        }

        private void powrot2_Click(object sender, RoutedEventArgs e)
        {
            gbDruzyny.Visibility = Visibility.Visible;
            gbDruzyny2.Visibility = Visibility.Hidden;
        }

        private void dalej_Click_1(object sender, RoutedEventArgs e)
        {
            utworz2ListeKlubow();

            gbDruzyny.Visibility = Visibility.Hidden;
            gbDruzyny2.Visibility = Visibility.Visible;
        }

        private void dalej2_Click(object sender, RoutedEventArgs e)
        {
            Klub.wybranaDruzyna = wybranyGospodarz;
            Klub.wybranyPrzeciwnik = wybranyGosc;

            this.Visibility = Visibility.Hidden;
            OknoPrzedMeczem.instancja.Visibility = Visibility.Visible;
        }

        private void listaKlubow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            utworz2ListeKlubow();

            gbDruzyny.Visibility = Visibility.Hidden;
            gbDruzyny2.Visibility = Visibility.Visible;
        }

        private void listaKlubow2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (wybranyGosc is Klub)
                wybranyGosc = (Klub)listaKlubow2.SelectedItem;
            else
                wybranyGosc = (Klub)listaKlubow2.Items[0];

            Klub.wybranaDruzyna = wybranyGospodarz;
            Klub.wybranyPrzeciwnik = wybranyGosc;

            this.Visibility = Visibility.Hidden;
            OknoPrzedMeczem.instancja.Visibility = Visibility.Visible;
        }

        void utworz2ListeKlubow()
        {
            if (wybranyGospodarz is Klub)
                wybranyGospodarz = (Klub)listaKlubow.SelectedItem;
            else
                wybranyGospodarz = (Klub)listaKlubow.Items[0];

            listaKlubow2.Items.Clear();
            for (int i = 0; i < BazaDanych.instancja.iloscKlubow; i++)
            {
                if (wybranyGospodarz != BazaDanych.instancja.kluby[i])
                    listaKlubow2.Items.Add(BazaDanych.instancja.kluby[i]);
            }
        }

    }
}
