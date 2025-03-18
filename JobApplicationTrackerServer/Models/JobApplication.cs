namespace JobApplicationTrackerServer.Models
{
    public class JobApplication
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string Status { get; set; } = "Applied"; // Default status
        public DateTime DateApplied { get; set; } = DateTime.UtcNow;
    }
}
