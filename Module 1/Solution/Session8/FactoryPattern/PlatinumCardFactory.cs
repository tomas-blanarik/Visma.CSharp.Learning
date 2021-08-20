namespace Session8.FactoryPattern
{
    public class PlatinumCardFactory : CardFactory
    {
        private int _creditLimit;

        public PlatinumCardFactory(int creditLimit)
        {
            _creditLimit = creditLimit;
        }

        public override Card CreateCard()
        {
            return new PlatinumCard(_creditLimit);
        }
    }
}
