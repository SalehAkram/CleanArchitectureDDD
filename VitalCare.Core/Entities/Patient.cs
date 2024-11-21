using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitalCare.Core.Contracts;

namespace VitalCare.Core.Entities
{
    public class Patient : Entity<int>, IAggregateRoot
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        private readonly List<VitalSign> _vitalSigns;
        public IReadOnlyCollection<VitalSign> VitalSigns => _vitalSigns;
        public Patient() { }

        public Patient(int id, string firstName, string lastName) 
        { 
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
        public void ProcessVitalSigns(DateTime dateMeasured, VitalSignType vitalSignType, decimal value)
        {
            //inlclude business invariants here

            // Add the new vital sign reading
            var vs = new VitalSign(dateMeasured, vitalSignType, value);
            _vitalSigns.Add(vs);
        }
    }
}
