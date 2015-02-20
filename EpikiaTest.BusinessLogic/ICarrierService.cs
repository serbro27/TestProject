using System;
using EpikiaTest.ViewModel.Carrier;

namespace EpikiaTest.BusinessLogic
{
    public interface ICarrierService
    {
        Guid AddContainer(AddContainerVm model);
        void ApproveRequest(Guid requestId);
        void RejectRequest(Guid requestId);
    }
}
