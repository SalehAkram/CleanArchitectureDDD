using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitalCare.Core.Entities;

namespace VitalCare.Infra
{
    public static class PatientSeedData
    {
        public static List<Patient> GetPatients()
        {
            return new List<Patient>
            {
                new Patient(1, "Tommy", "Test"),
                new Patient(2, "Barry", "Test"),
                new Patient(3, "Sally", "Test"),

            };
        }
    }
}
