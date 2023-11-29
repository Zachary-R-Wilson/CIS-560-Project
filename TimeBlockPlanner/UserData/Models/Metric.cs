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
        public bool IsDeleted = false;
        public Metric(int metricID, string name, bool isDeleted)
        {
            MetricId = metricID;
            Name = name;
            IsDeleted = isDeleted;
        }
    }
}
