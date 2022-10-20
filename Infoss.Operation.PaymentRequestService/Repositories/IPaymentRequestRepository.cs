
namespace Infoss.Operation.PaymentRequestService.Repositories
{
    public interface IPaymentRequestRepository
    {
        public Task<ResponsePage<PaymentRequestResponsePage>> Read(PaymentRequestPage requestPage);
        public Task<ResponsePage<PaymentRequestResponseId>> Read(RequestId requestId);
        public Task<Response> Create(PaymentRequestTransaction paymentRequest);
        public Task<Response> Update(PaymentRequestTransaction paymentRequest);
        public Task<Response> Delete(RequestId requestId);

    }
}
