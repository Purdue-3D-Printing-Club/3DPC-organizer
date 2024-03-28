using Organizer.Shared.Enums;
using Organizer.Shared.Models;

namespace Organizer.Shared.Views
{
    public class PrinterOverview
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PrinterType { get; set; }
        public PrinterState Status { get; set; }
        public Guid? AssignedJobId { get; set; }
        public string? AssignedJobUser { get; set; }

        public PrinterOverview(Guid id, string name, string printerType, PrinterState status, Guid? assignedJobId, string? assignedJobUser)
        {
            Id = id;
            Name = name;
            PrinterType = printerType;
            Status = status;
            AssignedJobId = assignedJobId;
            AssignedJobUser = assignedJobUser;
        }
        public PrinterOverview(Printer printer, Job? job)
        {
            Id = printer.Id;
            Name = printer.Name;
            PrinterType = printer.PrinterType;
            Status = printer.Status;
            AssignedJobId = printer.AssignedJobId;
            AssignedJobUser = job?.UserSubmitting;
        }
    }

    public class PrinterDetail
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PrinterType { get; set; }
        public PrinterState Status { get; set; }
        public Guid? AssignedJobId { get; set; }
        public string? AssignedJobUser { get; set; }
        public JobState? AssignedJobStatus { get; set; }
        public string[]? AssignedJobFiles { get; set; }
        public string? AssignedJobNotes { get; set; }
        public float? AssignedJobEstimatedFilament { get; set; }

        public PrinterDetail(Guid id, string name, string printerType, PrinterState status, Guid? assignedJobId, string? assignedJobUser, JobState? assignedJobStatus, string[]? assignedJobFiles, string? assignedJobNotes, float? assignedJobEstimatedFilament)
        {
            Id = id;
            Name = name;
            PrinterType = printerType;
            Status = status;
            AssignedJobId = assignedJobId;
            AssignedJobUser = assignedJobUser;
            AssignedJobStatus = assignedJobStatus;
            AssignedJobFiles = assignedJobFiles;
            AssignedJobNotes = assignedJobNotes;
            AssignedJobEstimatedFilament = assignedJobEstimatedFilament;
        }
        public PrinterDetail(Printer printer, Job? job)
        {
            Id = printer.Id;
            Name = printer.Name;
            PrinterType = printer.PrinterType;
            Status = printer.Status;
            AssignedJobId = printer.AssignedJobId;
            AssignedJobUser = job?.UserSubmitting;
            AssignedJobStatus = job?.Status;
            AssignedJobFiles = job?.Files;
            AssignedJobNotes = job?.Notes;
            AssignedJobEstimatedFilament = job?.EstimatedFilament;
        }
    }
}