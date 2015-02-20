using System;
using EpikiaTest.DAL;

namespace EpikiaTest.BusinessLogic.Implementation
{
    public abstract class BaseService : IDisposable
    {
        private bool _disposed;
        protected readonly IDbContext DbContext;

        protected BaseService(IDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    DbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
