using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeBlockData.Models
{
    public class MetricTimeFrame 
    {
        public int MetricTimeFrameID { get; }
        public string Name { get; }
        public bool IsDeleted = false;

        public MetricTimeFrame(int metric, string name, bool isDeleted)
        {
            MetricTimeFrameID = metric;
            Name = name;
            IsDeleted = isDeleted;
        }
    }
}
