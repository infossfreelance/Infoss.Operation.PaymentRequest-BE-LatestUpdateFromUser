namespace Infoss.Operation.PaymentRequestModel
{
    public class PaymentRequestDetailResponse : PaymentRequestDetail
    {
        public string ModifiedBy { get; set; } = string.Empty;
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
    }
}