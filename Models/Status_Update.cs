using System.ComponentModel.DataAnnotations;

namespace ReGenerationProjectAssignment_FundRaiser.Models
{
    public class Status_Update
    {
        [Key]
        public int StatusId { get; set; }
        public string? Message { get; set; }
        public required Project Project { get; set; }
        public DateTime DateTime { get; set; }
    }
}
