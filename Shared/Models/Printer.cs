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
        public string id { get; set; }
        public string name { get; set; }
        public PrinterState status { get; set; }
        public string? assignedJobId { get; set; }
    }
}