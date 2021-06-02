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
using Baze2.Model;

namespace Baze2
{
    /// <summary>
    /// Interaction logic for DogadjajView.xaml
    /// </summary>
    public partial class DogadjajView : Window
    {
        ReturnFromDatabase retDB = new ReturnFromDatabase();
        DeleteFromDatabase delDB = new DeleteFromDatabase();
        DogadjajModel dogadjaj = null;
        List<DogadjajModel> dogadjaji = null;

        public DogadjajView()
        {
            InitializeComponent();
            dogadjaji = retDB.GetDogadjaje();
            dataGrid.ItemsSource = dogadjaji;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddDogadjajView view = new AddDogadjajView();
            this.Close();
            view.ShowDialog();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (dogadjaj == null)
            {
                MessageBox.Show("Niste selektovali element iz tabele!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int result = delDB.DeleteDogadjaj(dogadjaj.Id);
            if (result != 0)
            {
                MessageBox.Show("Doslo je do greske!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                MessageBox.Show(String.Format("Uspjesno ste obrisali dogadjaj sa id-jem: {0}", dogadjaj.Id), "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                dogadjaji = retDB.GetDogadjaje();

                dataGrid.ItemsSource = null;
                dataGrid.ItemsSource = dogadjaji;
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            EditDogadjajView view = new EditDogadjajView();

            if(dogadjaj == null)
            {
                MessageBox.Show("Niste selektovali element iz tabele!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                view.textBox.Text = dogadjaj.Id.ToString();
                view.textBox1.Text = dogadjaj.dogKv.ToString();
                try
                {
                    view.textBox2.Text = dogadjaj.tId.ToString();
                }
                catch
                {
                    view.textBox2.Text = "123";
                }

                this.Close();
                view.ShowDialog();
            }
            

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dogadjaj = (DogadjajModel)dataGrid.SelectedItem;
        }
    }
}
