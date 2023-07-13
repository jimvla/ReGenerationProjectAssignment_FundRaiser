namespace ReGenerationProjectAssignment_FundRaiser.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurName { get; set; }

        public virtual IEnumerable<Project> Projects { get; set; } = new List<Project>();
        public virtual IEnumerable<Transaction_Tracker> Transaction_Trackers { get; set; } = new List<Transaction_Tracker>();
    }
}
