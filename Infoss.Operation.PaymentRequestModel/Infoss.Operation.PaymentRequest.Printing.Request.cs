namespace Infoss.Operation.PaymentRequestModel
{
    public class PaymentRequestPrintingRequest
    {
        public string RowStatus { get; set; } = string.Empty;
        public int CountryId { get; set; }
        public int CompanyId { get; set; }
        public int BranchId { get; set; }
        public int Id { get; set; }
        public int Printing { get; set; }
        public string User { get; set; } = string.Empty;
    }
}
