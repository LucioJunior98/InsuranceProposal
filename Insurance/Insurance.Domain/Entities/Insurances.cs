using Insurance.Domain.Entities.Base;
using Insurance.Domain.Enums;

namespace Insurance.Domain.Entities
{
    public class Insurances : BaseEntity
    {
        public string Name { get; set; }
        public string TaxNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public InsuranceStatus Status { get; set; }
        public InsuranceType Type { get; set; }
        public decimal InsuranceValue { get; set; }
    }
}
