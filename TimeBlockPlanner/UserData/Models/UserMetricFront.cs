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


        public UserMetricFront(int userId, int metricTimeframeId, int metricId, string metricName, string metricTimeframeName, DateTime date, int value)
        {
            UserId = userId;
            MetricTimeframeId = metricTimeframeId;
            MetricId = metricId;
            MetricName = metricName;
            MetricTimeframeName = metricTimeframeName;
            Date = date;
            Value = value;

        }
    }
}
