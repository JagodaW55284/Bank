namespace Bank
{
    abstract class Account//klasa abstrakcyjna zawierająca zmienne i funkcje, które są takie same dla kazdego konta //
    {
        public int Id { get; }
        public string AccountNumber { get; }
        public decimal Balance { get; protected set; }
        public string FirstName { get; }
        public string LastName { get; }
        public long Pesel { get; }
 
        public Account(int id, string firstName, string lastName, long pesel)//informacje o koncie/kliencie//
        {
            Id = id;
            AccountNumber = generateAccountNumber(id);
            Balance = 0.0M;
            FirstName = firstName;
            LastName = lastName;
            Pesel = pesel;
        }
 
        public abstract string TypeName();
 
        public string GetFullName()//pobranie pełnej nazwy klienta//
        {
            string fullName = string.Format("{0} {1}", FirstName, LastName);
 
            return fullName;
        }
 
        public string GetBalance()//pobranie stanu konta//
        {
            return string.Format("{0}zł", Balance);
        }
 
        public void ChangeBalance(decimal value)//zmiana stanu konta//
        {
            Balance += value;
        }
 
        private string generateAccountNumber(int id)//numer konta//
        {
            var accountNumber = string.Format("94{0:D10}", id);
 
            return accountNumber;
        }
    }
}
