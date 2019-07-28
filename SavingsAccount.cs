namespace Bank
{
    class SavingsAccount : Account//Klasa konta o. Dziedziczy po klasie bazowej Account i ma poszerzoną funkcję o funkcje do dodawania odsetek.//
    {
        public SavingsAccount(int id, string firstName, string lastName, long pesel)
            : base(id, firstName, lastName, pesel)
        {
        }
 // informacje konto oszczednosciowe//
        public void AddInterest(decimal interest)//odsetki//
        {
            Balance += Balance * interest;
        }
 
        public override string TypeName()//nazwa/typ konta//
        {
            return "OSZCZĘDNOŚCIOWE";
        }
    }
}
