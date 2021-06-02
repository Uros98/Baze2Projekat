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
    /// Interaction logic for AddOperaterView.xaml
    /// </summary>
    public partial class AddOperaterView : Window
    {
        AddInDatabase addDB = new AddInDatabase();

        public AddOperaterView()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox.Text);
                string ime = textBox1.Text;
                string prezime = textBox2.Text;
                int idLokala = Convert.ToInt32(textBox3.Text);
                string opRacunar = textBox4.Text;

                int result = addDB.AddOperater(id, ime, prezime, idLokala, opRacunar);

                if (result == 3)
                {
                    textBox3.Background = Brushes.Red;
                    MessageBox.Show(String.Format("Ne postoji lokal sa id-jem: {0}", idLokala), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (result == 2)
                {
                    textBox.Background = Brushes.Red;
                    MessageBox.Show(String.Format("Vec postoji radnik sa id-jem: {0}", id), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (result == 1)
                {
                    MessageBox.Show("Doslo je do greske!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show(String.Format("Uspjesno ste dodali radnika-operatera sa id-jem: {0}", id), "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch
            {
                MessageBox.Show("Nevalidan unos!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            OperaterView view = new OperaterView();
            this.Close();
            view.ShowDialog();
        }
    }
}
