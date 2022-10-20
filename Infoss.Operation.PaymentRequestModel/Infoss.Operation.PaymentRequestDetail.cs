namespace Infoss.Operation.PaymentRequestModel
{
    public class PaymentRequestDetail
    {
        public string RowStatus { get; set; } = string.Empty;
        public int CountryId { get; set; } = 0;
        public int CompanyId { get; set; } = 0;
        public int BranchId { get; set; } = 0;
        public int PaymentRequestId { get; set; } = 0;
        public int Sequence { get; set; } = 0;
        public string DebetCredit { get; set; } = string.Empty;
        public int AccountId { get; set; } = 0;
        public string Description { get; set; } = string.Empty;
        public int Type { get; set; } = 0;
        public bool CodingQuantity { get; set; }
        public decimal Quantity { get; set; } = 0;
        public decimal PerQty { get; set; } = 0;
        public decimal Amount { get; set; } = 0;
        public int AmountCrr { get; set; } = 0;
        public bool Paid { get; set; }
        public DateTime PaidOn { get; set; }
        public bool PaidPV { get; set; }
        public int EPLDetailId { get; set; } = 0;
        public bool StatusMemo { get; set; }
        public int MemoNo { get; set; } = 0;
        public int IdLama { get; set; } = 0;
        public bool IsCostToCost { get; set; }
        public bool IsPpn { get; set; }
        public int PersenPpn { get; set; } = 0;
        public string FakturNo { get; set; } = string.Empty;
        public DateTime FakturDate { get; set; }
        public bool IsCostTrucking { get; set; }
        public int KendaraanId { get; set; } = 0;
        public string KendaraanNopol { get; set; } = string.Empty;
        public int EmployeeId { get; set; } = 0;
        public string EmployeeName { get; set; } = string.Empty;
        public int MrgId { get; set; } = 0;
        public DateTime DeliveryDate { get; set; }
        public decimal OriginalUsd { get; set; } = 0;
        public decimal OriginalRate { get; set; } = 0;
    }
}