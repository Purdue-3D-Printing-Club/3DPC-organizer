using Organizer.Shared.Enums;
using Organizer.Shared.Models;

namespace Organizer.Shared.Views
{
    public class PendingJobSubmission
    {
        public string SubmitterName { get; set; }
        public string SubmitterEmail { get; set; }
        public string SupervisorName { get; set; }
        public string[] Files { get; set; }
        public string? Notes { get; set; }
        
        public PendingJobSubmission(string SubmitterName, string SubmitterEmail, string SupervisorName, string[] Files, string? Notes)
        {
            this.SubmitterName = SubmitterName;
            this.SubmitterEmail = SubmitterEmail;
            this.SupervisorName = SupervisorName;
            this.Files = Files;
            this.Notes = Notes;
        }
        public PendingJobSubmission(Job job)
        {
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