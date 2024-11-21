using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitalCare.Core.Contracts
{
    public interface IUnitOfWork
    {
        IPatientRepository PatientRepository { get; }

        Task<int> SaveChangesAsync();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
