namespace Infoss.Operation.PaymentRequestModel
{
    public class PaymentRequestPage : RequestPaymentRequest
    {
        public PaymentRequestGetPageRequest UserLogin = new PaymentRequestGetPageRequest();

        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }
}
