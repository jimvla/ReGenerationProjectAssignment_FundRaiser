using System.ComponentModel.DataAnnotations;

namespace ReGenerationProjectAssignment_FundRaiser.Models
{
    public class Project_Tracker
    {
        [Key]
        public int TrackerId { get; set; }
        public int Amount { get; set; }
    }
}
