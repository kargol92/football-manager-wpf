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
    /// Interaction logic for OknoOpcje.xaml
    /// </summary>
    public partial class OknoOpcje : UserControl
    {
        public static OknoOpcje instancja;

        public OknoOpcje()
        {
            InitializeComponent();
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void powrot_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            OknoGlowne.instancja.Visibility = Visibility.Visible;
        }

        private void rbMale_Checked(object sender, RoutedEventArgs e)
        {
            MainWindow.instancja.Height = 450;
            MainWindow.instancja.Width = 600;
        }

        private void rbSrednie_Checked(object sender, RoutedEventArgs e)
        {
            MainWindow.instancja.Height = 600;
            MainWindow.instancja.Width = 800;
        }

        private void rbDuze_Checked(object sender, RoutedEventArgs e)
        {
            MainWindow.instancja.Height = 750;
            MainWindow.instancja.Width = 1000;
        }

    }
}
