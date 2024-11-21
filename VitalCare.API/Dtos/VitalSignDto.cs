using VitalCare.Core.Entities;

namespace VitalCare.API.Dtos
{
    public class VitalSignDto
    {
        public DateTime DateMeasured { get; set; }
        public VitalSignType VitalSignType { get; set; }
        public decimal Value { get; set; }
    }
}
