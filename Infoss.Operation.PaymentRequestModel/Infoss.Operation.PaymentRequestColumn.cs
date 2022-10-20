namespace Infoss.Operation.PaymentRequestModel
{
    public class PaymentRequestColumn
    {
        public List<PaymentRequestHeaderColumn> HeaderColumns { get; set; } = new List<PaymentRequestHeaderColumn>();
        public List<PaymentRequestDetailColumn> DetailColumns { get; set; } = new List<PaymentRequestDetailColumn>();
    }
}