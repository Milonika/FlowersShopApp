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
    /// Interaction logic for OrderHistoryPage.xaml
    /// </summary>
    public partial class OrderHistoryPage : Page
    {
        public OrderHistoryPage()
        {
            InitializeComponent();
            if (MainWindow.loggedUser.RoleId == 1)
                DGOrderHistory.ItemsSource = MainWindow.db.OrderHistory.Where(c => c.UserId == MainWindow.loggedUser.Id).ToList();
            if (MainWindow.loggedUser.RoleId == 2)
                DGOrderHistory.ItemsSource = MainWindow.db.OrderHistory.ToList();
        }

        private void BBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
