using System;
using System.Linq;
using EpikiaTest.DAL;
using EpikiaTest.Model;
using EpikiaTest.ViewModel.Carrier;

namespace EpikiaTest.BusinessLogic.Implementation
{
    public class CarrierService : BaseService, ICarrierService
    {
        public CarrierService(IDbContext dbContext) : base(dbContext) { }

        public Guid AddContainer(AddContainerVm model)
        {
            var carrier = DbContext.Actors.OfType<Carrier>().FirstOrDefault(c => c.Name == model.CarrierName);
            if (carrier == null)
            {
                throw new Exception(String.Format("User with name {0} was not found", model.CarrierName));
            }
            var container = new Container
            {
                Id = Guid.NewGuid(),
                Price = model.Price,
                Size = model.Size,
                Carrier = carrier
            };
            DbContext.Containers.Add(container);
            DbContext.SaveChanges();
            return container.Id;
        }

        public void ApproveRequest(Guid requestId)
        {
            var reuse = DbContext.Reuses.Find(requestId);
            if (reuse == null)
            {
                throw new Exception(String.Format("Container with id {0} was not found", requestId));
            }
            if (reuse.Status == ReuseStatus.Rejected)
            {
                throw new Exception("Request has already been rejected");
            }
            if (reuse.Status == ReuseStatus.Approved)
            {
                throw new Exception("Request has already been approved");
            }
            var sameDateReuses = reuse.Container.Reuses.Where(r => r != reuse && r.DateOfReuse.Date == reuse.DateOfReuse.Date && r.Status == ReuseStatus.Pending).ToList();
            foreach (var sameDateReuse in sameDateReuses)
            {
                sameDateReuse.Status = ReuseStatus.Rejected;
                sameDateReuse.Transporter.Account.Credits += sameDateReuse.Price;
            }
            reuse.Status = ReuseStatus.Approved;
            DbContext.SaveChanges();
        }

        public void RejectRequest(Guid requestId)
        {
            var reuse = DbContext.Reuses.Find(requestId);
            if (reuse == null)
            {
                throw new Exception(String.Format("Container with id {0} was not found", requestId));
            }
            if (reuse.Status == ReuseStatus.Rejected)
            {
                throw new Exception("Request has already been rejected");
            }
            reuse.Status = ReuseStatus.Rejected;
            reuse.Transporter.Account.Credits += reuse.Price;
            DbContext.SaveChanges();
        }
    }
}
