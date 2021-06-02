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
    /// Interaction logic for EditBarmenView.xaml
    /// </summary>
    public partial class EditBarmenView : Window
    {
        public EditInDatabase editDB = new EditInDatabase();

        public EditBarmenView()
        {
            InitializeComponent();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox.Text);
                string ime = textBox1.Text;
                string prezime = textBox2.Text;
                int localId = Convert.ToInt32(textBox3.Text);
                string brsektor = textBox4.Text;

                bool result = editDB.EditBarmen(id, ime, prezime, localId, brsektor);

                
                 if (result == false)
                     MessageBox.Show("Doslo je do greske ili ste unijeli id lokala koji ne postoji!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                 else
                     MessageBox.Show(String.Format("Uspjesto ste izmjenili radnika-barmena sa id-jem: {0}", id), "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch
            {
                MessageBox.Show("Nevalidan unos!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            BarmenView view = new BarmenView();
            this.Close();
            view.ShowDialog();
        }
    }
}
