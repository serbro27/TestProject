using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EpikiaTest.BusinessLogic;
using EpikiaTest.ViewModel.Carrier;

namespace EpikiaTest.Api.Controllers
{
    public class CarrierController : ApiController
    {
        protected readonly ICarrierService CarrierService;

        public CarrierController(ICarrierService carrierService)
        {
            CarrierService = carrierService;
        }

        [HttpPost]
        public HttpResponseMessage AddContainer(AddContainerVm model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
                return Request.CreateResponse(HttpStatusCode.Created, CarrierService.AddContainer(model));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        public HttpResponseMessage ApproveRequest(string id)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid request ID");
            }
            try
            {
                CarrierService.ApproveRequest(guid);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        public HttpResponseMessage RejectRequest(string id)
        {
            Guid guid;
            if (!Guid.TryParse(id, out guid))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid request ID");
            }
            try
            {
                CarrierService.RejectRequest(guid);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
