using System.ComponentModel.DataAnnotations;

namespace ReGenerationProjectAssignment_FundRaiser.Models
{
    public class Project_Tracker
    {
        [Key]
        public int TrackerId { get; set; }
        public int? Amount { get; set; }
        public User User { get; set; }
        public Project Project { get; set; }
        public Funding_Package Funding_Packages { get; set; }
        

    }
}
