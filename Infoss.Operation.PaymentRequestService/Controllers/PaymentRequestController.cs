using Infoss.Operation.PaymentRequestService.Repositories;
using Infoss.Reg.UserAccessModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Infoss.Operation.PaymentRequestService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PaymentRequestController : ControllerBase
    {
        private readonly IPaymentRequestRepository paymentRequestRepository;
        public IConfigurationRoot Configuration { get; }

        public PaymentRequestController()
        {
            IConfiguration Configuration = new ConfigurationBuilder().
                SetBasePath(Directory.GetCurrentDirectory()).
                AddJsonFile("appsettings.json").
                Build();

            paymentRequestRepository = new PaymentRequestRepository(Configuration);
        }


        [Route("PostByPage")]
        [HttpPost]
        public async Task<ResponsePage<PaymentRequestResponsePage>> Post(int pageNumber, int pageSize, [FromBody] PaymentRequestGetPageRequest userLogin)
        {
            var route = Request.Path.Value;

            var requestPage = new PaymentRequestPage();
            requestPage.RowStatus = "ACT";
            requestPage.UserLogin = userLogin;
            requestPage.PageNumber = pageNumber;
            requestPage.PageSize = pageSize;

            var responsePage = await paymentRequestRepository.Read(requestPage);
            return responsePage;

        }

        [Route("PostById")]
        [HttpPost]
        public async Task<ResponsePage<PaymentRequestResponseId>> Post(int id, [FromBody] UserLogin userLogin)
        {
            var route = Request.Path.Value;

            var requestId = new RequestId();
            requestId.UserLogin = userLogin;
            requestId.Id = id;

            var responsePage = await paymentRequestRepository.Read(requestId);
            return responsePage;

        }

        [Route("Create")]
        [HttpPost]
        public async Task<Response> Post([FromBody] PaymentRequestTransaction paymentRequest)
        {
            return await paymentRequestRepository.Create(paymentRequest);
        }

        [Route("Update")]
        [HttpPut]
        public async Task<Response> Put([FromBody] PaymentRequestTransaction paymentRequest)
        {
            return await paymentRequestRepository.Update(paymentRequest);
        }

        [Route("Delete")]
        [HttpPut]
        public async Task<Response> Delete(int id, [FromBody] UserLogin userLogin)
        {
            var route = Request.Path.Value;

            var requestId = new RequestId();
            requestId.UserLogin = userLogin;
            requestId.Id = id;

            var responsePage = await paymentRequestRepository.Delete(requestId);
            return responsePage;

        }

        [Route("Approval")]
        [HttpPut]
        public async Task<Response> Approve([FromBody] PaymentRequestApproval paymentRequest)
        {
            return await paymentRequestRepository.Approval(paymentRequest);
        }

        [Route("UpdateStatusPrinting")]
        [HttpPut]
        public async Task<Response> PutStatusPrint([FromBody] PaymentRequestPrintingRequest paymentRequest)
        {
            return await paymentRequestRepository.UpdateStatusPrint(paymentRequest);
        }
    }
}
