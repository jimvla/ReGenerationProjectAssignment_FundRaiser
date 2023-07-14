using System.ComponentModel.DataAnnotations;

namespace ReGenerationProjectAssignment_FundRaiser.Models
{
    public class Project_Tracker
    {
        [Key]
        public int TrackerId { get; set; }
        public int Amount { get; set; }
        public virtual IEnumerable<Status_Update> Status_Updates { get; set; } = new List<Status_Update>();
        public virtual IEnumerable<Funding_Package> Funding_Packages { get; set; } = new List<Funding_Package>();

    }
}
