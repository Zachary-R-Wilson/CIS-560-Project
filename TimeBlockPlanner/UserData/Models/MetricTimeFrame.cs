using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserData.Models
{
    public class MetricTimeframe 
    {
        public int MetricTimeframeId { get; }
        public string Name { get; }
        public int IsDeleted { get; }

        public MetricTimeframe(int metric, string name, int isDeleted)
        {
            MetricTimeframeId = metric;
            Name = name;
            IsDeleted = isDeleted;
        }
    }
}
