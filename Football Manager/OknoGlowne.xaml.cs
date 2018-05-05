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
    /// Interaction logic for OknoGlowne.xaml
    /// </summary>
    public partial class OknoGlowne : UserControl
    {
        public static OknoGlowne instancja;

        public OknoGlowne()
        {
            InitializeComponent();
        }

        private void MeczTowarzyski_Click(object sender, RoutedEventArgs e)
        {
            if (BazaDanych.instancja == null)
            {
                BazaDanych.instancja = new BazaDanych();
                for (int i = 0; i < BazaDanych.instancja.iloscKlubow; i++)
                {
                    BazaDanych.instancja.kluby[i].menedzer.ustalNajlepszySklad();
                    BazaDanych.instancja.kluby[i].obliczPoziomy();
                }
            }

            OknoTrybMenedzera.trybMenedzera = false;
            this.Visibility = Visibility.Hidden;
            OknoMeczTowarzyski.instancja.Visibility = Visibility.Visible;
        }

        private void TrybMenedzera_Click(object sender, RoutedEventArgs e)
        {
            if (BazaDanych.instancja == null)
            {
                BazaDanych.instancja = new BazaDanych();
                for (int i = 0; i < BazaDanych.instancja.iloscKlubow; i++)
                {
                    BazaDanych.instancja.kluby[i].menedzer.ustalNajlepszySklad();
                    BazaDanych.instancja.kluby[i].obliczPoziomy();
                }
            }

            OknoTrybMenedzera.trybMenedzera = true;
            OknoTrybMenedzera.wczytanyTrybMenedzera = false;
            this.Visibility = Visibility.Hidden;
            OknoDruzynyTrybMenedzera.instancja.Visibility = Visibility.Visible;
        }

        private void WczytajTrybMenedzera_Click(object sender, RoutedEventArgs e)
        {
            BazaDanych.instancja = new BazaDanych();
            Liga.instancja = BazaDanych.instancja.wczytajGre();

            if (Liga.instancja == null)
            {
                BazaDanych.instancja = new BazaDanych();
                for (int i = 0; i < BazaDanych.instancja.iloscKlubow; i++)
                {
                    BazaDanych.instancja.kluby[i].menedzer.ustalNajlepszySklad();
                    BazaDanych.instancja.kluby[i].obliczPoziomy();
                }
                MessageBox.Show("Nie można było wczytać gry.", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            if (Liga.instancja != null)
            {
                for (int i = 0; i < Liga.instancja.iloscDruzyn; i++)
                {
                    if (Liga.instancja.druzynaGracza != Liga.instancja.druzyny[i])
                    {
                        Liga.instancja.druzyny[i].menedzer.ustalNajlepszySklad();
                        Liga.instancja.druzyny[i].obliczPoziomy();
                    }
                }


                OknoTrybMenedzera.trybMenedzera = true;
                OknoTrybMenedzera.wczytanyTrybMenedzera = true;
                this.Visibility = Visibility.Hidden;
                OknoTrybMenedzera.instancja.Visibility = Visibility.Visible;
            }
        }

        private void OGrze_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            OknoOGrze.instancja.Visibility = Visibility.Visible;
        }

        private void Opcje_Click(object sender, RoutedEventArgs e)
        {
            //this.Visibility = Visibility.Hidden;
            //OknoOpcje.instancja.Visibility = Visibility.Visible;

            if (MessageBox.Show("Czy na pewno chcesz wygenerować nowe dane? W przypadku potwierdzenia zostanie usunięty zapis gry.", "Informacja", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Generator generator = new Generator();
                if (generator.generuj() != -1)
                {
                    BazaDanych.instancja = new BazaDanych();
                    for (int i = 0; i < BazaDanych.instancja.iloscKlubow; i++)
                    {
                        BazaDanych.instancja.kluby[i].menedzer.ustalNajlepszySklad();
                        BazaDanych.instancja.kluby[i].obliczPoziomy();
                    }
                    MessageBox.Show("Dane zostały wygenerowane", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Wystąpił błąd. Dane nie zostały wygenerowane", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Wyjscie_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
