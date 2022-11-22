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
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void BRegistration_Click(object sender, RoutedEventArgs e)
        {
            if(TBPassword.Text != TBPasswordConfirm.Text)
            {
                MessageBox.Show("Password's don't match");
                return;
            }
            Model.User user = new Model.User();
            user.RoleId = 1;
            user.Login = TBLogin.Text;
            user.Password = TBPassword.Text;
            MainWindow.db.User.Add(user);
            MainWindow.db.SaveChanges();
            this.Close();
        }
    }
}
