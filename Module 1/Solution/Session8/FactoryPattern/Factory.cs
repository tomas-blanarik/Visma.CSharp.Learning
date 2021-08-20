namespace Session8.FactoryPattern
{
    public class Factory
    {
        private CardFactory _goldFactory;

        public Factory()
        {
            _goldFactory = new GoldCardFactory();
        }

        public Card CreateGoldCard() => _goldFactory.CreateCard();
        public Card CreatePlatinumCard(int creditLimit) => new PlatinumCardFactory(creditLimit).CreateCard();
    }
}
