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
    /// Interaction logic for OknoOGrze.xaml
    /// </summary>
    public partial class OknoOGrze : UserControl
    {
        public static OknoOGrze instancja;

        public OknoOGrze()
        {
            InitializeComponent();
        }

        private void Powrot_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            OknoGlowne.instancja.Visibility = Visibility.Visible;
            MainWindow.menu = "Menu";
        }
    }
}
