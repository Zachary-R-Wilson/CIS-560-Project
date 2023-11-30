using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserData.Models;

namespace UserData
{
    public interface IMetricRepository
    {

        Metric RetrieveMetric(int metricId);

        void SaveMetric(int metricId, string name, int isDeleted);

    }


}

