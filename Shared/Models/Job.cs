using Organizer.Shared.Enums;
using Organizer.Shared.Views;

namespace Organizer.Shared.Models
{
    public class Job
    {
        public Guid Id { get; set; }
        public string SubmitterName { get; set; }
        public string SubmitterEmail { get; set; }
        public string SupervisorName { get; set; }
        public DateTime? SubmittedTime { get; set; }
        public DateTime? StartedTime { get; set; }
        public DateTime? CompletedTime { get; set; }
        public JobState Status { get; set; }
        public string[] Files { get; set; }
        public string? Notes { get; set; }
        public double? EstimatedFilament { get; set; }
        public string[]? FailureNotes { get; set; }

        public Job(
            string SubmitterName,
            string SubmitterEmail,
            string SupervisorName,
            string[] Files,
            string? Notes,
            double? EstimatedFilament
        )
        {
            Id = Guid.NewGuid();
            this.SubmitterName = SubmitterName;
            this.SubmitterEmail = SubmitterEmail;
            this.SupervisorName = SupervisorName;
            this.Files = Files;
            this.Notes = Notes;
            this.EstimatedFilament = EstimatedFilament;
            Status = JobState.Pending;
        }

        public Job(PendingJobSubmission submission)
        {
            Id = Guid.NewGuid();
            SubmitterName = submission.SubmitterName;
            SubmitterEmail = submission.SubmitterEmail;
            SupervisorName = submission.SupervisorName;
            Files = submission.Files;
            Notes = submission.Notes;
            Status = JobState.Pending;
            SubmittedTime = DateTime.UtcNow;
        }
    }
}
