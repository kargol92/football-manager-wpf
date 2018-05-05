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
    /// Interaction logic for OknoMecz.xaml
    /// </summary>
    public partial class OknoPoMeczu : UserControl
    {
        public static OknoPoMeczu instancja;

        public OknoPoMeczu()
        {
            InitializeComponent();
        }

        Mecz mecz;

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (IsVisible == true)
            {
                if (OknoTrybMenedzera.trybMenedzera == false)
                {
                    mecz = Mecz.ostatnioRozegranyMecz;
                    //mecz = new Mecz(Klub.wybranaDruzyna, Klub.wybranyPrzeciwnik);
                    //mecz.rozegrajBezRelacji();
                }
                if (OknoTrybMenedzera.trybMenedzera == true)
                    mecz = Liga.instancja.sprawdzPoprzedniMecz();

                lGospodarzNazwa.Content = mecz.gospodarz.nazwa;
                lGoscNazwa.Content = mecz.gosc.nazwa;
                lGole.Content = mecz.goleGospodarz + " - " + mecz.goleGosc;
                lPosiadaniePilkiGospodarz.Content = mecz.posiadaniePilkiGospodarz + "%";
                lPosiadaniePilkiGosc.Content = mecz.posiadaniePilkiGosc + "%";
                lSkutecznoscAtakuGospodarz.Content = mecz.skutecznoscAtakuGospodarz + "%";
                lSkutecznoscAtakuGosc.Content = mecz.skutecznoscAtakuGosc + "%";
                lGospodarzIloscAkcji.Content = mecz.iloscAkcjiGospodarz;
                lGoscIloscAkcji.Content = mecz.iloscAkcjiGosc;
                lFormacjaGospodarz.Content = mecz.gospodarz.formacja;
                lFormacjaGosc.Content = mecz.gosc.formacja;
                lUstawienieGospodarz.Content = mecz.gospodarz.ustawienie;
                lUstawienieGosc.Content = mecz.gosc.ustawienie;
                lPressingGospodarz.Content = mecz.gospodarz.pressing;
                lPressingGosc.Content = mecz.gosc.pressing;
                lAgresjaGospodarz.Content = mecz.gospodarz.agresja;
                lAgresjaGosc.Content = mecz.gosc.agresja;
                lKapitanGospodarz.Content = mecz.gospodarz.pilkarze[mecz.gospodarz.kapitan].nazwisko;
                lKapitanGosc.Content = mecz.gosc.pilkarze[mecz.gosc.kapitan].nazwisko;
                lStaleFragmentyGospodarz.Content = mecz.gospodarz.pilkarze[mecz.gospodarz.staleFragmentyGry].nazwisko;
                lStaleFragmentyGosc.Content = mecz.gosc.pilkarze[mecz.gosc.staleFragmentyGry].nazwisko;


                rPosiadaniePilkiGospodarz.Width = mecz.posiadaniePilkiGospodarz * 2.5;
                rPosiadaniePilkiGosc.Width = mecz.posiadaniePilkiGosc * 2.5;
                rSkutecznoscAtakuGospodarz.Width = mecz.skutecznoscAtakuGospodarz * 3.5;
                rSkutecznoscAtakuGosc.Width = mecz.skutecznoscAtakuGosc * 3.5;

                lGospodarzGole.ItemsSource = mecz.zdarzeniaGospodarz;
                lGoscGole.ItemsSource = mecz.zdarzeniaGosc;

                //lGospodarz11.Items.Clear();
                //lGosc11.Items.Clear();
                //for (int i = 0; i < 11; i++)
                //{
                //    lGospodarz11.Items.Add(gospodarz.pilkarze[i]);
                //    lGosc11.Items.Add(gosc.pilkarze[i]);
                //}
            }
        }

        private void powrot_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            if (OknoTrybMenedzera.trybMenedzera == false)
                OknoPrzedMeczem.instancja.Visibility = Visibility.Visible;
            if (OknoTrybMenedzera.trybMenedzera == true)
                OknoTrybMenedzera.instancja.Visibility = Visibility.Visible;
        }
    }
}
