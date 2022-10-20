
namespace Infoss.Operation.PaymentRequestModel
{
    public class PaymentRequestGetPageRequest
    {
        private string _defFilter = "";
        public string UserCode { get; set; } = string.Empty;
        public int CountryId { get; set; }
        public int CompanyId { get; set; }
        public int BranchId { get; set; }
        public fieldFilter[] Filter { get; set; }
    }
    public class fieldFilter
    {
        public string Field { get; set; }
        public string Data { get; set; }
    }
}
