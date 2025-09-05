using Insurance.Domain.Entities.Base;
using Insurance.Domain.Enums;

namespace Insurance.Domain.Entities
{
    public class ProposalHiring : BaseEntity
    {
        public long InsurancesId { get; set; }
        public string Name { get; set; }
        public string TaxNumber { get; set; }
        public ProposalHiringStatus Status { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
