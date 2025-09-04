using Insurance.Domain.Enums;

namespace InsuranceApi.Models
{
    public class CreateProposalModel
    {
        public string Name { get; set; }
        public string TaxNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public InsuranceStatus Status { get; set; }
        public InsuranceType Type { get; set; }
        public decimal InsuranceValue { get; set; }
    }
}
