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

        public PrinterDetail()
        {
            Id = Guid.Empty;
            Name = "";
            PrinterType = "";
            Status = PrinterState.Offline;
            AssignedJob = null;
        }

        public PrinterDetail(Printer printer, Job? job)
        {
            Id = printer.Id;
            Name = printer.Name;
            PrinterType = printer.PrinterType;
            Status = printer.Status;
            AssignedJob = job;
        }
    }

    public class NewPrinter
    {
        public string Name { get; set; }
        public string PrinterType { get; set; }

        public NewPrinter()
        {
            Name = "";
            PrinterType = "";
        }

        public NewPrinter(string name, string printerType)
        {
            Name = name;
            PrinterType = printerType;
        }
    }
}
