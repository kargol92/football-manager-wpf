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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow instancja;
        public static string menu;

        public MainWindow()
        {
            InitializeComponent();

            //BazaDanych.instancja = new BazaDanych();

            menu = "Menu >>";
            lMenu.Content = menu;
            instancja = this;
            OknoGlowne.instancja = oknoGlowne;
            OknoMeczTowarzyski.instancja = oknoMeczTowarzyski;
            OknoDruzynyTrybMenedzera.instancja = oknoDruzynyTrybMenedzera;
            OknoTrybMenedzera.instancja = oknoTrybMenedzera;
            OknoOGrze.instancja = oknoOGrze;

            OknoSklad.instancja = oknoSklad;
            OknoTaktyka.instancja = oknoTaktyka;
            OknoTabela.instancja = oknoTabela;
            OknoTerminarz.instancja = oknoTerminarz;
            OknoTerminarzDruzyny.instancja = oknoTerminarzDruzyny;
            OknoPrzedMeczem.instancja = oknoPrzedMeczem;
            OknoMecz.instancja = oknoMecz;
            OknoPoMeczu.instancja = oknoPoMeczu;
        }

        private void bPowrot_Click(object sender, RoutedEventArgs e)
        {
            switch (menu)
            {
                case "Menu >>": App.Current.Shutdown(); break;
                case "Menu >> Mecz towarzyski": App.Current.Shutdown(); break;
                default: MessageBox.Show("Błąd"); break;
            }

            if (menu == "Menu >>")
                App.Current.Shutdown();
        }
    }
}
