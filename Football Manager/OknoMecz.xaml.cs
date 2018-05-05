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
using System.Windows.Threading;
using System.Windows.Media.Animation;

namespace Football_Manager
{
    /// <summary>
    /// Interaction logic for OknoMecz.xaml
    /// </summary>
    public partial class OknoMecz : UserControl
    {
        public static OknoMecz instancja;

        public OknoMecz()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
        }

        Mecz mecz;
        bool szybkoscZwykla;
        DispatcherTimer timer;
        int minuta;

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (IsVisible == false)
            {
                powrot.IsEnabled = false;
                Mecz.ostatnioRozegranyMecz = mecz;
            }

            if (IsVisible == true)
            {
                lMinuta.Content = 0;
                lGole.Content = "0 - 0";
                lPosiadaniePilkiGospodarz.Content = "50%";
                lPosiadaniePilkiGosc.Content = "50%";
                rPosiadaniePilkiGospodarz.Width = 50 * 2.5;
                rPosiadaniePilkiGosc.Width = 50 * 2.5;
                lSkutecznoscAtakuGospodarz.Content = "0%";
                lSkutecznoscAtakuGosc.Content = "0%";
                rSkutecznoscAtakuGospodarz.Width = 0;
                rSkutecznoscAtakuGosc.Width = 0;

                //timer = new DispatcherTimer();
                //timer.Tick += new EventHandler(timer_Tick);
                //timer.Interval = new TimeSpan(0, 0, 1);

                if (OknoTrybMenedzera.trybMenedzera == false)
                {
                    mecz = new Mecz(Klub.wybranaDruzyna, Klub.wybranyPrzeciwnik);
                }
                else if (OknoTrybMenedzera.trybMenedzera == true)
                {
                    Liga.instancja = Liga.instancja;

                    mecz = Liga.instancja.sprawdzPoprzedniMecz();
                    mecz.wyczysc();
                }

                lRelacja.Items.Clear();
                lGospodarzNazwa.Content = mecz.gospodarz.nazwa;
                lGoscNazwa.Content = mecz.gosc.nazwa;

                minuta = 0;
                timer.Interval = new TimeSpan(0, 0, 1);
                timer.Start();
                szybkoscZwykla = true;
                bTimer.Content = "Przyspiesz";
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //lSkutecznoscRzutuKarnegoGospodarz.Content = mecz.skutecznoscRzutuKarnegoGospodarz;
            if (minuta < 90)
            {
                mecz.rozegrajAkcje(minuta);

                lMinuta.Content = minuta + 1;
                if (mecz.akcje[minuta].pilkePosiadaGospodarz == true)
                    lPilkePosiada.Content = mecz.gospodarz.nazwa;
                if (mecz.akcje[minuta].pilkePosiadaGospodarz == false)
                    lPilkePosiada.Content = mecz.gosc.nazwa;

                lGole.Content = mecz.wynik;
                lPosiadaniePilkiGospodarz.Content = mecz.posiadaniePilkiGospodarz + "%";
                lPosiadaniePilkiGosc.Content = mecz.posiadaniePilkiGosc + "%";
                //pbPosiadaniePilkiGospodarz.Value = mecz.posiadaniePilkiGospodarz;
                //pbPosiadaniePilkiGosc.Value = mecz.posiadaniePilkiGosc;
                rPosiadaniePilkiGospodarz.Width = mecz.posiadaniePilkiGospodarz * 2.5;
                rPosiadaniePilkiGosc.Width = mecz.posiadaniePilkiGosc * 2.5;
                lSkutecznoscAtakuGospodarz.Content = mecz.skutecznoscAtakuGospodarz + "%";
                lSkutecznoscAtakuGosc.Content = mecz.skutecznoscAtakuGosc + "%";
                //pbSkutecznoscAtakuGospodarz.Value = mecz.skutecznoscAtakuGospodarz;
                //pbSkutecznoscAtakuGosc.Value = mecz.skutecznoscAtakuGosc;
                rSkutecznoscAtakuGospodarz.Width = mecz.skutecznoscAtakuGospodarz * 3.5;
                rSkutecznoscAtakuGosc.Width = mecz.skutecznoscAtakuGosc * 3.5;

                //lRoznicaAtak.Content = mecz.roznicaAtakObrona;
                //lRoznicaPomoc.Content = mecz.roznicaPomoc;
                //lRoznicaObrona.Content = mecz.roznicaObronaAtak;

                lRelacja.Items.Clear();
                for (int i = 89; i >= 0; i--)
                {
                    if (mecz.akcje[i] != null)
                    {
                        if (mecz.akcje[i].komentarz != null)
                            lRelacja.Items.Add(mecz.akcje[i]);
                    }
                }

                //if (mecz.akcje[minuta].komentarz != null)
                //{
                //    lRelacja.Items.Add(mecz.akcje[minuta]);
                //}

                //CommandManager.InvalidateRequerySuggested();
                //lRelacja.Items.MoveCurrentToLast();
                //lRelacja.SelectedItem = lRelacja.Items.CurrentItem;
                //lRelacja.ScrollIntoView(lRelacja.Items.CurrentItem);

                minuta++;
                //wykonajAnimacjeStatystyk();
            }
            else
            {
                powrot.IsEnabled = true;
                timer.Stop();
            }
        }

