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
    /// Interaction logic for LokaliView.xaml
    /// </summary>
    public partial class LokaliView : Window
    {
        public List<Lokal> lokali = null;

        public Lokal lokal = null;

        public ReturnFromDatabase returnDB = new ReturnFromDatabase();
        public DeleteFromDatabase deleteDB = new DeleteFromDatabase();

        public LokaliView()
        {
            InitializeComponent();
            lokali = returnDB.GetLokale();
            dataGrid.ItemsSource = lokali;

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddLokalView view = new AddLokalView();
            this.Close();
            view.ShowDialog();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if(lokal == null)
            {
                MessageBox.Show("Niste selektovali element iz tabele!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {
                int id = lokal.Id;
                int result = deleteDB.DeleteLokal(id);

                if(result == 1)
                {
                    MessageBox.Show("Doslo je do greske1", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show(String.Format("Uspjesno ste obrisali lokal sa id-jem: {0}", id), "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    lokali = returnDB.GetLokale();

                    dataGrid.ItemsSource = null;
                    dataGrid.ItemsSource = lokali;
                }
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            EditLokalView view = new EditLokalView();

            if(lokal == null)
            {
                MessageBox.Show("Niste selektovali element iz tabele!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {
                view.textBox.Text = lokal.Id.ToString();
                view.textBox1.Text = lokal.lokNaz;
                view.textBox2.Text = lokal.lokGr;
                view.textBox3.Text = lokal.lokUl;
                view.textBox4.Text = lokal.lokBr.ToString();

                this.Close();
                view.ShowDialog();
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lokal = (Lokal)dataGrid.SelectedItem;
        }
    }
}
