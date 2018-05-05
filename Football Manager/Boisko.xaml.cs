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
    /// Interaction logic for Boisko.xaml
    /// </summary>
    public partial class Boisko : UserControl
    {
        public Boisko()
        {
            InitializeComponent();
        }

        Klub druzyna;

        public void odswiez()
        {
            druzyna = Klub.wybranaDruzyna;

            if (druzyna.formacja == "5-4-1")
            {
                this.c5_4_1.Visibility = Visibility.Visible;
                this.c5_3_2.Visibility = Visibility.Hidden;
                this.c4_5_1.Visibility = Visibility.Hidden;
                this.c4_4_2.Visibility = Visibility.Hidden;
                this.c4_3_3.Visibility = Visibility.Hidden;
                this.c3_5_2.Visibility = Visibility.Hidden;
                this.c3_4_3.Visibility = Visibility.Hidden;
            }
            if (druzyna.formacja == "5-3-2")
            {
                this.c5_4_1.Visibility = Visibility.Hidden;
                this.c5_3_2.Visibility = Visibility.Visible;
                this.c4_5_1.Visibility = Visibility.Hidden;
                this.c4_4_2.Visibility = Visibility.Hidden;
                this.c4_3_3.Visibility = Visibility.Hidden;
                this.c3_5_2.Visibility = Visibility.Hidden;
                this.c3_4_3.Visibility = Visibility.Hidden;
            }
            if (druzyna.formacja == "4-5-1")
            {
                this.c5_4_1.Visibility = Visibility.Hidden;
                this.c5_3_2.Visibility = Visibility.Hidden;
                this.c4_5_1.Visibility = Visibility.Visible;
                this.c4_4_2.Visibility = Visibility.Hidden;
                this.c4_3_3.Visibility = Visibility.Hidden;
                this.c3_5_2.Visibility = Visibility.Hidden;
                this.c3_4_3.Visibility = Visibility.Hidden;
            }
            if (druzyna.formacja == "4-4-2")
            {
                this.c5_4_1.Visibility = Visibility.Hidden;
                this.c5_3_2.Visibility = Visibility.Hidden;
                this.c4_5_1.Visibility = Visibility.Hidden;
                this.c4_4_2.Visibility = Visibility.Visible;
                this.c4_3_3.Visibility = Visibility.Hidden;
                this.c3_5_2.Visibility = Visibility.Hidden;
                this.c3_4_3.Visibility = Visibility.Hidden;
            }
            if (druzyna.formacja == "4-3-3")
            {
                this.c5_4_1.Visibility = Visibility.Hidden;
                this.c5_3_2.Visibility = Visibility.Hidden;
                this.c4_5_1.Visibility = Visibility.Hidden;
                this.c4_4_2.Visibility = Visibility.Hidden;
                this.c4_3_3.Visibility = Visibility.Visible;
                this.c3_5_2.Visibility = Visibility.Hidden;
                this.c3_4_3.Visibility = Visibility.Hidden;
            }
            if (druzyna.formacja == "3-5-2")
            {
                this.c5_4_1.Visibility = Visibility.Hidden;
                this.c5_3_2.Visibility = Visibility.Hidden;
                this.c4_5_1.Visibility = Visibility.Hidden;
                this.c4_4_2.Visibility = Visibility.Hidden;
                this.c4_3_3.Visibility = Visibility.Hidden;
                this.c3_5_2.Visibility = Visibility.Visible;
                this.c3_4_3.Visibility = Visibility.Hidden;
            }
            if (druzyna.formacja == "3-4-3")
            {
                this.c5_4_1.Visibility = Visibility.Hidden;
                this.c5_3_2.Visibility = Visibility.Hidden;
                this.c4_5_1.Visibility = Visibility.Hidden;
                this.c4_4_2.Visibility = Visibility.Hidden;
                this.c4_3_3.Visibility = Visibility.Hidden;
                this.c3_5_2.Visibility = Visibility.Hidden;
                this.c3_4_3.Visibility = Visibility.Visible;
            }
            if (druzyna.ustawienie == "bardzo ofensywne")
            {
                this.c5_4_1.SetValue(Canvas.TopProperty, 10.0);
                this.c5_3_2.SetValue(Canvas.TopProperty, 10.0);
                this.c4_5_1.SetValue(Canvas.TopProperty, 10.0);
                this.c4_4_2.SetValue(Canvas.TopProperty, 10.0);
                this.c4_3_3.SetValue(Canvas.TopProperty, 10.0);
                this.c3_5_2.SetValue(Canvas.TopProperty, 10.0);
                this.c3_4_3.SetValue(Canvas.TopProperty, 10.0);
            }
            if (druzyna.ustawienie == "ofensywne")
            {
                this.c5_4_1.SetValue(Canvas.TopProperty, 5.0);
                this.c5_3_2.SetValue(Canvas.TopProperty, 5.0);
                this.c4_5_1.SetValue(Canvas.TopProperty, 5.0);
                this.c4_4_2.SetValue(Canvas.TopProperty, 5.0);
                this.c4_3_3.SetValue(Canvas.TopProperty, 5.0);
                this.c3_5_2.SetValue(Canvas.TopProperty, 5.0);
                this.c3_4_3.SetValue(Canvas.TopProperty, 5.0);
            }
            if (druzyna.ustawienie == "neutralne")
            {
                this.c5_4_1.SetValue(Canvas.TopProperty, 0.1);
                this.c5_3_2.SetValue(Canvas.TopProperty, 0.1);
                this.c4_5_1.SetValue(Canvas.TopProperty, 0.1);
                this.c4_4_2.SetValue(Canvas.TopProperty, 0.1);
                this.c4_3_3.SetValue(Canvas.TopProperty, 0.1);
                this.c3_5_2.SetValue(Canvas.TopProperty, 0.1);
                this.c3_4_3.SetValue(Canvas.TopProperty, 0.1);
            }
            if (druzyna.ustawienie == "defensywne")
            {
                this.c5_4_1.SetValue(Canvas.TopProperty, -5.0);
                this.c5_3_2.SetValue(Canvas.TopProperty, -5.0);
                this.c4_5_1.SetValue(Canvas.TopProperty, -5.0);
                this.c4_4_2.SetValue(Canvas.TopProperty, -5.0);
                this.c4_3_3.SetValue(Canvas.TopProperty, -5.0);
                this.c3_5_2.SetValue(Canvas.TopProperty, -5.0);
                this.c3_4_3.SetValue(Canvas.TopProperty, -5.0);
            }
            if (druzyna.ustawienie == "bardzo defensywne")
            {
                this.c5_4_1.SetValue(Canvas.TopProperty, -10.0);
                this.c5_3_2.SetValue(Canvas.TopProperty, -10.0);
                this.c4_5_1.SetValue(Canvas.TopProperty, -10.0);
                this.c4_4_2.SetValue(Canvas.TopProperty, -10.0);
                this.c4_3_3.SetValue(Canvas.TopProperty, -10.0);
                this.c3_5_2.SetValue(Canvas.TopProperty, -10.0);
                this.c3_4_3.SetValue(Canvas.TopProperty, -10.0);
            }
        }
    }
}
