using Organizer.Shared.Enums;
using Organizer.Shared.Models;

namespace Organizer.Shared.Views
{
    public class PendingJobSubmission
    {
        public Guid Id { get; set; }
        public string SubmitterName { get; set; }
        public string SubmitterEmail { get; set; }
        public string SupervisorName { get; set; }
        public string[] Files { get; set; }
        public string? Notes { get; set; }

        public PendingJobSubmission()
        {
            Id = Guid.Empty;
            SubmitterName = "";
            SubmitterEmail = "";
            SupervisorName = "";
            Files = Array.Empty<string>();
            Notes = null;
        }

        public PendingJobSubmission(
            Guid Id,
            string SubmitterName,
            string SubmitterEmail,
            string SupervisorName,
            string[] Files,
            string? Notes
        )
        {
            this.Id = Id;
            this.SubmitterName = SubmitterName;
            this.SubmitterEmail = SubmitterEmail;
            this.SupervisorName = SupervisorName;
            this.Files = Files;
            this.Notes = Notes;
        }

        public PendingJobSubmission(Job job)
        {
            Id = job.Id;
            SubmitterName = job.SubmitterName;
            SubmitterEmail = job.SubmitterEmail;
            SupervisorName = job.SupervisorName;
            Files = job.Files;
            Notes = job.Notes;
        }
    }

    public class ActiveJob
    {
        public Guid Id { get; set; }
        public string SubmitterName { get; set; }
        public string SubmitterEmail { get; set; }
        public string SupervisorName { get; set; }
        public string[] Files { get; set; }
        public JobState Status { get; set; }
        public DateTime SubmittedTime { get; set; }
        public DateTime StartedTime { get; set; }
        public string? Notes { get; set; }
        public double? EstimatedFilament { get; set; }
        public string[]? FailureNotes { get; set; }

        public ActiveJob()
        {
            Id = Guid.Empty;
            SubmitterName = "";
            SubmitterEmail = "";
            SupervisorName = "";
            Files = Array.Empty<string>();
            Status = JobState.Pending;
            SubmittedTime = DateTime.UnixEpoch;
            StartedTime = DateTime.UnixEpoch;
            Notes = null;
            EstimatedFilament = null;
            FailureNotes = null;
        }

        public ActiveJob(Job job)
        {
            Id = job.Id;
            SubmitterName = job.SubmitterName;
            SubmitterEmail = job.SubmitterEmail;
            SupervisorName = job.SupervisorName;
            Files = job.Files;
            Status = job.Status;
            SubmittedTime = job.SubmittedTime ?? DateTime.UnixEpoch;
            StartedTime = job.StartedTime ?? DateTime.UnixEpoch;
            Notes = job.Notes;
            EstimatedFilament = job.EstimatedFilament;
            FailureNotes = job.FailureNotes;
        }
    }

    public class CompletedJob
    {
        public Guid Id { get; set; }
        public string SubmitterName { get; set; }
        public string SubmitterEmail { get; set; }
        public string SupervisorName { get; set; }
        public JobState Status { get; set; }
        public DateTime SubmittedTime { get; set; }
        public DateTime StartedTime { get; set; }
        public DateTime CompletedTime { get; set; }
        public string? Notes { get; set; }
        public double? EstimatedFilament { get; set; }
        public string[]? FailureNotes { get; set; }

        public CompletedJob()
        {
            Id = Guid.Empty;
            SubmitterName = "";
            SubmitterEmail = "";
            SupervisorName = "";
            Status = JobState.Pending;
            SubmittedTime = DateTime.UnixEpoch;
            StartedTime = DateTime.UnixEpoch;
            CompletedTime = DateTime.UnixEpoch;
            Notes = null;
            EstimatedFilament = null;
            FailureNotes = null;
        }

        public CompletedJob(Job job)
        {
            Id = job.Id;
            SubmitterName = job.SubmitterName;
            SubmitterEmail = job.SubmitterEmail;
            SupervisorName = job.SupervisorName;
            Status = job.Status;
            SubmittedTime = job.SubmittedTime ?? DateTime.UnixEpoch;
            StartedTime = job.StartedTime ?? DateTime.UnixEpoch;
            CompletedTime = job.CompletedTime ?? DateTime.UnixEpoch;
            Notes = job.Notes;
            EstimatedFilament = job.EstimatedFilament;
            FailureNotes = job.FailureNotes;
        }
    }
}
