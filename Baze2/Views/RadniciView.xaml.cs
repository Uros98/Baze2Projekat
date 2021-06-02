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
    /// Interaction logic for RadniciView.xaml
    /// </summary>
    public partial class RadniciView : Window
    {
        public ReturnFromDatabase returnDB = new ReturnFromDatabase();
        public List<Radnik> radnici = new List<Radnik>();

        public RadniciView()
        {
            InitializeComponent();
            radnici = returnDB.GetRadnike();
            dataGrid.ItemsSource = radnici;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
