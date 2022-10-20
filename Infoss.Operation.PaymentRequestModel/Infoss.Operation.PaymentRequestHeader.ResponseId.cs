namespace Infoss.Operation.PaymentRequestModel
{
    public class PaymentRequestHeaderResponseId : PaymentRequestHeaderResponse
    {
        public List<PaymentRequestDetailResponse> PaymentRequestDetails { get; set; } = new List<PaymentRequestDetailResponse>();
    }
}