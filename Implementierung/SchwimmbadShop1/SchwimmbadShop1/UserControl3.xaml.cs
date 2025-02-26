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
   //UserControl3 = LogIn Window 
    public partial class UserControl3 : UserControl
    {
        MainWindow wnd = null;
        public UserControl3(MainWindow wnd)
        {
            InitializeComponent();
            this.wnd = wnd;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            wnd.contentcontroler.Content = wnd.Menü;
        }
    }
}
