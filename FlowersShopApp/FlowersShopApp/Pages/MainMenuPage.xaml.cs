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
    /// Interaction logic for MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        public MainMenuPage()
        {
            InitializeComponent();
            TBTitle.Text = $"Welcome, {MainWindow.loggedUser.Login}!";
            if(MainWindow.loggedUser.RoleId == 1)
            {
                BOrderHistoryList.Visibility = Visibility.Visible;
                BBouquetList.Visibility = Visibility.Visible;
            }
            if (MainWindow.loggedUser.RoleId == 2)
            {
                BFlowersList.Visibility = Visibility.Visible;
                BPackageList.Visibility = Visibility.Visible;
                BOrderHistoryList.Visibility = Visibility.Visible;
                BBouquetList.Visibility = Visibility.Visible;
            }
        }

        private void BBouquetList_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.BouquetListPage());
        }

        private void BOrderHistoryList_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.OrderHistoryPage());
        }

        private void BFlowersList_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.FlowersListPage());
        }

        private void BPackageList_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.PackageListPage());
        }

        private void BExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
