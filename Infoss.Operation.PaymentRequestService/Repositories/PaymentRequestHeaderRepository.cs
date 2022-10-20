
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Infoss.Master.MessageModel;
using Infoss.Operation.PaymentRequestModel;

namespace Infoss.Operation.PaymentRequestService.Repositories
{
    public class PaymentRequestHeaderRepository : IPaymentRequestHeaderRepository
    {
        private SqlConnection connection;

        public PaymentRequestHeaderRepository(SqlConnection connection)
        {
            this.connection = connection;
        }

        public async Task<Response> Create(PaymentRequestHeaderTransaction paymentRequestHeader)
        {
            var responsePage = new Response();

            PaymentRequestParameters invoiceParameters = new PaymentRequestParameters(paymentRequestHeader);
            var parameters = invoiceParameters.Create();

            try
            {
                var affectedRows = await connection.ExecuteAsync("operation.SP_PaymentRequest_Create", parameters, commandType: CommandType.StoredProcedure);

                int id = parameters.Get<int>("@RETURNVALUE");
                paymentRequestHeader.PaymentRequestHeader.Id = id;

                responsePage.Code = 200;
                responsePage.Message = "Data created";

                return responsePage;

            }
            catch (Exception ex)
            {
                responsePage.Code = 500;
                responsePage.Error = ex.Message;
                responsePage.Message = "Failed to create";

                return responsePage;
            }
        }

        public async Task<Response> Update(PaymentRequestHeaderTransaction paymentRequestHeader)
        {
            var responsePage = new Response();

            PaymentRequestParameters paymentRequestParameters = new PaymentRequestParameters(paymentRequestHeader);
            var parameters = paymentRequestParameters.Update();

            try
            {
                var affectedRows = await connection.ExecuteAsync("operation.SP_PaymentRequest_Update", parameters, commandType: CommandType.StoredProcedure);

                responsePage.Code = 200;
                responsePage.Message = "Data updated";

                return responsePage;

            }
            catch (Exception ex)
            {
                responsePage.Code = 500;
                responsePage.Error = ex.Message;
                responsePage.Message = "Failed to update";

                return responsePage;
            }
        }
    }
}
