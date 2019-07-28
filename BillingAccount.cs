namespace Bank
{
    class BillingAccount : Account//Klasa konta rozliczeniowego, poszerzone o funkcje pobierania opłaty za prowadzenie konta.//
    {
        public BillingAccount(int id, string firstName, string lastName, long pesel)
            : base(id, firstName, lastName, pesel)
        {
        }
  // informacje konto rozliczeniowe//
        public void TakeCharge(decimal value)//stan konta//
        {
            Balance -= value;
        }
 
        public override string TypeName()//nazwa/typ konta//
        {
            return "ROZLICZENIOWE";
        }
    }
}
