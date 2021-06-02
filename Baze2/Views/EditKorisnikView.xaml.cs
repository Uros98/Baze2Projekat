using Baze2.Data_Access;
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

namespace Baze2
{
    /// <summary>
    /// Interaction logic for EditKorisnikView.xaml
    /// </summary>
    public partial class EditKorisnikView : Window
    {
        EditInDatabase editDB = new EditInDatabase();

        public EditKorisnikView()
        {
            InitializeComponent();
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            KorisnikView view = new KorisnikView();
            this.Close();
            view.ShowDialog();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox.Text);
                string ime = textBox1.Text;
                string prezime = textBox2.Text;

                bool result = editDB.EditKorisnik(id, ime, prezime);

                if (result == false)
                    MessageBox.Show("Doslo je do greske!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                    MessageBox.Show(String.Format("Uspjesto ste izmjenili korisnika sa id-jem: {0}", id), "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Nevalidan unos!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
