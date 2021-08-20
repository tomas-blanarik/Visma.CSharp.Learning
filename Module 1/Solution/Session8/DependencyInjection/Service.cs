using System.Collections.Generic;

namespace Session8.DependencyInjection
{
    public class Service : IService
    {
        private readonly IRepository _repository;

        public Service(IRepository repository)
        {
            _repository = repository;
        }

        public void ProcessPayment(Payment payment)
        {
            var payments = GetPayments();
            if (payments.Exists(x => x.AccountId == payment.AccountId))
            {
                _repository.Update(payment);
            }
            else
            {
                _repository.Add(payment);
            }
        }

        public List<Payment> GetPayments()
        {
            return _repository.GetAll();
        }
    }
}
