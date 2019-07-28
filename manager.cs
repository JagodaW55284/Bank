using System.Collections.Generic;
using System.Linq;
 
namespace Bank
{
    class AccountsManager
    {
        private IList<Account> _accounts;
 
        public AccountsManager()
        {
            _accounts = new List<Account>();
        }
 
        public SavingsAccount CreateSavingsAccount(string firstName, string lastName, long pesel)
        {
            int id = generateId();
 
            SavingsAccount account = new SavingsAccount(id, firstName, lastName, pesel);
 
            _accounts.Add(account);
 
            return account;
        }
 
        public BillingAccount CreateBillingAccount(string firstName, string lastName, long pesel)
        {
            int id = generateId();
 
            BillingAccount account = new BillingAccount(id, firstName, lastName, pesel);
 
            _accounts.Add(account);
 
            return account;
        }
 
        public IEnumerable<Account> GetAllAccounts()
        {
            return _accounts;
        }
 
        private int generateId()
        {
            int id = 1;
 
            if (_accounts.Any())
            {
                id = _accounts.Max(x => x.Id) + 1;
            }
 //dotąd zawiwera funkcję dodawania kont i pobierania listy wszystkich-które są już dodane//
            return id;