using System.Text;
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
    
    

    public partial class MainWindow : Window
    {

        SwimmingPoolShopContext ctx = new SwimmingPoolShopContext(); 



        //UserControl1 = Main Menu
        //UserControl2 = Register Window
        //UserControl3 = LogIn Window 


        public UserControl1 Menü;
        public UserControl2 Registriere;
        public UserControl3 Login;
        public UserControl4 Shop;

        public MainWindow()
        {
            InitializeComponent();
            Menü = new UserControl1(this);
            contentcontroler.Content = Menü;

            Registriere = new UserControl2(this);

            Login = new UserControl3(this);

            Shop = new UserControl4(this);
        }
    }
}