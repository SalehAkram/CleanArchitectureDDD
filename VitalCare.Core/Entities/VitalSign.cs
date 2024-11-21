using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitalCare.Core.Entities
{
    public enum VitalSignType
    {
        BloodPressure,
        Temperature,
        HeartRate

    }

    public class VitalSign: Entity<int>
    {
        public int PatientId { get; private set; }
        public DateTime DateMeasured { get; private set; }
        public VitalSignType VitalSignType { get; private set; }
        public decimal Value {  get; private set; }

        public VitalSign(DateTime dateMeasured, VitalSignType vitalSignType, decimal value)
        {
            DateMeasured = dateMeasured;
            VitalSignType = vitalSignType;
            Value = value;
        }
    }
}
