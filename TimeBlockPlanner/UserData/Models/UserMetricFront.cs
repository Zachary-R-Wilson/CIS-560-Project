using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserData.Models
{
    public class UserMetricFront
    {
        public int UserId { get; set; }

        public int MetricTimeframeId { get; set; }

        public int MetricId { get; set; }

        public string MetricName { get; set; }

        public string MetricTimeframeName { get; set; }

        public DateTime Date { get; set; }

        public int Value { get; set; }
    }
}
