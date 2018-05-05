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
    /// Interaction logic for OknoTerminarzDruzyny.xaml
    /// </summary>
    public partial class OknoTerminarzDruzyny : UserControl
    {
        public static OknoTerminarzDruzyny instancja;

        public OknoTerminarzDruzyny()
        {
            InitializeComponent();
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (IsVisible == true)
            {
                lTerminarz.ItemsSource = Liga.instancja.druzynaGracza.mecze;
                lTerminarz.Items.Refresh();
            }
        }

        private void Powrot_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            OknoTrybMenedzera.instancja.Visibility = Visibility.Visible;
        }
    }
}
