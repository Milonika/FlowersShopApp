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

namespace FlowersShopApp.Windows
{
    /// <summary>
    /// Interaction logic for FlowersListWindow.xaml
    /// </summary>
    public partial class FlowersListWindow : Window
    {
        public FlowersListWindow()
        {
            InitializeComponent();
            DGFlower.ItemsSource = MainWindow.db.Flower.ToList();
        }

        private void DGFlower_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.Close();
        }
    }
}
