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
    /// Interaction logic for AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void BAuthorize_Click(object sender, RoutedEventArgs e)
        {
            Model.User user = MainWindow.db.User.FirstOrDefault(c => c.Login == TBLogin.Text && c.Password == PBPassword.Password);
            if(user == null)
            {
                MessageBox.Show("Unkown User");
                return;
            }
            MainWindow.loggedUser = user;
            NavigationService.Navigate(new Pages.MainMenuPage());
        }

        private void BRegistration_Click(object sender, RoutedEventArgs e)
        {
            Windows.RegistrationWindow registrationWindow = new Windows.RegistrationWindow();
            registrationWindow.ShowDialog();
        }
    }
}
