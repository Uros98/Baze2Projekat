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
    /// Interaction logic for EditDogadjajView.xaml
    /// </summary>
    public partial class EditDogadjajView : Window
    {
        public EditInDatabase editDB = new EditInDatabase();

        public EditDogadjajView()
        {
            InitializeComponent();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox.Text);
                double kvota = Convert.ToDouble(textBox1.Text);
                int tId = Convert.ToInt32(textBox2.Text);

                bool result = editDB.EditDogadjaj(id, kvota, tId);

                if (result == false)
                    MessageBox.Show("Doslo je do greske ili ste unijeli id tiketa koji ne postoji!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                    MessageBox.Show(String.Format("Uspjesto ste izmjenili dogadjaj sa id-jem: {0}", id), "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Nevalidan unos!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            DogadjajView view = new DogadjajView();
            this.Close();
            view.ShowDialog();
        }
    }
}
