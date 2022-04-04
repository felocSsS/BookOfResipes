using BookOfRecipes.Classes;
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

namespace BookOfRecipes.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FrameClass.Frm.Navigate(new RegisterPage());
        }

        private void BtnLogIn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HelpClass.IsAuth = true;
            HelpClass.Name = "Влад Шипилов";
        }
    }
}
