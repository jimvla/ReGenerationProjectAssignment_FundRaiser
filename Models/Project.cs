using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReGenerationProjectAssignment_FundRaiser.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageURL { get; set; }
        public string? VideoURL { get; set; }
        public int FundingGoal { get; set; }

        public int TotalAmount { get; set; }
        //Foreign Key
        [Display(Name = "Category")]
        public virtual int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }
        public User? User { get; set; }
        public Project_Tracker? Project_Tracker { get; set; }
        public virtual IEnumerable<Funding_Package> Funding_Packages { get; set; } = new List<Funding_Package>();


        //public List<Status_Update>? Status_Updates { get; set; }
        //public virtual IEnumerable<Status_Update> Status_Updates { get; set; } = new List<Status_Update>();

        //public virtual IEnumerable<Project_Tracker> Project_Trackers { get; set; } = new List<Project_Tracker>();


    }
}
