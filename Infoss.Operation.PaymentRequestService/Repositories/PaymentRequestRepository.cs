
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Infoss.Operation.PaymentRequestModel;

namespace Infoss.Operation.PaymentRequestService.Repositories
{
    public class PaymentRequestRepository : IPaymentRequestRepository
    {
        private string connectionString = string.Empty;

        private readonly PaymentRequestHeaderRepository paymentRequestHeaderRepository;
        private readonly PaymentRequestDetailRepository paymentRequestDetailRepository;

        public PaymentRequestRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("SqlConnection");
            paymentRequestHeaderRepository = new PaymentRequestHeaderRepository(new SqlConnection(connectionString));
            paymentRequestDetailRepository = new PaymentRequestDetailRepository(new SqlConnection(connectionString));
        }

        public async Task<ResponsePage<PaymentRequestResponsePage>> Read(PaymentRequestPage requestPage)
        {
            var responsePage = new ResponsePage<PaymentRequestResponsePage>();

            try
            {
                int a = requestPage.UserLogin.Filter.Length;
                string queryfilter = "";
                for (int i = 0; i < a; i++)
                {
                    string x = "";
                    string y = "";
                    y = requestPage.UserLogin.Filter[i].Field;
                    x = requestPage.UserLogin.Filter[i].Data;
                    if (y != "")
                    {
                        if (y == "DebetCredit")
                        {
                            queryfilter = queryfilter + " AND prdtl." + y + " LIKE '%" + x + "%' ";
                        }
                        else
                        {
                            queryfilter = queryfilter + " AND pr." + y + " LIKE '%" + x + "%' ";
                        }
                    }
                }

                var parameters = new DynamicParameters();
                parameters.Add("@RowStatus", requestPage.RowStatus == "" ? "ACT" : requestPage.RowStatus);
                parameters.Add("@CountryId", requestPage.UserLogin.CountryId);
                parameters.Add("@CompanyId", requestPage.UserLogin.CompanyId);
                parameters.Add("@BranchId", requestPage.UserLogin.BranchId);
                parameters.Add("@User", requestPage.UserLogin.UserCode);
                parameters.Add("@Id", 0);
                parameters.Add("@Filter", queryfilter);
                parameters.Add("@PageNo", requestPage.PageNumber);
                parameters.Add("@PageSize", requestPage.PageSize);
                parameters.Add("@RowCount", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@PageCount", dbType: DbType.Int32, direction: ParameterDirection.Output);

                using (var connection = new SqlConnection(connectionString))
                {
                    using (var multi = (await connection.QueryMultipleAsync("operation.SP_PaymentRequest_Read_Test", parameters, commandType: CommandType.StoredProcedure)))
                    {
                        PaymentRequestResponsePage paymentRequestResponsePage = new PaymentRequestResponsePage();

                        var paymentRequestHeaderColumns = (await multi.ReadAsync<PaymentRequestHeaderColumn>()).ToList();
                        var paymentRequestHeaderResponses = (await multi.ReadAsync<PaymentRequestHeaderResponse>()).ToList();

                        paymentRequestResponsePage.Columns.HeaderColumns = paymentRequestHeaderColumns;
                        paymentRequestResponsePage.PaymentRequestHeader = paymentRequestHeaderResponses;

                        responsePage.Data = paymentRequestResponsePage;

                        responsePage.TotalRowCount = parameters.Get<int>("@RowCount");
                        responsePage.TotalPage = parameters.Get<int>("@PageCount");

                        if (responsePage.Data != null)
                        {
                            responsePage.Code = 200;
                            responsePage.Message = "Successfully read";
                        }
                        else
                        {
                            responsePage.Code = 204;
                            responsePage.Message = "No content";
                        }

                        return responsePage;
                    }
                }

            }

            catch (Exception ex)
            {
                responsePage.Code = 500;
                responsePage.Error = ex.Message;
                responsePage.Message = "Failed to read";

                return responsePage;
            }
        }

        public async Task<ResponsePage<PaymentRequestResponseId>> Read(RequestId requestId)
        {
            var responsePage = new ResponsePage<PaymentRequestResponseId>();

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@RowStatus", requestId.RowStatus == "" ? "ACT" : requestId.RowStatus);
                parameters.Add("@CountryId", requestId.UserLogin.CountryId);
                parameters.Add("@CompanyId", requestId.UserLogin.CompanyId);
                parameters.Add("@BranchId", requestId.UserLogin.BranchId);
                parameters.Add("@User", requestId.UserLogin.UserCode);
                parameters.Add("@Id", requestId.Id);
                parameters.Add("@PageNo", 0);
                parameters.Add("@PageSize", 0);
                parameters.Add("@RowCount", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@PageCount", dbType: DbType.Int32, direction: ParameterDirection.Output);

                using (var connection = new SqlConnection(connectionString))
                {
                    using (var multi = (await connection.QueryMultipleAsync("operation.SP_PaymentRequest_Read_Test", parameters, commandType: CommandType.StoredProcedure)))
                    {
                        PaymentRequestResponseId paymentRequestResponseId = new PaymentRequestResponseId();

                        var paymentRequestHeaderResponses = (await multi.ReadAsync<PaymentRequestHeaderResponseId>()).First();
                        var paymentRequestHeaderColumns = (await multi.ReadAsync<PaymentRequestHeaderColumn>()).ToList();

                        var paymentRequestDetailResponses = (await multi.ReadAsync<PaymentRequestDetailResponse>()).ToList();
                        var paymentRequestDetailColumns = (await multi.ReadAsync<PaymentRequestDetailColumn>()).ToList();

                        paymentRequestResponseId.Columns.HeaderColumns = paymentRequestHeaderColumns;
                        paymentRequestResponseId.PaymentRequestHeader = paymentRequestHeaderResponses;

                        paymentRequestResponseId.Columns.DetailColumns = paymentRequestDetailColumns;
                        paymentRequestResponseId.PaymentRequestHeader.PaymentRequestDetails = paymentRequestDetailResponses;

                        responsePage.Data = paymentRequestResponseId;

                        responsePage.TotalRowCount = parameters.Get<int>("@RowCount");
                        responsePage.TotalPage = parameters.Get<int>("@PageCount");

                        if (responsePage.Data != null)
                        {
                            responsePage.Code = 200;
                            responsePage.Message = "Successfully read";
                        }
                        else
                        {
                            responsePage.Code = 204;
                            responsePage.Message = "No content";
                        }

                        return responsePage;
                    }
                }

            }

            catch (Exception ex)
            {
                responsePage.Code = 500;
                responsePage.Error = ex.Message;
                responsePage.Message = "Failed to read";

                return responsePage;
            }
        }

        public async Task<Response> Create(PaymentRequestTransaction paymentRequest)
        {
            PaymentRequestHeaderTransaction paymentRequestHeaderTransaction = new PaymentRequestHeaderTransaction();
            PaymentRequestDetailTransaction paymentRequestDetailTransaction = new PaymentRequestDetailTransaction();

            paymentRequestHeaderTransaction.PaymentRequestHeader = paymentRequest.PaymentRequestHeader;
            paymentRequestDetailTransaction.PaymentRequestDetails = paymentRequest.PaymentRequestDetails;

            using (var connection = new SqlConnection(connectionString))
            {
                var response = new Response();
                var responsePage = new Response();

                await connection.OpenAsync();
                var transaction = connection.BeginTransaction();

                try
                {
                    // PaymentRequest Header Insert
                    response = await paymentRequestHeaderRepository.Create(paymentRequestHeaderTransaction);

                    // PaymentRequest Detail Insert
                    paymentRequestDetailRepository.paymentRequestId = paymentRequestHeaderTransaction.PaymentRequestHeader.Id;
                    paymentRequestDetailRepository.countryId = paymentRequestHeaderTransaction.PaymentRequestHeader.CountryId;
                    paymentRequestDetailRepository.companyId = paymentRequestHeaderTransaction.PaymentRequestHeader.CompanyId;
                    paymentRequestDetailRepository.branchId = paymentRequestHeaderTransaction.PaymentRequestHeader.BranchId;
                    response = await paymentRequestDetailRepository.Create(paymentRequestDetailTransaction);

                    transaction.Commit();

                    responsePage.Code = response.Code;
                    responsePage.Message = response.Message;

                    return responsePage;

                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    responsePage.Code = response.Code;
                    responsePage.Error = ex.Message;
                    responsePage.Message = response.Message;

                    return responsePage;
                }
            }
        }

        public async Task<Response> Update(PaymentRequestTransaction paymentRequest)
        {
            PaymentRequestHeaderTransaction paymentRequestHeaderTransaction = new PaymentRequestHeaderTransaction();
            PaymentRequestDetailTransaction paymentRequestDetailTransaction = new PaymentRequestDetailTransaction();

            paymentRequestHeaderTransaction.PaymentRequestHeader = paymentRequest.PaymentRequestHeader;
            paymentRequestDetailTransaction.PaymentRequestDetails = paymentRequest.PaymentRequestDetails;

            using (var connection = new SqlConnection(connectionString))
            {
                var response = new Response();
                var responsePage = new Response();

                await connection.OpenAsync();
                var transaction = connection.BeginTransaction();

                try
                {
                    // PaymentRequest Header Update
                    response = await paymentRequestHeaderRepository.Update(paymentRequestHeaderTransaction);

                    // PaymentRequest Detail Update
                    paymentRequestDetailRepository.paymentRequestId = paymentRequestHeaderTransaction.PaymentRequestHeader.Id;
                    paymentRequestDetailRepository.countryId = paymentRequestHeaderTransaction.PaymentRequestHeader.CountryId;
                    paymentRequestDetailRepository.companyId = paymentRequestHeaderTransaction.PaymentRequestHeader.CompanyId;
                    paymentRequestDetailRepository.branchId = paymentRequestHeaderTransaction.PaymentRequestHeader.BranchId;
                    response = await paymentRequestDetailRepository.Update(paymentRequestDetailTransaction);

                    transaction.Commit();

                    responsePage.Code = response.Code;
                    responsePage.Message = response.Message;

                    return responsePage;

                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    responsePage.Code = response.Code;
                    responsePage.Error = ex.Message;
                    responsePage.Message = response.Message;

                    return responsePage;
                }
            }
        }

        public async Task<Response> Delete(RequestId requestId)
        {
            var response = new Response();
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


                using (var connection = new SqlConnection(connectionString))
                {
                    var affectedRows = await connection.ExecuteAsync("Operation.SP_PaymentRequest_Delete", parameters, commandType: CommandType.StoredProcedure);

                    // Invoice Detail Delete
                    response = await paymentRequestDetailRepository.Delete(requestId);

                    responsePage.Code = 200;
                    responsePage.Message = "Data deleted";

                    return responsePage;
                }
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
