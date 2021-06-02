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
    /// Interaction logic for OperaterView.xaml
    /// </summary>
    public partial class OperaterView : Window
    {
        public Operater operater = null;
        public List<Operater> operateri = null;
        public ReturnFromDatabase returnDB = new ReturnFromDatabase();
        public DeleteFromDatabase deleteDB = new DeleteFromDatabase();

        public OperaterView()
        {
            InitializeComponent();
            operateri = returnDB.GetOperatere();
            dataGrid.ItemsSource = operateri;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            operater = (Operater)dataGrid.SelectedItem;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddOperaterView view = new AddOperaterView();
            this.Close();
            view.ShowDialog();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (operater == null)
            {
                MessageBox.Show("Niste selektovali element iz tabele!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int result = deleteDB.DeleteOperater(operater.Id);
            if (result != 0)
            {
                MessageBox.Show("Doslo je do greske!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                MessageBox.Show(String.Format("Uspjesno ste obrisali radnika-barmena sa id-jem: {0}", operater.Id), "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                operateri = returnDB.GetOperatere();

                dataGrid.ItemsSource = null;
                dataGrid.ItemsSource = operateri;
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            EditOperaterView view = new EditOperaterView();

            if (operater == null)
            {
                MessageBox.Show("Niste selektovali element iz tabele!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {
                view.textBox.Text = operater.Id.ToString();
                view.textBox1.Text = operater.radIme;
                view.textBox2.Text = operater.radPrz;
                view.textBox3.Text = operater.LokalId.ToString();
                view.textBox4.Text = operater.opRacunar;

                this.Close();
                view.ShowDialog();
            }
        }
    }
}
