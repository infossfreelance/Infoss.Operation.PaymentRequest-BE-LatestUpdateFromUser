namespace Infoss.Operation.PaymentRequestModel
{
    public class PaymentRequestHeader
    {
        public string RowStatus { get; set; } = string.Empty;
        public int CountryId { get; set; } = 0;
        public int CompanyId { get; set; } = 0;
        public int BranchId { get; set; } = 0;
        public int Id { get; set; } = 0;
        public int TicketId { get; set; } = 0;
        public int PRNo { get; set; } = 0;
        public string DebetCredit { get; set; } = string.Empty;
        public int ShipmentId { get; set; } = 0;
        public string ShipmentNo { get; set; } = string.Empty;
        public string Reference { get; set; } = string.Empty;
        public int PRStatus { get; set; } = 0;
        public bool IsGeneralPR { get; set; }
        public int CustomerId { get; set; } = 0;
        public int CustomerTypeId { get; set; } = 0;
        public int PersonalId { get; set; } = 0;
        public decimal PaymentUSD { get; set; } = 0;
        public decimal PaymentIDR { get; set; } = 0;
        public string PRContraStatus { get; set; } = string.Empty;
        public int PRContraNo { get; set; } = 0;
        public bool PaidUSD { get; set; }
        public DateTime DatePaidUSD { get; set; }
        public bool PaidIDR { get; set; }
        public DateTime DatePaidIDR { get; set; }
        public bool Deleted { get; set; }
        public DateTime DeletedOn { get; set; }
        public bool ApproveOpr { get; set; }
        public DateTime ApproveOprOn { get; set; }
        public bool ApproveAcc { get; set; }
        public DateTime ApproveAccOn { get; set; }
        public decimal Rate { get; set; } = 0;
        public DateTime ExRateDate { get; set; }
        public int Printing { get; set; } = 0;
        public DateTime PrintedOn { get; set; }
        public string PRNo2 { get; set; } = string.Empty;
        public int ExRateId { get; set; } = 0;
        public string DeletedRemarks { get; set; } = string.Empty;
        public int IdLama { get; set; } = 0;
        public bool IsCostToCost { get; set; }
        public decimal TotalPpnUSD { get; set; } = 0;
        public decimal TotalPpnIDR { get; set; } = 0;
        public string UniqueKeyPR { get; set; } = string.Empty;
        public string PackingListNo { get; set; } = string.Empty;
        public string SICustomerNo { get; set; } = string.Empty;
        public string VendorDN { get; set; } = string.Empty;
        public bool Approved { get; set; }
        public DateTime ApprovedOn { get; set; }
        public string ApprovedBy { get; set; } = string.Empty;
        public string ApprovedRemarks { get; set; } = string.Empty;
        public bool ApprovedMarketing { get; set; }
        public DateTime ApprovedMarketingOn { get; set; }
        public string ApprovedMarketingBy { get; set; } = string.Empty;
    }
}