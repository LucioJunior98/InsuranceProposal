using Insurance.Domain.Entities.Base;

namespace Insurance.Domain.Entities
{
    public class Insured : BaseEntity
    {
        public long InsuranceId { get; set; }
        public string Name { get; set; }    
        public string TaxNumber { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
