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
    /// Interaction logic for TiketView.xaml
    /// </summary>
    public partial class TiketView : Window
    {
        ReturnFromDatabase returnDB = new ReturnFromDatabase();
        DeleteFromDatabase deleteDB = new DeleteFromDatabase();
        List<Tiket> tiketi = null;
        Tiket tiket = null;

        public TiketView()
        {
            InitializeComponent();
            tiketi = returnDB.GetTikete();
            dataGrid.ItemsSource = tiketi;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddTiketView view = new AddTiketView();
            this.Close();
            view.ShowDialog();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (tiket == null)
            {
                MessageBox.Show("Niste selektovali element iz tabele!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {
                int id = tiket.Id;
                int result = deleteDB.DeleteTiket(id);

                if (result == 1)
                {
                    MessageBox.Show("Doslo je do greske!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show(String.Format("Uspjesno ste obrisali tiket sa id-jem: {0}", id), "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    tiketi = returnDB.GetTikete();

                    dataGrid.ItemsSource = null;
                    dataGrid.ItemsSource = tiketi;
                }
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            EditTiketView view = new EditTiketView();

            if(tiket == null)
            {
                MessageBox.Show("Niste selektovali element iz tabele!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {
                view.textBox.Text = tiket.Id.ToString();
                view.textBox1.Text = tiket.tKv.ToString();
                view.textBox2.Text = tiket.tDob.ToString();
                view.textBox3.Text = tiket.KorisnikId.ToString();
                view.textBox4.Text = tiket.OperaterId.ToString();

                this.Close();
                view.ShowDialog();
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tiket = (Tiket)dataGrid.SelectedItem;
        }
    }
}
