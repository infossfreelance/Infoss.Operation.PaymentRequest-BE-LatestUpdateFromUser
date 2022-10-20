namespace Infoss.Operation.PaymentRequestModel
{
    public class PaymentRequestTransaction
    {
        public PaymentRequestHeaderRequest PaymentRequestHeader { get; set; } = new PaymentRequestHeaderRequest();
        public List<PaymentRequestDetailRequest> PaymentRequestDetails { get; set; } = new List<PaymentRequestDetailRequest>();

    }
}