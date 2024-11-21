using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using VitalCare.Core.Entities;

namespace VitalCare.Core.Contracts
{
    public interface IPatientRepository : IPatientRepository<Patient>
    {
        //Extend the this repository with custom contracts, including the default ones provided by IRepository if needed
        Task<List<Patient>> GetPatientsByIdsAsync(List<int> patientIds, bool includeVitalSigns = false);

    }
}
