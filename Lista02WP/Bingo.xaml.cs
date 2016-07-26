using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Lista02WP
{
    public partial class Bingo : PhoneApplicationPage
    {
        public Bingo()
        {
            InitializeComponent();
        }

        private void sldQtd_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
           
        }

        private void sldQtd_LostMouseCapture(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var passo = 10;
            var meiopasso = passo / 10; //0

            var distanciafim = sldQtd.Value % passo; //76 % 10 == 6
            if (distanciafim > meiopasso) // 0.6 > 1
                distanciafim = distanciafim - passo;

            sldQtd.Value -= distanciafim;
            txtQtd.Text = sldQtd.Value.ToString();
        }
    }
}