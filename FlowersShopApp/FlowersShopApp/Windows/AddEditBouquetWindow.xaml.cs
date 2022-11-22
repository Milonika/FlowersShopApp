using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace FlowersShopApp.Windows
{
    /// <summary>
    /// Interaction logic for AddEditBouquetWindow.xaml
    /// </summary>
    public partial class AddEditBouquetWindow : Window
    {
        Model.Bouquet postBouquet;
        public AddEditBouquetWindow(Model.Bouquet bouquet)
        {
            InitializeComponent();
            DGPackage.ItemsSource = MainWindow.db.Package.ToList();
            
            postBouquet = bouquet;
            this.DataContext = postBouquet;
            if(postBouquet.Id != 0)
            {
                bouquetFlowers = MainWindow.db.BouquetFlower.Where(c => c.BouquetId == postBouquet.Id).ToList();
                Refresh();
            }
            
        }
        List<Model.BouquetFlower> bouquetFlowers = new List<Model.BouquetFlower>();
        private void BAddFlower_Click(object sender, RoutedEventArgs e)
        {
            Model.BouquetFlower bouquetFlower = (Model.BouquetFlower)((Button)sender).DataContext;
            bouquetFlower.Quantity++;
            Refresh();
        }

        private void BMinusFlower_Click(object sender, RoutedEventArgs e)
        {
            Model.BouquetFlower bouquetFlower = (Model.BouquetFlower)((Button)sender).DataContext;
            if (bouquetFlower.Quantity == 1)
                return;
            bouquetFlower.Quantity--;
            Refresh();
        }

        private void BChangePicture_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                postBouquet.Picture = File.ReadAllBytes(openFileDialog.FileName);
                MemoryStream byteStream = new MemoryStream(postBouquet.Picture);
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = byteStream;
                image.EndInit();
                IPicture.Source = image;
            }
        }

        private void BSave_Click(object sender, RoutedEventArgs e)
        {
            if(DGPackage.SelectedItem == null)
            {
                MessageBox.Show("Select Package");
                return;
            }
            if(postBouquet.Id != 0)
            {
                foreach(var b in bouquetFlowers)
                {
                    if(MainWindow.db.BouquetFlower.FirstOrDefault(c=>c.BouquetId == postBouquet.Id && c.FlowerId == b.FlowerId) == null)
                    {
                        MainWindow.db.BouquetFlower.Add(b);
                        MainWindow.db.SaveChanges();
                    }
                }
                MainWindow.db.SaveChanges();
            }
            if(postBouquet.Id == 0)
            {
                MainWindow.db.Bouquet.Add(postBouquet);
                foreach (var c in bouquetFlowers)
                {
                    MainWindow.db.BouquetFlower.Add(c);
                    MainWindow.db.SaveChanges();
                }
            }
            this.Close();
        }

        private void BAddNewFlower_Click(object sender, RoutedEventArgs e)
        {
            Windows.FlowersListWindow flowersListWindow = new FlowersListWindow();
            flowersListWindow.ShowDialog();
            if ((Model.Flower)flowersListWindow.DGFlower.SelectedItem == null)
                return;
            if (bouquetFlowers.Select(c=>c.Flower).Contains((Model.Flower)flowersListWindow.DGFlower.SelectedItem))
                return;
            Model.BouquetFlower bouquetFlower = new Model.BouquetFlower();
            bouquetFlower.BouquetId = postBouquet.Id;
            bouquetFlower.FlowerId = ((Model.Flower)flowersListWindow.DGFlower.SelectedItem).Id;
            bouquetFlower.Flower = (Model.Flower)flowersListWindow.DGFlower.SelectedItem;
            bouquetFlower.Quantity = 1;
            bouquetFlowers.Add(bouquetFlower);
            Refresh();
        }
        private void Refresh()
        {
            DGFlowers.ItemsSource = null;
            DGFlowers.ItemsSource = bouquetFlowers;
            double cost = 0;
            foreach (var c in bouquetFlowers)
            {
                cost += c.TotalCost;
            }
            if(DGPackage.SelectedItem != null)
                cost += ((Model.Package)DGPackage.SelectedItem).Cost;
            postBouquet.Cost = cost;
            TBCost.Text = postBouquet.Cost.ToString();
        }

        private void DGPackage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
    }
}
