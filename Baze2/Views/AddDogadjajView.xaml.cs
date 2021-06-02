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
    /// Interaction logic for AddDogadjajView.xaml
    /// </summary>
    public partial class AddDogadjajView : Window
    {
        AddInDatabase addDB = new AddInDatabase();

        public AddDogadjajView()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox.Text);
                double kvota = Convert.ToDouble(textBox1.Text);
                int tId = Convert.ToInt32(textBox2.Text);

                int result = addDB.AddDogadjaj(id,kvota,tId);

                if(result == 2)
                {
                    textBox2.Background = Brushes.Red;
                    MessageBox.Show(String.Format("Ne postoji tiket sa id-jem: {0}", tId), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if(result == 1)
                {
                    MessageBox.Show("Doslo je do greske!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show(String.Format("Uspjesno ste dodali dogadjaj sa id-jem: {0}", id), "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                }
            }
            catch
            {
                MessageBox.Show("Nevalidan unos!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

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
