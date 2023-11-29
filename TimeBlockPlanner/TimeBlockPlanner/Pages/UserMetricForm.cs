using System.Reflection.Emit;
using System.Xml.Linq;

namespace TimeBlockPlanner.Pages
{
    public class UserMetricForm
    {
        public int metricTimeframeId { get; set; }

        public int metricId { get; set; }

        public string metricName { get; set; }

        public string metricTimeframeName { get; set; }

        public DateTime date { get; set; }

        public int value { get; set; }
    }
}