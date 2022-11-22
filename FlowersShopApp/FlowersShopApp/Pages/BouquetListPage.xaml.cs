using FlowersShopApp.Model;
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
    /// Interaction logic for BouquetListPage.xaml
    /// </summary>
    public partial class BouquetListPage : Page
    {
        public BouquetListPage()
        {
            InitializeComponent();
            if(MainWindow.loggedUser.RoleId == 1)
            {
                BAdd.Visibility = Visibility.Collapsed;
                BEdit.Visibility = Visibility.Collapsed;
                BDelete.Visibility = Visibility.Collapsed;
            }
            Refresh();
        }
        private void Refresh()
        {
            LVBouquet.ItemsSource = null;
            LVBouquet.ItemsSource = MainWindow.db.Bouquet.ToList();
        }
        private bool Validation()
        {
            if (LVBouquet.SelectedItem == null)
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
            Windows.AddEditBouquetWindow addEditBouquetWindow = new Windows.AddEditBouquetWindow(new Model.Bouquet());
            addEditBouquetWindow.ShowDialog();
            Refresh();
        }

        private void BEdit_Click(object sender, RoutedEventArgs e)
        {
            if (!Validation()) return;
            Windows.AddEditBouquetWindow addEditBouquetWindow = new Windows.AddEditBouquetWindow((Model.Bouquet)LVBouquet.SelectedItem);
            addEditBouquetWindow.ShowDialog();
            Refresh();
        }

        private void BDelete_Click(object sender, RoutedEventArgs e)
        {
            if (!Validation()) return;
            MainWindow.db.Bouquet.Remove((Model.Bouquet)LVBouquet.SelectedItem);
            MainWindow.db.SaveChanges();
            Refresh();
        }

        private void BBuy_Click(object sender, RoutedEventArgs e)
        {
            if (!Validation()) return;
            Model.OrderHistory orderHistory = new OrderHistory();
            orderHistory.BouquetId = ((Model.Bouquet)LVBouquet.SelectedItem).Id;
            orderHistory.UserId = MainWindow.loggedUser.Id;
            orderHistory.Date = DateTime.Now;
            MainWindow.db.OrderHistory.Add(orderHistory);
            MainWindow.db.SaveChanges();
            MessageBox.Show($"You make order\nBouquet: {orderHistory.Bouquet.Name}\nCost: {orderHistory.Bouquet.Cost}\nDate: {DateTime.Now}");
        }
    }
}
