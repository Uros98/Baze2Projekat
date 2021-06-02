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
    /// Interaction logic for PiceView.xaml
    /// </summary>
    public partial class PiceView : Window
    {
        ReturnFromDatabase returnDB = new ReturnFromDatabase();
        DeleteFromDatabase deleteDB = new DeleteFromDatabase();
        List<Pice> pica = null;
        Pice pice = null;

        public PiceView()
        {
            InitializeComponent();
            pica = returnDB.GetPica();
            dataGrid.ItemsSource = pica;

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddPiceView view = new AddPiceView();
            this.Close();
            view.ShowDialog();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (pice == null)
            {
                MessageBox.Show("Niste selektovali element iz tabele!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {
                int id = pice.Id;
                int result = deleteDB.DeletePice(id);

                if (result == 1)
                {
                    MessageBox.Show("Doslo je do greske!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show(String.Format("Uspjesno ste obrisali pice sa id-jem: {0}", id), "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    pica = returnDB.GetPica();

                    dataGrid.ItemsSource = null;
                    dataGrid.ItemsSource = pica;
                }
            }
            }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            EditPiceView view = new EditPiceView();

            if(pice == null)
            {
                MessageBox.Show("Niste selektovali element iz tabele!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {
                view.textBox.Text = pice.Id.ToString();
                view.textBox1.Text = pice.piceNaz;

                this.Close();
                view.ShowDialog();
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pice = (Pice)dataGrid.SelectedItem;
        }
    }
}
