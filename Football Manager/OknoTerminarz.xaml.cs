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
    /// Interaction logic for OknoTerminarz.xaml
    /// </summary>
    public partial class OknoTerminarz : UserControl
    {
        public static OknoTerminarz instancja;

        public OknoTerminarz()
        {
            InitializeComponent();
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (IsVisible == true)
            {
                cbListaKolejek.ItemsSource = Liga.instancja.kolejki;
                cbListaKolejek.SelectedItem = Liga.instancja.kolejki[0];

                lTerminarz.ItemsSource = Liga.instancja.kolejki[0].mecze;
                lTerminarz.Items.Refresh();
            }
        }

        private void cbListaKolejek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            for (int i = 0; i < 30; i++)
            {
                if (cbListaKolejek.SelectedIndex == i)
                {
                    lTerminarz.ItemsSource = Liga.instancja.kolejki[i].mecze;
                    lTerminarz.Items.Refresh();
                }
            }
        }

        private void Powrot_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            OknoTrybMenedzera.instancja.Visibility = Visibility.Visible;
        }
    }
}
