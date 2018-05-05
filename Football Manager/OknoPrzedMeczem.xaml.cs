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
    /// Interaction logic for OknoPrzedMeczem.xaml
    /// </summary>
    public partial class OknoPrzedMeczem : UserControl
    {
        public static OknoPrzedMeczem instancja;

        public OknoPrzedMeczem()
        {
            InitializeComponent();
        }

        Klub gospodarz;
        Klub gosc;

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (IsVisible == true)
            {
                try
                {
                    gospodarz = Klub.wybranaDruzyna;
                    gosc = Klub.wybranyPrzeciwnik;
                    lGospodarzNazwa.Content = gospodarz.nazwa;
                    lGoscNazwa.Content = gosc.nazwa;
                    //pbPoziomGospodarz.Value = gospodarz.poziom;
                    //pbPoziomGosc.Value = gosc.poziom;
                    //pbAtakGospodarz.Value = gospodarz.atak;
                    //pbAtakGosc.Value = gosc.atak;
                    //pbPomocGospodarz.Value = gospodarz.pomoc;
                    //pbPomocGosc.Value = gosc.pomoc;
                    //pbObronaGospodarz.Value = gospodarz.obrona;
                    //pbObronaGosc.Value = gosc.obrona;
                    rPoziomGospodarz.Width = gospodarz.poziom * 2.5;
                    rPoziomGosc.Width = gosc.poziom * 2.5;
                    rAtakGospodarz.Width = gospodarz.atak * 2.5;
                    rAtakGosc.Width = gosc.atak * 2.5;
                    rPomocGospodarz.Width = gospodarz.pomoc * 2.5;
                    rPomocGosc.Width = gosc.pomoc * 2.5;
                    rObronaGospodarz.Width = gospodarz.obrona * 2.5;
                    rObronaGosc.Width = gosc.obrona * 2.5;

                    lPoziomGospodarz.Content = gospodarz.poziom;
                    lAtakGospodarz.Content = gospodarz.atak;
                    lPomocGospodarz.Content = gospodarz.pomoc;
                    lObronaGospodarz.Content = gospodarz.obrona;
                    lPoziomGosc.Content = gosc.poziom;
                    lAtakGosc.Content = gosc.atak;
                    lPomocGosc.Content = gosc.pomoc;
                    lObronaGosc.Content = gosc.obrona;

                    //Mecz mecz = new Mecz(gospodarz, gosc);
                    //mecz.rozegrajBezRelacji();
                    //lAtak.Content = mecz.roznicaAtakGospodarzObronaGosc + " " + mecz.roznicaAtakGospodarzObronaGosc / 10;
                    //lPomoc.Content = mecz.roznicaPomoc + " " + mecz.roznicaPomoc / 10;
                    //lObrona.Content = mecz.roznicaAtakGoscObronaGospodarz + " " + mecz.roznicaAtakGoscObronaGospodarz / 10;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
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

        private void Powrot_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            OknoMeczTowarzyski.instancja.Visibility = Visibility.Visible;
        }

        private void rozpocznijMecz_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            //Globalne.oknoPoMeczu.Visibility = Visibility.Visible;
            OknoMecz.instancja.Visibility = Visibility.Visible;
        }
    }
}
