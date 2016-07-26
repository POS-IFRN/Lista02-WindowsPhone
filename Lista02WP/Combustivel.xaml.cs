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
    public partial class Combustivel : PhoneApplicationPage
    {
        public Combustivel()
        {
            InitializeComponent();
        }

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            double qtdLitros = double.Parse(txtVP.Text) / double.Parse(txtVL.Text);
            txtKML.Text = (double.Parse(txtKm.Text) / qtdLitros).ToString();
            txtRSKM.Text = (double.Parse(txtVP.Text) / double.Parse(txtKm.Text)).ToString();
        }
    }
}