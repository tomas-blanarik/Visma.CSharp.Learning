using System.Collections.Generic;

namespace Session8.DependencyInjection
{
    public interface IRepository
    {
        List<Payment> GetAll();
        void Add(Payment payment);
        void Update(Payment payment);
        void Delete(Payment payment);
    }
}
