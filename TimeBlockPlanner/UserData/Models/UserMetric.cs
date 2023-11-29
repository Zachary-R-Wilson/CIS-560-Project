using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserData.Models
{
    public class UserMetric 
    {
        public int UserId { get; }
        public MetricTimeframe metricTimeframe
        {
            get;
        }
        public Metric metric { get; }
        public DateTime Date { get; }

        public int Value { get; }

        public UserMetric(int userID, MetricTimeframe metricTf, Metric _metric, DateTime date, int value)
        {
            UserId = userID;
            metricTimeframe = metricTf;
            metric = _metric;
            Date = date;
            Value = value;
        }
    }
}

