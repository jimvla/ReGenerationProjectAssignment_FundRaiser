using System.ComponentModel.DataAnnotations;

namespace ReGenerationProjectAssignment_FundRaiser.Models
{
    public class Transaction_Tracker
    {
        [Key]
        public string TransactionId { get; set; }
        public required Project Project { get; set; }
        public required Funding_Package FundingPackage { get; set; }
        public required User User { get; set;}


    }
}
