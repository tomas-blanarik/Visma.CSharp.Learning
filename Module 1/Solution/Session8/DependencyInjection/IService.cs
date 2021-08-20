using System.Collections.Generic;

namespace Session8.DependencyInjection
{
    public interface IService
    {
        void ProcessPayment(Payment payment);
        List<Payment> GetPayments();
    }
}
