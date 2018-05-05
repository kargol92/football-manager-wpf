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
    /// Interaction logic for Sklad.xaml
    /// </summary>
    public partial class OknoSklad : UserControl
    {
        public static OknoSklad instancja;

        public OknoSklad()
        {
            InitializeComponent();
        }

        Klub druzyna;
        Pilkarz zaznaczonyPilkarz;
        Pilkarz wybranyPilkarz;
        int doZmiany;
        int doZmiany2;

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (IsVisible == true)
            {
                boisko.odswiez();

                doZmiany = -1;
                doZmiany2 = -1;
                try
                {
                    druzyna = Klub.wybranaDruzyna;
                    druzyna.nadajNumery();

                    listaPilkarzy.ItemsSource = druzyna.pilkarze;
                    listaPilkarzy.SelectedItem = null;
                    zaznaczonyPilkarz = null;

                    gbDruzyna.Header = druzyna.nazwa;
                    gbPilkarz.Header = druzyna.pilkarze[0].imieNazwisko;
                    umiejetnosci.Width = druzyna.pilkarze[0].umiejetnosci * 1.7;
                    umBramkarskie.Width = druzyna.pilkarze[0].umBramkarskie * 1.7;
                    defensywa.Width = druzyna.pilkarze[0].defensywa * 1.7;
                    rozgrywanie.Width = druzyna.pilkarze[0].rozgrywanie * 1.7;
                    skutecznosc.Width = druzyna.pilkarze[0].skutecznosc * 1.7;
                    kondycja.Width = druzyna.pilkarze[0].kondycja * 1.7;
                    przywodztwo.Width = druzyna.pilkarze[0].przywodztwo * 1.7;
                    lPoziom.Content = druzyna.pilkarze[0].umiejetnosci;
                    lUmBramkarskie.Content = druzyna.pilkarze[0].umBramkarskie;
                    lDefensywa.Content = druzyna.pilkarze[0].defensywa;
                    lRozgrywanie.Content = druzyna.pilkarze[0].rozgrywanie;
                    lStrzaly.Content = druzyna.pilkarze[0].skutecznosc;
                    lKondycja.Content = druzyna.pilkarze[0].kondycja;
                    lPrzywodztwo.Content = druzyna.pilkarze[0].przywodztwo;


                    druzyna.uaktualnijWyjsciowa11();
                    druzyna.obliczPoziomy();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void listaPilkarzy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            zaznaczonyPilkarz = (Pilkarz)listaPilkarzy.SelectedItem;
            druzyna.nadajNumery();

            if (zaznaczonyPilkarz != null)
            {
                gbPilkarz.Header = zaznaczonyPilkarz.imieNazwisko;
                umiejetnosci.Width = zaznaczonyPilkarz.umiejetnosci  * 1.7;
                umBramkarskie.Width = zaznaczonyPilkarz.umBramkarskie* 1.7;
                defensywa.Width = zaznaczonyPilkarz.defensywa        * 1.7;
                rozgrywanie.Width = zaznaczonyPilkarz.rozgrywanie    * 1.7;
                skutecznosc.Width = zaznaczonyPilkarz.skutecznosc    * 1.7;
                kondycja.Width = zaznaczonyPilkarz.kondycja          * 1.7;
                przywodztwo.Width = zaznaczonyPilkarz.przywodztwo    * 1.7;
                lPoziom.Content = zaznaczonyPilkarz.umiejetnosci;
                lUmBramkarskie.Content = zaznaczonyPilkarz.umBramkarskie;
                lDefensywa.Content = zaznaczonyPilkarz.defensywa;
                lRozgrywanie.Content = zaznaczonyPilkarz.rozgrywanie;
                lStrzaly.Content = zaznaczonyPilkarz.skutecznosc;
                lKondycja.Content = zaznaczonyPilkarz.kondycja;
                lPrzywodztwo.Content = zaznaczonyPilkarz.przywodztwo;
                //lNajlepszaPozycja.Content = zaznaczonyPilkarz.najlepszaPozycja;
            }
        }

        private void Powrot_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            if (OknoTrybMenedzera.trybMenedzera == false)
                OknoPrzedMeczem.instancja.Visibility = Visibility.Visible;
            if (OknoTrybMenedzera.trybMenedzera == true)
                OknoTrybMenedzera.instancja.Visibility = Visibility.Visible;
        }

        private void listaPilkarzy_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            dokonajZmiany();
        }

        private void listaPilkarzy_KeyDown(object sender, KeyEventArgs e)
        {
            dokonajZmiany();
        }

        void dokonajZmiany()
        {
            if (wybranyPilkarz == null)
            {
                doZmiany = listaPilkarzy.SelectedIndex;
                wybranyPilkarz = (Pilkarz)listaPilkarzy.SelectedItem;
            }
            else if (wybranyPilkarz != null)
            {
                doZmiany2 = listaPilkarzy.SelectedIndex;
                if (doZmiany != -1)
                {
                    Pilkarz temp = druzyna.pilkarze[doZmiany];
                    druzyna.pilkarze[doZmiany] = druzyna.pilkarze[doZmiany2];
                    druzyna.pilkarze[doZmiany2] = temp;
                }
                listaPilkarzy.ItemsSource = druzyna.pilkarze;
                listaPilkarzy.Items.Refresh();
                listaPilkarzy.SelectedIndex = doZmiany2;
                wybranyPilkarz = null;
            }
            //if (wybranyPilkarz != null)
            //    lWybranyPilkarz.Content = wybranyPilkarz.nazwisko;
        }
    }
}
