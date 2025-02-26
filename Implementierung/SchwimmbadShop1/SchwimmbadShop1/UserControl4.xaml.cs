using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
    public partial class UserControl4 : UserControl
    {

        private ICollectionView DisplayView;

        SwimmingPoolShopContext _context = new SwimmingPoolShopContext();
        
        MainWindow wnd = null;


        public UserControl4(MainWindow wnd)
        {
            InitializeComponent();

            _context.Products.Load();
            
            DisplayView = CollectionViewSource.GetDefaultView(_context.Products.Local.ToObservableCollection());

            DataContext = DisplayView;

            this.wnd = wnd;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Product n = new Product
            {
                ProductId = Convert.ToInt32(prdktid.Text),
                ProductName = prdktname.Text,
                
                ProductDescription =  prdktbesch.Text,
                Price = Convert.ToInt32(prdktpr.Text)

               
            };

            _context.Products.Add(n);

            _context.SaveChanges();

        }

        private void DelButton_Click(object sender, RoutedEventArgs e)
        {
           int pr = Convert.ToInt32(prdktid.Text);
           

            Product n = _context.Products.FirstOrDefault(n => pr.Equals(n.ProductId));

            if (n != null)
            {
                _context.Products.Remove(n);

                _context.SaveChanges();

                
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            wnd.contentcontroler.Content = wnd.Menü;
        }
    }
}

