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
using System.Windows.Shapes;
using Baze2.Data_Access;

namespace Baze2
{
    /// <summary>
    /// Interaction logic for KorisnikView.xaml
    /// </summary>
    public partial class KorisnikView : Window
    {
        ReturnFromDatabase returnDB = new ReturnFromDatabase();
        DeleteFromDatabase deleteDB = new DeleteFromDatabase();
        List<Korisnik> korisnici = null;
        Korisnik korisnik = null;

        public KorisnikView()
        {
            InitializeComponent();
            korisnici = returnDB.GetKorisnike();
            dataGrid.ItemsSource = korisnici;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddKorisnikView view = new AddKorisnikView();
            this.Close();
            view.ShowDialog();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (korisnik == null)
            {
                MessageBox.Show("Niste selektovali element iz tabele!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {
                int id = korisnik.Id;
                int result = deleteDB.DeleteKorisnik(id);

                if (result == 1)
                {
                    MessageBox.Show("Doslo je do greske!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show(String.Format("Uspjesno ste obrisali korisnika sa id-jem: {0}", id), "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    korisnici = returnDB.GetKorisnike();

                    dataGrid.ItemsSource = null;
                    dataGrid.ItemsSource = korisnici;
                }
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            EditKorisnikView view = new EditKorisnikView();
            if (korisnik == null)
            {
                MessageBox.Show("Niste selektovali element iz tabele!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {
                view.textBox.Text = korisnik.Id.ToString();
                view.textBox1.Text = korisnik.kIme;
                view.textBox2.Text = korisnik.kPrz;

                this.Close();
                view.ShowDialog();
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            korisnik = (Korisnik)dataGrid.SelectedItem;
        }
    }
}
