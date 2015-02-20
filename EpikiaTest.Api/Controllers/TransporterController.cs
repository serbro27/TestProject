using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EpikiaTest.BusinessLogic;
using EpikiaTest.ViewModel.Transporter;

namespace EpikiaTest.Api.Controllers
{
    public class TransporterController : ApiController
    {
        protected readonly ITransporterService TransporterService;

        public TransporterController(ITransporterService transporterService)
        {
            TransporterService = transporterService;
        }

        [HttpPost]
        public HttpResponseMessage AddCreadits(AddCreditsVm model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, TransporterService.AddCredits(model));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage RequestReuse(RequestReuseVm model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
                return Request.CreateResponse(HttpStatusCode.Created, TransporterService.RequestReuse(model));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
