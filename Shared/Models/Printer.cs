using Organizer.Shared.Enums;

namespace Organizer.Shared.Models
{
    public class Printer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PrinterType { get; set; }
        public PrinterState Status { get; set; }
        public Guid? AssignedJobId { get; set; }

        public Printer(string name, string printerType)
        {
            Id = Guid.NewGuid();
            Name = name;
            PrinterType = printerType;
            Status = PrinterState.Offline;
            AssignedJobId = null;
        }
        public Printer()
        {
            Id = Guid.NewGuid();
            Name = "Nameless Printer";
            PrinterType = "Unknown";
            Status = PrinterState.Offline;
            AssignedJobId = null;
        }
    }
}