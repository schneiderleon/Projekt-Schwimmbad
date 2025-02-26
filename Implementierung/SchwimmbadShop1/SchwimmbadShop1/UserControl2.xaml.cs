using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    //UserControl2 = Register Window
    public partial class UserControl2 : UserControl
    {
        SwimmingPoolShopContext _context = new SwimmingPoolShopContext();
        MainWindow wnd = null;


        public UserControl2(MainWindow wnd)
        {
            InitializeComponent();
            this.wnd = wnd;
        }

        private void Back2_Click(object sender, RoutedEventArgs e)
        {
            wnd.contentcontroler.Content = wnd.Menü;
        }


        private bool IsValidEmail(string email)
        {
            
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+.[^@\s]+$");
            return emailRegex.IsMatch(email);
        }


        private void saveac(object sender, RoutedEventArgs e) 
        {

            if (IsValidEmail(newmail.Text))
            {

                if (newname.Text != null)
                {
                    if (pwdenter.Password == pwd.Password)
                    {
                        int maxId = _context.Customers.Any() ? _context.Customers.Max(c => c.CustomerId) : 0;

                        Customer c = new Customer
                        {
                            CustomerId = maxId + 1,
                            CustomerName = newname.Text,
                            Email = newmail.Text,
                            AccountPassword = pwd.Password,
                           
                        };

                        _context.Customers.Add(c);

                         _context.SaveChanges();

                        MessageBox.Show("Accountdetails wurden gespeichert.");

                       
                    }
                    else
                    {
                        MessageBox.Show("Passwörter stimmen nicht überein!");


                    }

                } else
                {
                    MessageBox.Show("Namensfeld ist leer!");
                }

            }else
            {
                MessageBox.Show("Email - Feld ist leer oder ungültig!");
            }
            newname.Text = "";
            newmail.Text = "";
            pwd.Password = "";
            pwdenter.Password = "";

        }

    }
}
