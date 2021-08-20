namespace Session8.FactoryPattern
{
    public class PlatinumCard : Card
    {
        public PlatinumCard(int creditLimit)
        {
            CardType = "Platinum";
            CreditLimit = creditLimit;
        }
    }
}
