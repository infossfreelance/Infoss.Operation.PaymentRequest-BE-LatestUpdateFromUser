
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Infoss.Master.MessageModel;
using Infoss.Operation.PaymentRequestModel;
using Infoss.Reg.UserAccessModel;

namespace Infoss.Operation.PaymentRequestService.Repositories
{
    public class PaymentRequestDetailRepository : IPaymentRequestDetailRepository
    {
        private SqlConnection connection;
        public int paymentRequestId;
        public int countryId;
        public int companyId;
        public int branchId;

        public PaymentRequestDetailRepository(SqlConnection connection)
        {
            this.connection = connection;
        }

        public async Task<Response> Create(PaymentRequestDetailTransaction paymentRequestDetails)
        {
            var responsePage = new Response();

            var parameters = new DynamicParameters();

            int index = 1;
            foreach (PaymentRequestDetailRequest paymentRequestDetail in paymentRequestDetails.PaymentRequestDetails)
            {
                parameters.Add("@RowStatus", paymentRequestDetail.RowStatus == "" ? "ACT" : paymentRequestDetail.RowStatus);
                parameters.Add("@CountryId", countryId);
                parameters.Add("@CompanyId", companyId);
                parameters.Add("@BranchId", branchId);
                parameters.Add("@PaymentRequestId", paymentRequestId);
                parameters.Add("@Sequence", index);
                parameters.Add("@DebetCredit", paymentRequestDetail.DebetCredit);
                parameters.Add("@AccountId", paymentRequestDetail.AccountId);
                parameters.Add("@Description", paymentRequestDetail.Description);
                parameters.Add("@Type", paymentRequestDetail.Type);
                parameters.Add("@CodingQuantity", paymentRequestDetail.CodingQuantity);
                parameters.Add("@Quantity", paymentRequestDetail.Quantity);
                parameters.Add("@PerQty", paymentRequestDetail.PerQty);
                parameters.Add("@Amount", paymentRequestDetail.Amount);
                parameters.Add("@AmountCrr", paymentRequestDetail.AmountCrr);
                parameters.Add("@Paid", paymentRequestDetail.Paid);
                parameters.Add("@PaidOn", paymentRequestDetail.PaidOn);
                parameters.Add("@PaidPV", paymentRequestDetail.PaidPV);
                parameters.Add("@EPLDetailId", paymentRequestDetail.EPLDetailId);
                parameters.Add("@StatusMemo", paymentRequestDetail.StatusMemo);
                parameters.Add("@MemoNo", paymentRequestDetail.MemoNo);
                parameters.Add("@IdLama", paymentRequestDetail.IdLama);
                parameters.Add("@IsCostToCost", paymentRequestDetail.IsCostToCost);
                parameters.Add("@IsPpn", paymentRequestDetail.IsPpn);
                parameters.Add("@PersenPpn", paymentRequestDetail.PersenPpn);
                parameters.Add("@FakturNo", paymentRequestDetail.FakturNo);
                parameters.Add("@FakturDate", paymentRequestDetail.FakturDate);
                parameters.Add("@IsCostTrucking", paymentRequestDetail.IsCostTrucking);
                parameters.Add("@KendaraanId", paymentRequestDetail.KendaraanId);
                parameters.Add("@KendaraanNopol", paymentRequestDetail.KendaraanNopol);
                parameters.Add("@EmployeeId", paymentRequestDetail.EmployeeId);
                parameters.Add("@EmployeeName", paymentRequestDetail.EmployeeName);
                parameters.Add("@MrgId", paymentRequestDetail.MrgId);
                parameters.Add("@DeliveryDate", paymentRequestDetail.DeliveryDate);
                parameters.Add("@OriginalUsd", paymentRequestDetail.OriginalUsd);
                parameters.Add("@OriginalRate", paymentRequestDetail.OriginalRate);
                parameters.Add("@CreatedBy", paymentRequestDetail.User);
                parameters.Add("@RETURNVALUE", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                try
                {
                    var affectedRows = await connection.ExecuteAsync("operation.SP_PaymentRequestDetail_Create", parameters, commandType: CommandType.StoredProcedure);
                    int id = parameters.Get<int>("@RETURNVALUE");

                    index++;

                }
                catch (Exception ex)
                {
                    responsePage.Code = 500;
                    responsePage.Error = ex.Message;
                    responsePage.Message = "Failed to create";

                    return responsePage;
                }
            }

            responsePage.Code = 200;
            responsePage.Message = "Data created";

            return responsePage;
        }

        public async Task<Response> Update(PaymentRequestDetailTransaction paymentRequestDetails)
        {
            var responsePage = new Response();

            var parameters = new DynamicParameters();


            // Delete Invoice Detail

            var requestId = new RequestId();
            requestId.Id = paymentRequestId;
            requestId.UserLogin.CountryId = countryId;
            requestId.UserLogin.CompanyId = companyId;
            requestId.UserLogin.BranchId = branchId;

            await Deleted(requestId);


            // Insert All Invoice Detail After Delete

            await Create(paymentRequestDetails);


            responsePage.Code = 200;
            responsePage.Message = "Data updated";

            return responsePage;
        }

        public async Task<Response> Deleted(RequestId requestId)
        {
            var responsePage = new Response();

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RowStatus", requestId.RowStatus == "" ? "DEL" : requestId.RowStatus);
                parameters.Add("@CountryId", requestId.UserLogin.CountryId);
                parameters.Add("@CompanyId", requestId.UserLogin.CompanyId);
                parameters.Add("@BranchId", requestId.UserLogin.BranchId);
                parameters.Add("@Id", requestId.Id);
                parameters.Add("@ModifiedBy", requestId.UserLogin.UserCode);

                var affectedRows = await connection.ExecuteAsync("Operation.SP_PaymentRequestDetail_Deleted", parameters, commandType: CommandType.StoredProcedure);

                responsePage.Code = 200;
                responsePage.Message = "Data deleted";

                return responsePage;
            }
            catch (Exception ex)
            {
                responsePage.Code = 500;
                responsePage.Error = ex.Message;
                responsePage.Message = "Failed to delete";

                return responsePage;
            }
        }

        public async Task<Response> Delete(RequestId requestId)
        {
            var responsePage = new Response();

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RowStatus", requestId.RowStatus == "" ? "DEL" : requestId.RowStatus);
                parameters.Add("@CountryId", requestId.UserLogin.CountryId);
                parameters.Add("@CompanyId", requestId.UserLogin.CompanyId);
                parameters.Add("@BranchId", requestId.UserLogin.BranchId);
                parameters.Add("@Id", requestId.Id);
                parameters.Add("@ModifiedBy", requestId.UserLogin.UserCode);

                var affectedRows = await connection.ExecuteAsync("Operation.SP_PaymentRequestDetail_Delete", parameters, commandType: CommandType.StoredProcedure);

                responsePage.Code = 200;
                responsePage.Message = "Data deleted";

                return responsePage;
            }
            catch (Exception ex)
            {
                responsePage.Code = 500;
                responsePage.Error = ex.Message;
                responsePage.Message = "Failed to delete";

                return responsePage;
            }
        }

    }
}
