namespace Session8.FactoryPattern
{
    public class GoldCardFactory : CardFactory
    {
        public override Card CreateCard()
        {
            return new GoldCard();
        }
    }
}
