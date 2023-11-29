using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserData.Models
{
    public class Metric
    {
        public int MetricId { get; }
        public string Name { get; }
        public int IsDeleted { get; }
        public Metric(int metricID, string name, int isDeleted)
        {
            MetricId = metricID;
            Name = name;
            IsDeleted = isDeleted;
        }
    }
}
