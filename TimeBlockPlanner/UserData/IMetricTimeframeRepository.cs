using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserData.Models;

namespace UserData
{
    public class IMetricTimeframeRepository
    {

        IReadOnlyList<MetricTimeframe> RetrieveMetricTimeframes();

       
        MetricTimeframe RetrieveMetricTimeframe(int metricTimeframeId);

        MetricTimeframe CreateMetricTimeframe(string name, int isDeleted);
    }
}


