using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeBlockData.Models
{
    public class UserMetric 
    {
        public int UserID { get; }
        public MetricTimeFrame metricTimeFrame
        {
            get;
        }
        public Metric metric { get; }
        public DateTime Date { get; }
        public UserMetric(int userID, MetricTimeFrame metricTF, Metric _metric, DateTime date)
        {
            UserID = userID;
            metricTimeFrame = metricTF;
            metric = _metric;
            Date = date;
        }
    }
}

