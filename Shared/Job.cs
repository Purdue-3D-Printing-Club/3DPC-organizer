namespace Organizer.Shared
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
        public string id { get; set; }
        public string userSubmittingId { get; set; }
        public string supervisorId { get; set; }
        public JobState status { get; set; }
        public string[] files { get; set; }
        public string notes { get; set; }
        public float estimatedFilament { get; set; }
    }
}