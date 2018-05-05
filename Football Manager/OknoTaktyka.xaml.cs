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
    /// Interaction logic for OknoTaktyka.xaml
    /// </summary>
    public partial class OknoTaktyka : UserControl
    {
        public static OknoTaktyka instancja;

        public OknoTaktyka()
        {
            InitializeComponent();
        }

        Klub druzyna;

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                druzyna = Klub.wybranaDruzyna;
                druzyna.uaktualnijWyjsciowa11();
                druzyna.obliczPoziomy();

                if (IsVisible == true)
                {
                    gbDruzyna.Header = druzyna.nazwa;

                    cbFormacja.ItemsSource = Klub.formacje;
                    cbUstawienie.ItemsSource = Klub.ustawienia;
                    cbPressing.ItemsSource = Klub.poziomy;
                    cbAgresja.ItemsSource = Klub.poziomy;
                    cbKapitan.ItemsSource = druzyna.jedenastka;
                    cbStaleFragmentyGry.ItemsSource = druzyna.jedenastka;

                    cbFormacja.SelectedItem = druzyna.formacja;
                    cbUstawienie.SelectedItem = druzyna.ustawienie;
                    cbPressing.SelectedItem = druzyna.pressing;
                    cbAgresja.SelectedItem = druzyna.agresja;
                    cbKapitan.SelectedIndex = druzyna.kapitan;
                    cbStaleFragmentyGry.SelectedIndex = druzyna.staleFragmentyGry;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbFormacja_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            druzyna.formacja = (string)cbFormacja.SelectedItem;
            boisko.odswiez();
        }

        private void cbUstawienie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            druzyna.ustawienie = (string)cbUstawienie.SelectedItem;
            druzyna.obliczPoziomy();
            boisko.odswiez();
        }

        private void cbPressing_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            druzyna.pressing = (string)cbPressing.SelectedItem;
        }

        private void cbAgresja_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            druzyna.agresja = (string)cbAgresja.SelectedItem;
        }

        private void cbKapitan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            druzyna.kapitan = cbKapitan.SelectedIndex;
        }

        private void cbStaleFragmentyGry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            druzyna.staleFragmentyGry = cbStaleFragmentyGry.SelectedIndex;
        }

        private void Powrot_Click(object sender, RoutedEventArgs e)
        {
            if (cbKapitan.SelectedIndex == -1)
                cbKapitan.SelectedIndex = 0;
            if (cbStaleFragmentyGry.SelectedIndex == -1)
                cbStaleFragmentyGry.SelectedIndex = 10;

            this.Visibility = Visibility.Hidden;
            if (OknoTrybMenedzera.trybMenedzera == false)
                OknoPrzedMeczem.instancja.Visibility = Visibility.Visible;
            if (OknoTrybMenedzera.trybMenedzera == true)
                OknoTrybMenedzera.instancja.Visibility = Visibility.Visible;
        }
    }
}
