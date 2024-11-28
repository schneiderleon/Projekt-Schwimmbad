namespace SchwimmbadShop
{
    using System;
    using System.Collections.Generic;
    using System.Text;

   
        class Program
        {
            // Benutzerregistrierung mit Warenkörben
            static Dictionary<string, User> Users = new Dictionary<string, User>();
            static Dictionary<string, decimal> Products = new Dictionary<string, decimal>
        {
            { "Schwimmbrille", 15.99m },
            { "Badehandtuch", 25.49m },
            { "Schwimmring", 10.99m },
            { "Badespielzeug", 8.99m },
            { "Sonnencreme", 12.49m },
            { "Flip-Flops", 14.99m },
            { "Wasserspielball", 9.99m },
            { "Poolnudel", 6.99m },
            { "Badeanzug", 29.99m },
            { "Wasserdichte Tasche", 19.99m }
        };
            static string LoggedInUser = null;

            static void Main(string[] args)
            {
                // Konsolenausgabe auf UTF-8 setzen
                Console.OutputEncoding = Encoding.UTF8;

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("=== Schwimmbad Geschenke-Shop ===");
                    Console.WriteLine("1. Registrieren");
                    Console.WriteLine("2. Anmelden");
                    Console.WriteLine("3. Produkte anzeigen");
                    Console.WriteLine("4. Warenkorb ansehen");
                    Console.WriteLine("5. Beenden");
                    Console.Write("Option wählen: ");
                    string input = Console.ReadLine();

                    if (input == "1") Register();
                    else if (input == "2") Login();
                    else if (input == "3") ShowProducts();
                    else if (input == "4") ShowCart();
                    else if (input == "5") break;
                    else Console.WriteLine("Ungültige Option.");
                }
            }

            static void Register()
            {
                Console.Clear();
                Console.Write("E-Mail: ");
                string email = Console.ReadLine();
                Console.Write("Passwort: ");
                string password = Console.ReadLine();

                if (Users.ContainsKey(email))
                {
                    Console.WriteLine("E-Mail bereits registriert.");
                }
                else
                {
                    Users[email] = new User { Password = password, Cart = new List<string>() };
                    Console.WriteLine("Registrierung erfolgreich.");
                }
                Console.ReadKey();
            }

            static void Login()
            {
                Console.Clear();
                Console.Write("E-Mail: ");
                string email = Console.ReadLine();
                Console.Write("Passwort: ");
                string password = Console.ReadLine();

                if (Users.ContainsKey(email) && Users[email].Password == password)
                {
                    LoggedInUser = email;
                    Console.WriteLine("Anmeldung erfolgreich.");
                }
                else
                {
                    Console.WriteLine("Ungültige E-Mail oder Passwort.");
                }
                Console.ReadKey();
            }

            static void ShowProducts()
            {
                if (LoggedInUser == null)
                {
                    Console.WriteLine("Bitte melden Sie sich an, um Produkte anzusehen.");
                    Console.ReadKey();
                    return;
                }

                Console.Clear();
                Console.WriteLine("=== Produktkatalog ===");
                foreach (var product in Products)
                {
                    Console.WriteLine($"{product.Key} - {product.Value:F2} €");
                }
                Console.Write("Produktname zum Warenkorb hinzufügen (oder ENTER zum Abbrechen): ");
                string input = Console.ReadLine();
                if (Products.ContainsKey(input))
                {
                    Users[LoggedInUser].Cart.Add(input);
                    Console.WriteLine($"{input} wurde zum Warenkorb hinzugefügt.");
                }
                else if (!string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Produkt nicht gefunden.");
                }
                Console.ReadKey();
            }

            static void ShowCart()
            {
                if (LoggedInUser == null)
                {
                    Console.WriteLine("Bitte melden Sie sich an, um Ihren Warenkorb zu sehen.");
                    Console.ReadKey();
                    return;
                }

                var cart = Users[LoggedInUser].Cart;
                Console.Clear();
                Console.WriteLine("=== Warenkorb ===");
                if (cart.Count == 0)
                {
                    Console.WriteLine("Ihr Warenkorb ist leer.");
                }
                else
                {
                    decimal total = 0;
                    foreach (var item in cart)
                    {
                        Console.WriteLine($"{item} - {Products[item]:F2} €");
                        total += Products[item];
                    }
                    Console.WriteLine($"Gesamt: {total:F2} €");
                    Console.Write("Bestellung abschließen? (ja/nein): ");
                    if (Console.ReadLine()?.ToLower() == "ja")
                    {
                        cart.Clear();
                        Console.WriteLine("Bestellung erfolgreich abgeschlossen.");
                    }
                }
                Console.ReadKey();
            }
        }

        class User
        {
            public string Password { get; set; }
            public List<string> Cart { get; set; } // Benutzer-spezifischer Warenkorb
        }
    

}