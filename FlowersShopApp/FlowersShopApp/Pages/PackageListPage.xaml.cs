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
    /// Interaction logic for PackageListPage.xaml
    /// </summary>
    public partial class PackageListPage : Page
    {
        public PackageListPage()
        {
            InitializeComponent();
            Refresh();
        }
        private void Refresh()
        {
            LVPackage.ItemsSource = null;
            LVPackage.ItemsSource = MainWindow.db.Package.ToList();
        }
        private bool Validation()
        {
            if (LVPackage.SelectedItem == null)
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
            Windows.AddEditPackageWindow addEditPackageWindow = new Windows.AddEditPackageWindow(new Model.Package());
            addEditPackageWindow.ShowDialog();
            Refresh();
        }

        private void BEdit_Click(object sender, RoutedEventArgs e)
        {
            if (!Validation()) return;
            Windows.AddEditPackageWindow addEditPackageWindow = new Windows.AddEditPackageWindow((Model.Package)LVPackage.SelectedItem);
            addEditPackageWindow.ShowDialog();
            Refresh();
        }

        private void BDelete_Click(object sender, RoutedEventArgs e)
        {
            if (!Validation()) return;
            MainWindow.db.Package.Remove((Model.Package)LVPackage.SelectedItem);
            MainWindow.db.SaveChanges();
            Refresh();
        }
    }
}
