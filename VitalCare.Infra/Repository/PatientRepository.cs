using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VitalCare.Core.Contracts;
using VitalCare.Core.Entities;

namespace VitalCare.Infra.Repository
{
    public class PatientRepository : IPatientRepository
    {
        protected readonly DbContext Context;

        private readonly DbSet<Patient> _dbSet;
        public PatientRepository(DbContext context)
        {
            Context = context;

            if (context != null)
            {
                _dbSet = context.Set<Patient>();
            }
        }
        public void Add(Patient entity)
        {
            _dbSet.Add(entity);
        }
        public void Remove(Patient entity)
        {
            _dbSet.Remove(entity);
        }
        public void Update(Patient entity)
        {
            _dbSet.Update(entity);
        }
        public async Task<Patient> FindBy(Expression<Func<Patient, bool>> predicate, params Expression<Func<Patient, object>>[] includes)
        {
            var query = _dbSet.Where(predicate);
            includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            var toReturn = await query.ToListAsync();
            return toReturn.FirstOrDefault();
        }

        public async Task<Patient> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id).ConfigureAwait(false);
        }

        public async Task<List<Patient>> GetPatientsByIdsAsync(List<int> patientIds, bool includeVitalSigns = false)
        {
            if (patientIds == null || !patientIds.Any())
            {
                return new List<Patient>();
            }

            var query = _dbSet.AsQueryable();
            // Eager load MeterReadings
            if (includeVitalSigns)
            {
                query = query.Include(p => p.VitalSigns);
            }

            return await query
                .Where(account => patientIds.Contains(account.Id))
                .ToListAsync();
        }
    }
}
