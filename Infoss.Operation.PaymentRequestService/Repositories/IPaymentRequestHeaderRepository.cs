namespace Infoss.Operation.PaymentRequestService.Repositories
{
    public interface IPaymentRequestHeaderRepository
    {
        public Task<Response> Create(PaymentRequestHeaderTransaction paymentRequestHeader);
        public Task<Response> Update(PaymentRequestHeaderTransaction paymentRequestHeader);
    }
}
