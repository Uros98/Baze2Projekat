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
    /// Interaction logic for EditTiketView.xaml
    /// </summary>
    public partial class EditTiketView : Window
    {
        EditInDatabase editDB = new EditInDatabase();

        public EditTiketView()
        {
            InitializeComponent();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox.Text);
                double kvota = Convert.ToDouble(textBox1.Text);
                double dobitak = Convert.ToDouble(textBox2.Text);
                int kID = Convert.ToInt32(textBox3.Text);
                int oID = Convert.ToInt32(textBox4.Text);

                bool result = editDB.EditTiket(id, kvota, dobitak, kID, oID);

                if(result == false)
                {
                    MessageBox.Show("Doslo je do greske!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                else
                {
                    MessageBox.Show(String.Format("Uspjesto ste izmjenili tiket sa id-jem: {0}", id), "Success", MessageBoxButton.OK, MessageBoxImage.Information);

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
