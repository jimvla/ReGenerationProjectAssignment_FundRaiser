namespace ReGenerationProjectAssignment_FundRaiser.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public required User User { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public string VideoURL { get; set; }
        public required Category Category { get; set; }
        public int FundingGoal { get; set; }

        //public List<Status_Update>? Status_Updates { get; set; }
        //public virtual IEnumerable<Status_Update> Status_Updates { get; set; } = new List<Status_Update>();
        public virtual IEnumerable<Funding_Package> Funding_Packages { get; set; } = new List<Funding_Package>();
        public virtual IEnumerable<Transaction_Tracker> Transaction_Trackers { get; set; } = new List<Transaction_Tracker>();
        public virtual IEnumerable<Project_Tracker> Project_Trackers { get; set; } = new List<Project_Tracker>();


    }
}
