using Insurance.Domain.Enums;

namespace InsuranceApi.Models
{
    public class ProposalHiringModal
    {
        public long InsurancesId { get; set; }
        public string Name { get; set; }
        public string TaxNumber { get; set; }
        public ProposalHiringStatus Status { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
