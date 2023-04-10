using DevFreela.Payments.API.Models;
using System.Threading.Tasks;

namespace DevFreela.Payments.API.Services
{
    public class PaymentService : IPaymentService
    {
        public Task<bool> Process(PaymentInfoInputModel paymentInfoInputModel)
        {
            //Apenas para teste. Não vou implementar aqui.
            return Task.FromResult(true);
        }
    }
}
