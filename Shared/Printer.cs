namespace Organizer.Shared
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
        public string Name { get; set; }
        public string Print { get; set; }
        public PrinterState Status { get; set; }
    }
}