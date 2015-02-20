using System;
using System.Linq;
using EpikiaTest.DAL;
using EpikiaTest.Model;
using EpikiaTest.ViewModel.Transporter;

namespace EpikiaTest.BusinessLogic.Implementation
{
    public class TransporterService : BaseService, ITransporterService
    {
        public TransporterService(IDbContext dbContext) : base(dbContext) { }

        public decimal AddCredits(AddCreditsVm model)
        {
            var transporter = DbContext.Actors.OfType<Transporter>().FirstOrDefault(t => t.Name == model.Name);
            if (transporter == null)
            {
                throw new Exception(String.Format("User with name {0} was not found", model.Name));
            }
            transporter.Account.Credits += model.Amount;
            DbContext.SaveChanges();
            return transporter.Account.Credits;
        }

        public Guid RequestReuse(RequestReuseVm model)
        {
            var transporter = DbContext.Actors.OfType<Transporter>().FirstOrDefault(t => t.Name == model.TransportersName);
            if (transporter == null)
            {
                throw new Exception(String.Format("User with name {0} was not found", model.TransportersName));
            }
            var container = DbContext.Containers.Find(model.ContainerId);
            if (container == null)
            {
                throw new Exception(String.Format("Container with id {0} was not found", model.ContainerId));
            }
            var sameDateReuses = container.Reuses.FirstOrDefault(r => r.DateOfReuse.Date == model.DateOfReuse.Date && r.Status == ReuseStatus.Approved);
            if (sameDateReuses != null)
            {
                throw new Exception("Container has already been reserved for this date");
            }
            var reuse = new Reuse
            {
                Id = Guid.NewGuid(),
                Status = ReuseStatus.Pending,
                DateOfReuse = model.DateOfReuse,
                Transporter = transporter,
                Container = container,
                Price = container.Price
            };
            transporter.Account.Credits -= reuse.Price;
            DbContext.SaveChanges();
            return reuse.Id;
        }
    }
}
