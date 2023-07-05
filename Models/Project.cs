namespace ReGenerationProjectAssignment_FundRaiser.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public string VideoURL { get; set; }
        public Category Category { get; set; }
        public int FundingGoal { get; set; }
        public List<Status_Update>? Status_Updates { get; set; }


    }
}
