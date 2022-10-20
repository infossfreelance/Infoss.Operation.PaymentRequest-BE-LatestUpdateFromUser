namespace Infoss.Operation.PaymentRequestModel
{
    public class PaymentRequestResponsePage
    {
        public List<PaymentRequestHeaderResponse> PaymentRequestHeader { get; set; } = new List<PaymentRequestHeaderResponse>();
        public PaymentRequestColumn Columns { get; set; } = new PaymentRequestColumn();

    }
}