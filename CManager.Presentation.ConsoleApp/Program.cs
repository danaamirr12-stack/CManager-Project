using CManager.Business;
using CManager.Data;

namespace CManager.Presentation.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerRepository repo = new CustomerRepository();
            CustomerService customerService = new CustomerService(repo);

            bool fortsätt = true;

            while (fortsätt == true)
            {
                Console.Clear();
                Console.WriteLine("--- Kundhantering ---");
                Console.WriteLine("1. Skapa ny kund");
                Console.WriteLine("2. Visa alla kunder");
                Console.WriteLine("3. Visa en kund");
                Console.WriteLine("4. Ta bort kund");
                Console.WriteLine("5. Avsluta");
                Console.Write("Välj: ");

                string val = Console.ReadLine();

                if (val == "1")
                {
                    Console.Clear();
                    Console.WriteLine("--- Skapa Kund ---");

                    Console.Write("Förnamn: ");
                    string förnamn = Console.ReadLine();

                    Console.Write("Efternamn: ");
                    string efternamn = Console.ReadLine();

                    Console.Write("E-post: ");
                    string epost = Console.ReadLine();

                    Console.Write("Telefon: ");
                    string telefon = Console.ReadLine();

                    Console.Write("Gatuadress: ");
                    string adress = Console.ReadLine();

                    Console.Write("Postnummer: ");
                    string postnummer = Console.ReadLine();

                    Console.Write("Ort: ");
                    string ort = Console.ReadLine();

                    customerService.CreateCustomer(förnamn, efternamn, epost, telefon, adress, postnummer, ort);

                    Console.WriteLine("Kund tillagd!");
                    Console.ReadKey();
                }
                else if (val == "2")
                {
                    Console.Clear();
                    Console.WriteLine("--- Alla Kunder ---");

                    List<Customer> allakunder = customerService.GetAllCustomers();

                    if (allakunder.Count == 0)
                    {
                        Console.WriteLine("Inga kunder.");
                    }
                    else
                    {
                        for (int i = 0; i < allakunder.Count; i++)
                        {
                            Console.WriteLine(allakunder[i].FirstName + " " + allakunder[i].LastName + " - " + allakunder[i].Email);
                        }
                    }

                    Console.ReadKey();
                }
                else if (val == "3")
                {
                    Console.Clear();
                    Console.WriteLine("--- Visa Kund ---");

                    Console.Write("E-post: ");
                    string sökEmail = Console.ReadLine();

                    Customer kund = customerService.GetCustomerByEmail(sökEmail);

                    if (kund == null)
                    {
                        Console.WriteLine("Finns ingen kund med den e-posten.");
                    }
                    else
                    {
                        Console.WriteLine("Namn: " + kund.FirstName + " " + kund.LastName);
                        Console.WriteLine("ID: " + kund.Id);
                        Console.WriteLine("E-post: " + kund.Email);
                        Console.WriteLine("Telefon: " + kund.PhoneNumber);
                        Console.WriteLine("Adress: " + kund.StreetAddress);
                        Console.WriteLine("Postnummer: " + kund.PostalCode);
                        Console.WriteLine("Ort: " + kund.City);
                    }

                    Console.ReadKey();
                }
                else if (val == "4")
                {
                    Console.Clear();
                    Console.WriteLine("--- Ta Bort Kund ---");

                    Console.Write("E-post: ");
                    string emailAttTaBort = Console.ReadLine();

                    customerService.DeleteCustomer(emailAttTaBort);

                    Console.WriteLine("Kund borttagen.");
                    Console.ReadKey();
                }
                else if (val == "5")
                {
                    fortsätt = false;
                }
                else
                {
                    Console.WriteLine("Felaktigt val!");
                    Console.ReadKey();
                }
            }
        }
    }
}
// Jag använde AI Copilot för att få hjälp med att strukturera koden rätt, Vissa parenteser, måsvingar och semikolon saknades när jag försökte koda ihop allt.