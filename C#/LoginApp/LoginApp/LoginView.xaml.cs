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

namespace LoginApp
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        public void OnLoginButton_Clicked(object sender, RoutedEventArgs args)
        {
            string passwordEntered = PasswordInput.Password;
            string? envPassword= Environment.GetEnvironmentVariable("DemoForPasswordC#");

            if (!string.IsNullOrEmpty(envPassword)) {
                if (passwordEntered == envPassword)
                {
                    MessageBox.Show("Correct Password.");
                    return;
                }
                else
                {
                    MessageBox.Show("Incorrect Password.");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Environment variable not found.");
                return;
            }

        }

        public void OnPassworChanged(object sender, EventArgs args)
        {
            LoginButton.IsEnabled = !string.IsNullOrEmpty(PasswordInput.Password);
        }

    }
}
