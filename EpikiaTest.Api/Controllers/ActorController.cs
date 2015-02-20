using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EpikiaTest.BusinessLogic;
using EpikiaTest.ViewModel.Actor;

namespace EpikiaTest.Api.Controllers
{
    public class ActorController : ApiController
    {
        protected readonly IActorService ActorService;

        public ActorController(IActorService actorService)
        {
            ActorService = actorService;
        }

        [HttpPost]
        public HttpResponseMessage Create(CreateActorVm model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
                return Request.CreateResponse(HttpStatusCode.Created, ActorService.CreateActor(model));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
