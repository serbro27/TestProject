using System;
using EpikiaTest.ViewModel.Transporter;

namespace EpikiaTest.BusinessLogic
{
    public  interface ITransporterService
    {
        decimal AddCredits(AddCreditsVm model);
        Guid RequestReuse(RequestReuseVm model);
    }
}
