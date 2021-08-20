namespace Session8.FactoryPattern
{
    public class GoldCard : Card
    {
        public GoldCard()
        {
            CardType = "Gold";
            CreditLimit = int.MaxValue;
        }
    }
}
