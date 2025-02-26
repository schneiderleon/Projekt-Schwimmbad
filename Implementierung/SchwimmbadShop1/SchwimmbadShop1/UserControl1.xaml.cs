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

namespace SchwimmbadShop1
{
    
    public partial class UserControl1 : UserControl
    {
        MainWindow wnd = null;


        //UserControl1 = Main Menu
        public UserControl1(MainWindow wnd)
        {
            

            InitializeComponent();
            this.wnd = wnd;


        }

        private void register_Click(object sender, RoutedEventArgs e)
        {
            wnd.contentcontroler.Content = wnd.Registriere;
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            wnd.contentcontroler.Content = wnd.Login;
        }

        private void shop_Click(object sender, RoutedEventArgs e)
        {
            wnd.contentcontroler.Content = wnd.Shop;
        }
    }
}
