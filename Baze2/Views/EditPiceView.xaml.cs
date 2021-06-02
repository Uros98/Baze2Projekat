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
    /// Interaction logic for EditPiceView.xaml
    /// </summary>
    public partial class EditPiceView : Window
    {
        public EditInDatabase editDB = new EditInDatabase();

        public EditPiceView()
        {
            InitializeComponent();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try {
                int id = Convert.ToInt32(textBox.Text);
                string naziv = textBox1.Text;

                bool result = editDB.EditPice(id,naziv);
                if (result == false)
                    MessageBox.Show("Doslo je do greske!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                    MessageBox.Show(String.Format("Uspjesto ste izmjenili pice sa id-jem: {0}", id), "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                catch
                {
                    MessageBox.Show("Nevalidan unos!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            PiceView view = new PiceView();
            this.Close();
            view.ShowDialog();
        }
    }
}