        private void powrot_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            if (OknoTrybMenedzera.trybMenedzera == false)
                //OknoPoMeczu.instancja.Visibility = Visibility.Visible;
                OknoPrzedMeczem.instancja.Visibility = Visibility.Visible;
            if (OknoTrybMenedzera.trybMenedzera == true)
            {
                OknoTrybMenedzera.instancja.Visibility = Visibility.Visible;
                if (Liga.instancja != null)
                    Liga.instancja.uaktualnijStatystyki();
            }
        }

        private void bTimer_Click(object sender, RoutedEventArgs e)
        {
            if (szybkoscZwykla == true)
            {
                timer.Stop();
                timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
                timer.Start();
                szybkoscZwykla = false;
                bTimer.Content = "Zwolnij";
            }
            else if (szybkoscZwykla == false)
            {
                timer.Stop();
                timer.Interval = new TimeSpan(0, 0, 1);
                timer.Start();
                szybkoscZwykla = true;
                bTimer.Content = "Przyspiesz";
            }
        }

        //private void bStatystyki_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Visibility = Visibility.Hidden;
        //    Globalne.oknoPoMeczu.Visibility = Visibility.Visible;
        //}

        //void wykonajAnimacjeStatystyk()
        //{
        //    DoubleAnimation animacja = new DoubleAnimation();
        //    if (bTimer.Content.ToString() == "Przyspiesz")
        //    {
        //        animacja.From = rPosiadaniePilkiGospodarz.ActualWidth;
        //        animacja.To = mecz.posiadaniePilkiGospodarz * 2;
        //        animacja.Duration = TimeSpan.FromSeconds(0.99);
        //        rPosiadaniePilkiGospodarz.BeginAnimation(Rectangle.WidthProperty, animacja);

        //        animacja.From = rPosiadaniePilkiGosc.ActualWidth;
        //        animacja.To = mecz.posiadaniePilkiGosc * 2;
        //        animacja.Duration = TimeSpan.FromSeconds(0.99);
        //        rPosiadaniePilkiGosc.BeginAnimation(Rectangle.WidthProperty, animacja);
        //    }
        //    if (bTimer.Content.ToString() == "Zwolnij")
        //    {
        //        animacja.From = rPosiadaniePilkiGospodarz.ActualWidth;
        //        animacja.To = mecz.posiadaniePilkiGospodarz * 2;
        //        animacja.Duration = TimeSpan.FromSeconds(0.0009);
        //        rPosiadaniePilkiGospodarz.BeginAnimation(Rectangle.WidthProperty, animacja);

        //        animacja.From = rPosiadaniePilkiGosc.ActualWidth;
        //        animacja.To = mecz.posiadaniePilkiGosc * 2;
        //        animacja.Duration = TimeSpan.FromSeconds(0.0009);
        //        rPosiadaniePilkiGosc.BeginAnimation(Rectangle.WidthProperty, animacja);
        //    }
        //}
    }
}
