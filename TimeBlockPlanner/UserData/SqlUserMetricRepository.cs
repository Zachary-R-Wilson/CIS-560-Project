using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserData.DataDelegates;
using UserData.Models;

namespace UserData
{
    public class SqlUserMetricRepository : IUserMetricRepository
    {
        private readonly SqlCommandExecutor executor;

        public SqlUserMetricRepository(string connectionString)
        {
            executor = new SqlCommandExecutor(connectionString);
        }

        public void SaveUserMetric(int userId, int metricTimeframeId, int metricId, DateTime date, int value)
        {
           
            var d = new SaveUserMetricDataDelegate(userId, metricTimeframeId, metricId, date, value);
            executor.ExecuteNonQuery(d);
        }

        public IReadOnlyList<UserMetric> RetrieveUserMetrics(int userId)
        {
            var d = new RetrieveUserMetricsForUserDataDelegate(userId);
            return executor.ExecuteReader(d);
        }

        public IReadOnlyList<UserMetricFront> RetrieveUserMetricsFront(int userId)
        {
            var d = new RetrieveUserMetricsFrontDataDelegate(userId);
            return executor.ExecuteReader(d);
        }
    }
}