using Organizer.Shared.Enums;
using Organizer.Shared.Models;

namespace Organizer.Shared.Views
{

    public class PrinterDetail
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PrinterType { get; set; }
        public PrinterState Status { get; set; }
        public Job? AssignedJob { get; set; }

        public PrinterDetail(Printer printer, Job? job)
        {
            Id = printer.Id;
            Name = printer.Name;
            PrinterType = printer.PrinterType;
            Status = printer.Status;
            AssignedJob = job;
        }
    }
}