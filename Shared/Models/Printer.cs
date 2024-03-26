namespace Organizer.Shared.Models
{
    public enum PrinterState
        {
            Idle,
            Printing,
            Error,
            Offline
        }
    public class Printer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PrinterType { get; set; }
        public PrinterState Status { get; set; }
        public Guid? AssignedJobId { get; set; }
    }
}