namespace ReGenerationProjectAssignment_FundRaiser.Models
{
    public class Transaction_Tracker
    {
        public string TransactionId { get; set; }
        public Project Project { get; set; }
        public Funding_Package FundingPackage { get; set; }
        public User User { get; set;}
    }
}
