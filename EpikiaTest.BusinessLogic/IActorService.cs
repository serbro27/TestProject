using System;
using EpikiaTest.ViewModel.Actor;

namespace EpikiaTest.BusinessLogic
{
    public interface IActorService
    {
        Guid CreateActor(CreateActorVm model);
    }
}
