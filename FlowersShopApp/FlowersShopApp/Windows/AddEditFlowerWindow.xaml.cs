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
    /// Interaction logic for AddEditFlowerWindow.xaml
    /// </summary>
    public partial class AddEditFlowerWindow : Window
    {
        Model.Flower postFlower;
        public AddEditFlowerWindow(Model.Flower flower)
        {
            InitializeComponent();
            postFlower = flower;
            this.DataContext = postFlower;
        }

        private void BSave_Click(object sender, RoutedEventArgs e)
        {
            if (postFlower.Id == 0)
                MainWindow.db.Flower.Add(postFlower);
            MainWindow.db.SaveChanges();
            this.Close();
        }

        private void BChangePicture_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                postFlower.Picture = File.ReadAllBytes(openFileDialog.FileName);
                MemoryStream byteStream = new MemoryStream(postFlower.Picture);
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = byteStream;
                image.EndInit();
                IPicture.Source = image;
            }
        }
    }
}
