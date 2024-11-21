using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitalCare.Core.Contracts;
using VitalCare.Infra.Repository;

namespace VitalCare.Infra
{
    public class UnitOfWork : IUnitOfWork, IAsyncDisposable
    {
        private readonly VitalCareDbContext _context;
        public IPatientRepository PatientRepository { get; private set; }
        public UnitOfWork(VitalCareDbContext context)
        {
            _context = context;
            PatientRepository = new PatientRepository(_context);

        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// No matter an exception has been raised or not, this method always will dispose the DbContext 
        /// </summary>
        /// <returns></returns>
        public ValueTask DisposeAsync()
        {
            return _context.DisposeAsync();
        }
    }
}
