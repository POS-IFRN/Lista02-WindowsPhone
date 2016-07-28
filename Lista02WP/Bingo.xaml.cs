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
        bool firsttime;
        bool[] sorteados;
        int qtd;
        Random r;
        public Bingo()
        {
            InitializeComponent();
            firsttime = true;
            r = new Random();
        }

        private void sldQtd_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
           if (sldQtd!= null)
            {
                txtQtd.Text = (Convert.ToInt16(sldQtd.Value) * 10).ToString();
            }
        }

        private void sldQtd_LostMouseCapture(object sender, System.Windows.Input.MouseEventArgs e)
        {
           // var passo = 10;
           // var meiopasso = passo / 10; //1

            //var distanciafim = sldQtd.Value % passo; //76 % 10 == 0.6
            //if (distanciafim > meiopasso) // 0.6 > 1
              //  distanciafim = distanciafim - passo;

            //sldQtd.Value -= distanciafim;
            //txtQtd.Text = sldQtd.Value.ToString();
        }

        private void btnSortear_Click(object sender, RoutedEventArgs e)
        {
            if (firsttime)
            {
                sorteados = populateBoolArray(int.Parse(txtQtd.Text));
                firsttime = false;
                populateLstBox();
            }

            if (qtd != sorteados.Length) insertRandom();
            else MessageBox.Show("Você já sorteou todos os números, reinicie o programa!");
            


        }

        private bool[] populateBoolArray(int length)
        {
            bool[] arr = new bool[length];
            for (int i = 0; i < length; i++)
            {
                arr[i] = false;
            }
            return arr;
        }

        private void insertRandom()
        {
            int value = r.Next(0, sorteados.Length);
            if (!sorteados[value])
            {
                qtd++;
                sorteados[value] = true;
                makeVisible(value);
            }
            else insertRandom();
        }

        private void makeVisible(int index)
        {
            StackPanel control = (StackPanel)FindName("stk0");
            if (index > 9)
            {
                control = (StackPanel)FindName("stk" + (index / 10).ToString());
            }
            foreach (FrameworkElement child in control.Children)
                if (child.Name == index.ToString()) child.Opacity = 100;
        }
        private void populateLstBox()
        {
            
            ListBoxItem coluna;
            StackPanel control = (StackPanel)FindName("stk0");
            int width = Convert.ToInt16(control.Width) / 10;
            for (int i = 0; i < sorteados.Length; i++)
            {
                
                if (i % 10 == 0 && i != 0)
                {
                    control = (StackPanel)FindName("stk" + (i / 10).ToString());
                }
                coluna = new ListBoxItem();
                coluna.Content = coluna.Name = i.ToString();
                coluna.Width = width;
                coluna.HorizontalAlignment = HorizontalAlignment.Center;
                coluna.FontWeight = FontWeights.Bold;
                coluna.Opacity = 0;
                control.Children.Add(coluna);
            }
            

        }

        private void btnNG_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.GoBack();

            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));

        }
    }
}