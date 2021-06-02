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
    /// Interaction logic for BarmenView.xaml
    /// </summary>
    public partial class BarmenView : Window
    {
        public Barmen barmen = null;
        public List<Barmen> barmeni = null;
        public ReturnFromDatabase returnDB = new ReturnFromDatabase();
        public DeleteFromDatabase deleteDB = new DeleteFromDatabase();

        public BarmenView()
        {
            InitializeComponent();
            barmeni = returnDB.GetBarmene();
            dataGrid.ItemsSource = barmeni;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            barmen = (Barmen)dataGrid.SelectedItem;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddBarmenView view = new AddBarmenView();
            this.Close();
            view.ShowDialog();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if(barmen == null)
            {
                MessageBox.Show("Niste selektovali element iz tabele!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int result = deleteDB.DeleteBarmen(barmen.Id);
            if(result != 0)
            {
                MessageBox.Show("Doslo je do greske!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                MessageBox.Show(String.Format("Uspjesno ste obrisali radnika-barmena sa id-jem: {0}", barmen.Id), "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                barmeni = returnDB.GetBarmene();

                dataGrid.ItemsSource = null;
                dataGrid.ItemsSource = barmeni;
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            EditBarmenView view = new EditBarmenView();

            if (barmen == null)
            {
                MessageBox.Show("Niste selektovali element iz tabele!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {
                view.textBox.Text = barmen.Id.ToString();
                view.textBox1.Text = barmen.radIme;
                view.textBox2.Text = barmen.radPrz;
                view.textBox3.Text = barmen.LokalId.ToString();
                view.textBox4.Text = barmen.barSektor;

                this.Close();
                view.ShowDialog();
            }
        }
    }
}
