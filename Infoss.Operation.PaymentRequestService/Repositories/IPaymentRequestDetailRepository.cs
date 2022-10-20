namespace Infoss.Operation.PaymentRequestService.Repositories
{
    public interface IPaymentRequestDetailRepository
    {
        public Task<Response> Create(PaymentRequestDetailTransaction paymentRequestDetail);
        public Task<Response> Update(PaymentRequestDetailTransaction paymentRequestDetail);
        //public Task<ResponsePage<InvoiceDetailResponse>> Deleted(RequestId requestId);
        //public Task<ResponsePage<InvoiceDetailResponse>> Delete(RequestId requestId);
    }
}
