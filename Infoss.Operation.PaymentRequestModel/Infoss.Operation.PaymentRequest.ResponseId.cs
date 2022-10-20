namespace Infoss.Operation.PaymentRequestModel
{
    public class PaymentRequestResponseId
    {
        public PaymentRequestHeaderResponseId PaymentRequestHeader { get; set; } = new PaymentRequestHeaderResponseId();
        public PaymentRequestColumn Columns { get; set; } = new PaymentRequestColumn();
    }
}