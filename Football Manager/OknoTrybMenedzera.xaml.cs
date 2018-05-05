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
    /// Interaction logic for OknoTrybMenedzera.xaml
    /// </summary>
    public partial class OknoTrybMenedzera : UserControl
    {
        public static OknoTrybMenedzera instancja;
        public static bool trybMenedzera;
        public static bool wczytanyTrybMenedzera;
        public static bool zakonczoneRozgrywkiLigowe;

        public OknoTrybMenedzera()
        {
            InitializeComponent();
        }

        Klub druzyna;

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.IsVisible == true)
            {
                if (Liga.instancja == null)
                {
                    Liga.instancja = new Liga(BazaDanych.instancja.iloscKlubow, BazaDanych.instancja.kluby, Klub.wybranaDruzyna, "2014/2015", 0);

                    if (wczytanyTrybMenedzera == false)
                        Liga.instancja.wyczyscStatystykiLigowe();
                }

                if(zakonczoneRozgrywkiLigowe == false)
                    Kontynuuj.IsEnabled = true;

                druzyna = Liga.instancja.druzynaGracza;

                lDruzyna.Content = Liga.instancja.druzynaGracza.nazwa;
                lMenedzer.Content = Liga.instancja.druzynaGracza.menedzer.imieNazwisko;
                lSezon.Content = Liga.instancja.sezon;
                lNastepnaKolejka.Content = Liga.instancja.nrKolejki + 1; // NR KOLEJKI ZACZYNA SIE OD ZERA
                lMiejsce.Content = Liga.instancja.sprawdzMiejsce();
                lForma.Content = Liga.instancja.sprawdzOstatnie5Meczow();

                if (Liga.instancja.sprawdzPoprzedniMecz() != null) lPoprzedniMecz.Content = Liga.instancja.sprawdzPoprzedniMecz().druzynyWynik;
                else lPoprzedniMecz.Content = null;
                if (Liga.instancja.sprawdzNastepnyMecz() != null)
                {
                    lGospodarzNazwa.Content = Liga.instancja.sprawdzNastepnyMecz().gospodarz.nazwa;
                    lGoscNazwa.Content = Liga.instancja.sprawdzNastepnyMecz().gosc.nazwa;
                    lAtakGospodarz.Content = Liga.instancja.sprawdzNastepnyMecz().gospodarz.atak;
                    lAtakGosc.Content = Liga.instancja.sprawdzNastepnyMecz().gosc.atak;
                    lPomocGospodarz.Content = Liga.instancja.sprawdzNastepnyMecz().gospodarz.pomoc;
                    lPomocGosc.Content = Liga.instancja.sprawdzNastepnyMecz().gosc.pomoc;
                    lObronaGospodarz.Content = Liga.instancja.sprawdzNastepnyMecz().gospodarz.obrona;
                    lObronaGosc.Content = Liga.instancja.sprawdzNastepnyMecz().gosc.obrona;

                    rAtakGospodarz.Width = Liga.instancja.sprawdzNastepnyMecz().gospodarz.atak * 1.2;
                    rAtakGosc.Width = Liga.instancja.sprawdzNastepnyMecz().gosc.atak * 1.2;
                    rPomocGospodarz.Width = Liga.instancja.sprawdzNastepnyMecz().gospodarz.pomoc * 1.2;
                    rPomocGosc.Width = Liga.instancja.sprawdzNastepnyMecz().gosc.pomoc * 1.2;
                    rObronaGospodarz.Width = Liga.instancja.sprawdzNastepnyMecz().gospodarz.obrona * 1.2;
                    rObronaGosc.Width = Liga.instancja.sprawdzNastepnyMecz().gosc.obrona * 1.2;
                }
                else if (Liga.instancja.sprawdzNastepnyMecz() == null)
                {
                    lGospodarzNazwa.Content = null;
                    lGoscNazwa.Content = null;
                    lAtakGospodarz.Content = null;
                    lAtakGosc.Content = null;
                    lPomocGospodarz.Content = null;
                    lPomocGosc.Content = null;
                    lObronaGospodarz.Content = null;
                    lObronaGosc.Content = null;

                    rAtakGospodarz.Width = 0;
                    rAtakGosc.Width = 0;
                    rPomocGospodarz.Width = 0;
                    rPomocGosc.Width = 0;
                    rObronaGospodarz.Width = 0;
                    rObronaGosc.Width = 0;
                }

                if (Liga.instancja.nrKolejki == 30)
                {
                    if (zakonczoneRozgrywkiLigowe == false)
                    {
                        MessageBox.Show("Gratulacje. Zakończyłeś rozgrywki ligowe");
                        zakonczoneRozgrywkiLigowe = true;
                        Kontynuuj.IsEnabled = false;
                    }
                }
            }
        }

        private void Kontynuuj_Click(object sender, RoutedEventArgs e)
        {
            Liga.instancja.rozegrajKolejke();

            this.Visibility = Visibility.Hidden;
            OknoMecz.instancja.Visibility = Visibility.Visible;
        }

        private void Sklad_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            OknoSklad.instancja.Visibility = Visibility.Visible;
        }

        private void Taktyka_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            OknoTaktyka.instancja.Visibility = Visibility.Visible;
        }

        private void Tabela_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            OknoTabela.instancja.Visibility = Visibility.Visible;
        }

        private void TerminarzLigi_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            OknoTerminarz.instancja.Visibility = Visibility.Visible;
        }

        private void TerminarzDruzyny_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            OknoTerminarzDruzyny.instancja.Visibility = Visibility.Visible;
        }

        private void ZapiszGre_Click(object sender, RoutedEventArgs e)
        {
            if (BazaDanych.instancja.zapiszGre(Liga.instancja) == 0)
                MessageBox.Show("Zapis zakończony powodzeniem", "Zapis gry", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (BazaDanych.instancja.zapiszGre(Liga.instancja) == -1)
                MessageBox.Show("Błąd. Zapis zakończony niepowodzeniem", "Zapis gry", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Powrot_Click(object sender, RoutedEventArgs e)
        {
            trybMenedzera = false;
            zakonczoneRozgrywkiLigowe = false;

            Liga.instancja.tabelaLigowa.wyczysc();
            Liga.instancja = null;

            this.Visibility = Visibility.Hidden;
            if (wczytanyTrybMenedzera == false)
                OknoDruzynyTrybMenedzera.instancja.Visibility = Visibility.Visible;
            else if (wczytanyTrybMenedzera == true)
                OknoGlowne.instancja.Visibility = Visibility.Visible;
        }
    }
}
