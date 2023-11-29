using System.Reflection.Emit;
using System.Xml.Linq;

namespace TimeBlockPlanner.Pages
{
    public class UserMetricForm
    {
        public int metricTimeframeId { get; set; }

        public int metricId { get; set; }

        private string _metricName = "";

        public string metricName => _metricName;

        private string _metricTimeframeName = "";

        public string metricTimeframeName => _metricTimeframeName;

        public DateTime date { get; set; }

        public int value { get; set; }
    }
}