using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReGenerationProjectAssignment_FundRaiser.Models
{
    public class Transaction_Tracker
    {
        [Key]
        public string TransactionId { get; set; }
        public Project Project { get; set; }
        public Funding_Package? FundingPackage { get; set; }
        public User User { get; set; }

    }
}
