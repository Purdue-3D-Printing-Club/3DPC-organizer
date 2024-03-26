namespace Organizer.Shared.Models
{
    public enum JobState
    {
        Pending,
        InProgress,
        Completed,
        Failed,
        Cancelled
    }
    public class Job
    {
        public Guid Id { get; set; }
        public string UserSubmitting { get; set; }
        public string Supervisor { get; set; }
        public JobState Status { get; set; }
        public string[] Files { get; set; }
        public string? Notes { get; set; }
        public float? EstimatedFilament { get; set; }
    }
}