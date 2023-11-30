using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserData.Models;

namespace UserData
{
    public interface IMetricTimeframeRepository
    {
        IReadOnlyList<MetricTimeframe> RetrieveMetricTimeframes(int metricTimeframeId);

        IReadOnlyList<MetricTimeframe> RetrieveAllMetricTimeframes();

        void CreateMetricTimeframe(string name, int isDeleted);

        MetricTimeframe GetMetricTimeframeIdGivenName(string name);

        
    }
}


