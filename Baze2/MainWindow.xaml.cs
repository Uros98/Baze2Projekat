using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Baze2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LokalButton_Click(object sender, RoutedEventArgs e)
        {
            LokaliView view = new LokaliView();
            view.ShowDialog();
        }

        private void RadnikButton_Click(object sender, RoutedEventArgs e)
        {
            RadniciView view = new RadniciView();
            view.ShowDialog();
        }

        private void BarmenButton_Click(object sender, RoutedEventArgs e)
        {
            BarmenView view = new BarmenView();
            view.ShowDialog();
        }

        private void OperaterButton_Click(object sender, RoutedEventArgs e)
        {
            OperaterView view = new OperaterView();
            view.ShowDialog();
        }

        private void KorisnikButton_Click(object sender, RoutedEventArgs e)
        {
            KorisnikView view = new KorisnikView();
            view.ShowDialog();
        }

        private void TiketButton_Click(object sender, RoutedEventArgs e)
        {
            TiketView view = new TiketView();
            view.ShowDialog();
        }

        private void PiceButton_Click(object sender, RoutedEventArgs e)
        {
            PiceView view = new PiceView();
            view.ShowDialog();
        }

        private void DogadjajButton_Click(object sender, RoutedEventArgs e)
        {
            DogadjajView view = new DogadjajView();
            view.ShowDialog();
        }
    }
}
