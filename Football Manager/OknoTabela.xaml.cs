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
    /// Interaction logic for OknoTabela.xaml
    /// </summary>
    public partial class OknoTabela : UserControl
    {
        public static OknoTabela instancja;

        public OknoTabela()
        {
            InitializeComponent();
        }

        Tabela tabelaLigowa;

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (IsVisible == true)
            {
                tabelaLigowa = Liga.instancja.tabelaLigowa;
                tabelaLigowa.sortuj();
                lTabela.ItemsSource = tabelaLigowa.kluby;
                lTabela.Items.Refresh();
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
    }
}
