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
    /// Interaction logic for AddTiketView.xaml
    /// </summary>
    public partial class AddTiketView : Window
    {
        AddInDatabase AddDB = new AddInDatabase();

        public AddTiketView()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox.Text);
                double kvota = Convert.ToDouble(textBox1.Text);
                double dobitak = Convert.ToDouble(textBox2.Text);
                int kId = Convert.ToInt32(textBox3.Text);
                int oId = Convert.ToInt32(textBox4.Text);

                int result = AddDB.AddTiket(id, kvota, dobitak, kId, oId);

                if (result == 4)
                {
                    textBox3.Background = Brushes.Red;
                    MessageBox.Show("Ne postoji korisnik sa tim id-jem", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }else if(result == 3)
                {
                    textBox4.Background = Brushes.Red;
                    MessageBox.Show("Ne postoji operator sa tim id-jem", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }else if(result == 2)
                {
                    textBox.Background = Brushes.Red;
                    MessageBox.Show(String.Format("Vec postoji tiket sa id-jem: {0}", id), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }else if(result == 1)
                {
                    MessageBox.Show("Doslo je do greske!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                else
                {
                    MessageBox.Show(String.Format("Uspjesno ste dodali tiket sa id-jem: {0}", id), "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                }
            }
            catch
            {
                MessageBox.Show("Nevalidan unos!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            TiketView view = new TiketView();
            this.Close();
            view.ShowDialog();
        }
    }
}
