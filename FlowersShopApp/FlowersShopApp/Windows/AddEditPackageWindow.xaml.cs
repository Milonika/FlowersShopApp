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
    /// Interaction logic for AddEditPackageWindow.xaml
    /// </summary>
    public partial class AddEditPackageWindow : Window
    {
        Model.Package postPackage;
        public AddEditPackageWindow(Model.Package package)
        {
            InitializeComponent();
            postPackage = package;
            this.DataContext = postPackage;
        }

        private void BSave_Click(object sender, RoutedEventArgs e)
        {
            if (postPackage.Id == 0)
                MainWindow.db.Package.Add(postPackage);
            MainWindow.db.SaveChanges();
            this.Close();
        }

        private void BChangePicture_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                postPackage.Picture = File.ReadAllBytes(openFileDialog.FileName);
                MemoryStream byteStream = new MemoryStream(postPackage.Picture);
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = byteStream;
                image.EndInit();
                IPicture.Source = image;
            }
        }
    }
}
