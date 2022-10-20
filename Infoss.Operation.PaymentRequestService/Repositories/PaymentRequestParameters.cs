using System.Data;
using Dapper;
using Infoss.Operation.PaymentRequestService.Repositories;
using Infoss.Operation.PaymentRequestModel;

namespace Infoss.Operation.PaymentRequestService.Repositories
{
    public class PaymentRequestParameters : PaymentRequestParametersBase
    {

        public PaymentRequestParameters()
        {

        }
        public PaymentRequestParameters(PaymentRequestHeaderTransaction paymentRequestHeader)
        {
            PaymentRequestParameter(paymentRequestHeader);
        }
        public DynamicParameters Create()
        {
            paymentRequestHeader.PaymentRequestHeader.Id = 0;

            parameters.Add("@CreatedBy", paymentRequestHeader.PaymentRequestHeader.User);
            parameters.Add("@RETURNVALUE", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);


            return parameters;
        }

        public DynamicParameters Update()
        {
            parameters.Add("@ModifiedBy", paymentRequestHeader.PaymentRequestHeader.User);
            parameters.Add("@RETURNVALUE", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);


            return parameters;
        }

    }
}
