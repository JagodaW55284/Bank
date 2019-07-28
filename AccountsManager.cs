using System.Collections.Generic;
using System.Linq;
 
namespace Bank
{
    class AccountsManager//Klasa managera kont. Trzyma listę otwartych kont w jednym miejscu i pozwala na tworzenie, modyfikowanie i dodawanie kont w aplikacji.//
    {
        private IList<Account> _accounts;
 
        public AccountsManager()//lista kont//
        {
            _accounts = new List<Account>();
        }
 
        public SavingsAccount CreateSavingsAccount(string firstName, string lastName, long pesel)//tworzenie konta oszczednosciowego//
        {
            int id = generateId();
 
            SavingsAccount account = new SavingsAccount(id, firstName, lastName, pesel);
 
            _accounts.Add(account);
 
            return account;
        }
 
        public BillingAccount CreateBillingAccount(string firstName, string lastName, long pesel)//tworzenie konta oszczednosciowego//
        {
            int id = generateId();
 
            BillingAccount account = new BillingAccount(id, firstName, lastName, pesel);
 
            _accounts.Add(account);
 
            return account;
        }
 
        public IEnumerable<Account> GetAllAccounts()//wszytskie konta//
        {
            return _accounts;
        }
 
        public IEnumerable<Account> GetAllAccountsFor(string firstName, string lastName, long pesel)//wszytskie konta dla//
        {
            return _accounts.Where(x => x.FirstName == firstName && x.LastName == lastName && x.Pesel == pesel);
        }
 
        public Account GetAccount(string accountNo)//konto//
        {
            return _accounts.Single(x => x.AccountNumber == accountNo);
        }
 
        public IEnumerable<string> ListOfCustomers()//lista klient-konto//
        {
            return _accounts.Select(a => string.Format("Imię: {0} | Nazwisko: {1} | PESEL: {2}", a.FirstName, a.LastName, a.Pesel)).Distinct();
        }
 
        public void CloseMonth()//zamknięcie miesiąca//
        {
            foreach(SavingsAccount account in _accounts.Where(x => x is SavingsAccount))
            {
                account.AddInterest(0.04M);
            }
 
            foreach(BillingAccount account in _accounts.Where(x => x is BillingAccount))
            {
                account.TakeCharge(5.0M);
            }
        }
 
        public void AddMoney(string accountNo, decimal value)//dodanie pieniędzy do konta//
        {
            Account account = GetAccount(accountNo);
            account.ChangeBalance(value);
        }
 
        public void TakeMoney(string accountNo, decimal value)//pobieranie pieniędzy z konta//
        {
            Account account = GetAccount(accountNo);
            account.ChangeBalance(-value);
        }
 
        private int generateId()
        {
            var id = 1;
 
            if (_accounts.Any())
            {
                id = _accounts.Max(x => x.Id) + 1;
            }
 
            return id;
        }
    }
}
