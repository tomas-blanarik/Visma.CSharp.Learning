using System.Collections.Generic;

namespace Session8.DependencyInjection
{
    public class Repository : IRepository
    {
        private readonly List<Payment> _payments = new List<Payment>();

        public void Add(Payment payment)
        {
            _payments.Add(payment);
        }

        public void Delete(Payment payment)
        {
            if (_payments.Contains(payment))
            {
                _payments.Remove(payment);
            }
        }

        public List<Payment> GetAll()
        {
            return _payments;
        }

        public void Update(Payment payment)
        {
            if (_payments.Contains(payment))
            {
                var indexOf = _payments.IndexOf(payment);
                var paymentToUpdate = _payments[indexOf];

                paymentToUpdate.Amount = payment.Amount;
            }
        }
    }
}
