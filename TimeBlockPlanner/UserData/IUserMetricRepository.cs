using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserData.Models;

namespace UserData
{
    public interface IUserMetricRepository
    {
        IReadOnlyList<UserMetric> RetrieveUserMetrics(int userId);

        void SaveUserMetric(int userId, int metricTimeframeId, int metricId, DateTime date, int value);
    }
}
