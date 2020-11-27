using System.Windows.Media;

namespace WpfScheduler
{
    public class Employee
    {
        public string Name { get; set; }
        public object ID { get; set; }
        public Brush BackgroundBrush { get; set; }
        public Brush ForegroundBrush { get; set; }
        public string ImageSource { get; set; }
    }
}
