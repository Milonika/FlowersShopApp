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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlowersShopApp.Pages
{
    /// <summary>
    /// Interaction logic for FlowersListPage.xaml
    /// </summary>
    public partial class FlowersListPage : Page
    {
        public FlowersListPage()
        {
            InitializeComponent();
            Refresh();
        }
        private void Refresh()
        {
            LVFlower.ItemsSource = null;
            LVFlower.ItemsSource = MainWindow.db.Flower.ToList();
        }
        private bool Validation()
        {
            if(LVFlower.SelectedItem == null)
            {
                MessageBox.Show("Select Item");
                return false;
            }
            return true;
        }
        private void BBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BAdd_Click(object sender, RoutedEventArgs e)
        {
            Windows.AddEditFlowerWindow addEditFlowerWindow = new Windows.AddEditFlowerWindow(new Model.Flower());
            addEditFlowerWindow.ShowDialog();
            Refresh();
        }

        private void BEdit_Click(object sender, RoutedEventArgs e)
        {
            if (!Validation()) return;
            Windows.AddEditFlowerWindow addEditFlowerWindow = new Windows.AddEditFlowerWindow((Model.Flower)LVFlower.SelectedItem);
            addEditFlowerWindow.ShowDialog();
            Refresh();
        }

        private void BDelete_Click(object sender, RoutedEventArgs e)
        {
            if (!Validation()) return;
            MainWindow.db.Flower.Remove((Model.Flower)LVFlower.SelectedItem);
            MainWindow.db.SaveChanges();
            Refresh();
        }
    }
}
