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
    /// Interaction logic for AddLokalView.xaml
    /// </summary>
    public partial class AddLokalView : Window
    {
        public AddInDatabase addDB = new AddInDatabase();

        public AddLokalView()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                int id = Convert.ToInt32(textBox.Text);
                string naziv = textBox1.Text;
                string grad = textBox2.Text;
                string ulica = textBox3.Text;
                int broj = Convert.ToInt32(textBox4.Text);
                int result = addDB.AddLokal(id, naziv, grad, ulica, broj);


                if (result == 2)
                {
                    textBox.Background = Brushes.Red;
                    MessageBox.Show(String.Format("Vec postoji lokal sa id-jem: {0}", id), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (result == 1)
                {
                    MessageBox.Show("Doslo je do greske!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show(String.Format("Uspjesno ste dodali lokal sa id-jem: {0}", id), "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch
            {
                MessageBox.Show("Nevalidan unos!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            LokaliView view = new LokaliView();
            this.Close();
            view.ShowDialog();
        }
    }
}
