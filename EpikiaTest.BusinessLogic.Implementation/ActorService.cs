using System;
using EpikiaTest.DAL;
using EpikiaTest.Model;
using EpikiaTest.ViewModel.Actor;

namespace EpikiaTest.BusinessLogic.Implementation
{
    public class ActorService : BaseService, IActorService
    {
        public ActorService(IDbContext dbContext) : base(dbContext) { }

        public Guid CreateActor(CreateActorVm model)
        {
            Actor actor;
            switch (model.Type)
            {
                case ActorType.Carrier:
                    actor = new Carrier();
                    break;
                case ActorType.Transporter:
                    actor = new Transporter();
                    ((Transporter)actor).Account = new Account
                    {
                        Credits = 0
                    };
                    break;
                default:
                    actor = new Carrier();
                    break;
            }
            actor.Id = Guid.NewGuid();
            actor.Active = true;
            actor.DateOfRegistration = DateTime.Now;
            actor.Name = model.Name;
            DbContext.Actors.Add(actor);
            DbContext.SaveChanges();
            return actor.Id;
        }
    }
}
