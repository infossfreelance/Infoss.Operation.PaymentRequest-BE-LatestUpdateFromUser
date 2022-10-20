using System.Data;
using Dapper;

namespace Infoss.Operation.PaymentRequestService.Repositories
{
    public class PaymentRequestParametersBase
    {
        public DynamicParameters parameters { get; set; } = new DynamicParameters();
        public PaymentRequestHeaderTransaction paymentRequestHeader { get; set; } = new PaymentRequestHeaderTransaction();

        public PaymentRequestParametersBase()
        {

        }

        public DynamicParameters PaymentRequestParameter(PaymentRequestHeaderTransaction paymentRequestHeader)
        {
            this.paymentRequestHeader = paymentRequestHeader;

            parameters.Add("@RowStatus", paymentRequestHeader.PaymentRequestHeader.RowStatus == "" ? "ACT" : paymentRequestHeader.PaymentRequestHeader.RowStatus);
            parameters.Add("@CountryId", paymentRequestHeader.PaymentRequestHeader.CountryId);
            parameters.Add("@CompanyId", paymentRequestHeader.PaymentRequestHeader.CompanyId);
            parameters.Add("@BranchId", paymentRequestHeader.PaymentRequestHeader.BranchId);
            parameters.Add("@Id", paymentRequestHeader.PaymentRequestHeader.Id);
            parameters.Add("@TicketId", paymentRequestHeader.PaymentRequestHeader.TicketId);
            parameters.Add("@PRNo", paymentRequestHeader.PaymentRequestHeader.PRNo);
            parameters.Add("@DebetCredit", paymentRequestHeader.PaymentRequestHeader.DebetCredit);
            parameters.Add("@ShipmentId", paymentRequestHeader.PaymentRequestHeader.ShipmentId);
            parameters.Add("@Reference", paymentRequestHeader.PaymentRequestHeader.Reference);
            parameters.Add("@PRStatus", paymentRequestHeader.PaymentRequestHeader.PRStatus);
            parameters.Add("@IsGeneralPR", paymentRequestHeader.PaymentRequestHeader.IsGeneralPR);
            parameters.Add("@CustomerId", paymentRequestHeader.PaymentRequestHeader.CustomerId);
            parameters.Add("@CustomerTypeId", paymentRequestHeader.PaymentRequestHeader.CustomerTypeId);
            parameters.Add("@PersonalId", paymentRequestHeader.PaymentRequestHeader.PersonalId);
            parameters.Add("@PaymentUSD", paymentRequestHeader.PaymentRequestHeader.PaymentUSD);
            parameters.Add("@PaymentIDR", paymentRequestHeader.PaymentRequestHeader.PaymentIDR);
            parameters.Add("@PRContraStatus", paymentRequestHeader.PaymentRequestHeader.PRContraStatus);
            parameters.Add("@PRContraNo", paymentRequestHeader.PaymentRequestHeader.PRContraNo);
            parameters.Add("@PaidUSD", paymentRequestHeader.PaymentRequestHeader.PaidUSD);
            parameters.Add("@DatePaidUSD", paymentRequestHeader.PaymentRequestHeader.DatePaidUSD);
            parameters.Add("@PaidIDR", paymentRequestHeader.PaymentRequestHeader.PaidIDR);
            parameters.Add("@DatePaidIDR", paymentRequestHeader.PaymentRequestHeader.DatePaidIDR);
            parameters.Add("@Deleted", paymentRequestHeader.PaymentRequestHeader.Deleted);
            parameters.Add("@DeletedOn", paymentRequestHeader.PaymentRequestHeader.DeletedOn);
            parameters.Add("@ApproveOpr", paymentRequestHeader.PaymentRequestHeader.ApproveOpr);
            parameters.Add("@ApproveOprOn", paymentRequestHeader.PaymentRequestHeader.ApproveOprOn);
            parameters.Add("@ApproveAcc", paymentRequestHeader.PaymentRequestHeader.ApproveAcc);
            parameters.Add("@ApproveAccOn", paymentRequestHeader.PaymentRequestHeader.ApproveAccOn);
            parameters.Add("@Rate", paymentRequestHeader.PaymentRequestHeader.Rate);
            parameters.Add("@ExRateDate", paymentRequestHeader.PaymentRequestHeader.ExRateDate);
            parameters.Add("@Printing", paymentRequestHeader.PaymentRequestHeader.Printing);
            parameters.Add("@PrintedOn", paymentRequestHeader.PaymentRequestHeader.PrintedOn);
            parameters.Add("@PRNo2", paymentRequestHeader.PaymentRequestHeader.PRNo2);
            parameters.Add("@ExRateId", paymentRequestHeader.PaymentRequestHeader.ExRateId);
            parameters.Add("@DeletedRemarks", paymentRequestHeader.PaymentRequestHeader.DeletedRemarks);
            parameters.Add("@IdLama", paymentRequestHeader.PaymentRequestHeader.IdLama);
            parameters.Add("@IsCostToCost", paymentRequestHeader.PaymentRequestHeader.IsCostToCost);
            parameters.Add("@TotalPpnUSD", paymentRequestHeader.PaymentRequestHeader.TotalPpnUSD);
            parameters.Add("@TotalPpnIDR", paymentRequestHeader.PaymentRequestHeader.TotalPpnIDR);
            parameters.Add("@UniqueKeyPR", paymentRequestHeader.PaymentRequestHeader.UniqueKeyPR);
            parameters.Add("@PackingListNo", paymentRequestHeader.PaymentRequestHeader.PackingListNo);
            parameters.Add("@SICustomerNo", paymentRequestHeader.PaymentRequestHeader.SICustomerNo);
            parameters.Add("@VendorDN", paymentRequestHeader.PaymentRequestHeader.VendorDN);
            parameters.Add("@Approved", paymentRequestHeader.PaymentRequestHeader.Approved);
            parameters.Add("@ApprovedOn", paymentRequestHeader.PaymentRequestHeader.ApprovedOn);
            parameters.Add("@ApprovedBy", paymentRequestHeader.PaymentRequestHeader.ApprovedBy);
            parameters.Add("@ApprovedRemarks", paymentRequestHeader.PaymentRequestHeader.ApprovedRemarks);
            parameters.Add("@ApprovedMarketing", paymentRequestHeader.PaymentRequestHeader.ApprovedMarketing);
            parameters.Add("@ApprovedMarketingOn", paymentRequestHeader.PaymentRequestHeader.ApprovedMarketingOn);
            parameters.Add("@ApprovedMarketingBy", paymentRequestHeader.PaymentRequestHeader.ApprovedMarketingBy);

            return parameters;
        }

    }
}
