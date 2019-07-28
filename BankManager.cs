using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Bank
{
    class BankManager
    {
        private AccountsManager _accountsManager;
        private IPrinter _printer;
 
        public BankManager()//tworzenie /zarzadznie kontami//s
        {
            _accountsManager = new AccountsManager();
            _printer = new Printer();
        }
 //wybór opcji działania//
        public void Run()
        {
            int action;
            do
            {
                PrintMainMenu();
                action = SelectedAction();
 
                switch (action)
                {
                    case 1:
                        ListOfAccounts();
                        break;
                    case 2:
                        AddBillingAccount();
                        break;
                    case 3:
                        Console.Clear();
                        AddSavingsAccount();
                        Console.ReadKey();
                        break;
                    case 4:
                        AddMoney();
                        break;
                    case 5:
                        Console.Clear();
                        TakeMoney();
                        Console.ReadKey();
                        break;
                    case 6:
                        ListOfCustomers();
                        break;
                    case 7:
                        ListOfAllAccounts();
                        break;
                    case 8:
                        CloseMonth();
                        break;
                    default:
                        Console.Write("Nieznane polecenie");
                        break;
                }
            }
            while (action != 0);
        }
 
        private void PrintMainMenu()//wybór numeru//
        {
            Console.Clear();
            Console.WriteLine("Wybierz akcję:");
            Console.WriteLine("1 - Lista kont klienta");
            Console.WriteLine("2 - Dodaj konto rozliczeniowe");
            Console.WriteLine("3 - Dodaj konto oszczędnościowe");
            Console.WriteLine("4 - Wpłać pieniądze na konto");
            Console.WriteLine("5 - Wypłać pieniądze z konta");
            Console.WriteLine("6 - Lista klientów");
            Console.WriteLine("7 - Wszystkie konta");
            Console.WriteLine("8 - Zakończ miesiąc");
            Console.WriteLine("0 - Zakończ");
        }
 
        private int SelectedAction()//akcja//
        {
            Console.Write("Akcja: ");
            string action = Console.ReadLine();
            if (string.IsNullOrEmpty(action))
            {
                return -1;
            }
            return int.Parse(action);
        }
 
        private void ListOfAccounts()//lista kont//
        {
            Console.Clear();
            CustomerData data = ReadCustomerData();
            Console.WriteLine();
            Console.WriteLine("Konta klienta {0} {1} {2}", data.FirstName, data.LastName, data.Pesel);
 
            foreach (Account account in _accountsManager.GetAllAccountsFor(data.FirstName, data.LastName, data.Pesel))
            {
                _printer.Print(account);
            }
            Console.ReadKey();
        }
 
        private CustomerData ReadCustomerData()//klient//
        {
            string firstName;
            string lastName;
            string pesel;
            Console.WriteLine("Podaj dane klienta:");
            Console.Write("Imię: ");
            firstName = Console.ReadLine();
            Console.Write("Nazwisko: ");
            lastName = Console.ReadLine();
            Console.Write("PESEL: ");
            pesel = Console.ReadLine();
 
            return new CustomerData(firstName, lastName, pesel);
        }
 
        private void AddBillingAccount()//dodanie rozliczeniowego konta//
        {
            Console.Clear();
            CustomerData data = ReadCustomerData();
            Account billingAccount = _accountsManager.CreateBillingAccount(data.FirstName, data.LastName, data.Pesel);
 
            Console.WriteLine("Utworzono konto rozliczeniowe:");
            _printer.Print(billingAccount);
            Console.ReadKey();
        }
 
        private void AddSavingsAccount()//dodanie oszczędnościowego konta//
        {
            Console.Clear();
            CustomerData data = ReadCustomerData();
            Account savingsAccount = _accountsManager.CreateSavingsAccount(data.FirstName, data.LastName, data.Pesel);
 
            Console.WriteLine("Utworzono konto rozliczeniowe:");
            _printer.Print(savingsAccount);
            Console.ReadKey();
        }
 
        private void AddMoney()//dodanie pieniędzy//
        {
            string accountNo;
            decimal value;
 
            Console.WriteLine("Wpłata pieniędzy");
            Console.Write("Numer konta: ");
            accountNo = Console.ReadLine();
            Console.Write("Kwota: ");
            value = decimal.Parse(Console.ReadLine());
            _accountsManager.AddMoney(accountNo, value);
 
            Account account = _accountsManager.GetAccount(accountNo);
            _printer.Print(account);
 
            Console.ReadKey();
        }
 
        private void TakeMoney()//pobranie pieniędzy//
        {
            string accountNo;
            decimal value;
 
            Console.WriteLine("Wypłata pieniędzy");
            Console.Write("Numer konta: ");
            accountNo = Console.ReadLine();
            Console.Write("Kwota: ");
            value = decimal.Parse(Console.ReadLine());
            _accountsManager.TakeMoney(accountNo, value);
 
            Account account = _accountsManager.GetAccount(accountNo);
            _printer.Print(account);
 
            Console.ReadKey();
        }
 
        private void ListOfCustomers()//lista klientów//
        {
            Console.Clear();
            Console.WriteLine("Lista klientów:");
            foreach (string customer in _accountsManager.ListOfCustomers())
            {
                Console.WriteLine(customer);
            }
            Console.ReadKey();
        }
 
        private void ListOfAllAccounts()//wszytskie konta//
        {
            Console.Clear();
            Console.WriteLine("Wszystkie konta:");
            foreach (Account account in _accountsManager.GetAllAccounts())
            {
                _printer.Print(account);
            }
            Console.ReadKey();
        }
 
        private void CloseMonth()//zamknięcie miesiąca//
        {
            Console.Clear();
            _accountsManager.CloseMonth();
            Console.WriteLine("Miesiąc zamknięty");
            Console.ReadKey();
        }
    }
 
    class CustomerData//dane klienta//
    {
        public string FirstName { get; }
        public string LastName { get; }
        public long Pesel { get; }
 
        public CustomerData(string firstName, string lastName, string pesel)
        {
            FirstName = firstName;
            LastName = lastName;
            Pesel = long.Parse(pesel);
        }
    }
}