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
    public class SqlMetricRepository : IMetricRepository
    {
        private readonly SqlCommandExecutor executor;

        public SqlMetricRepository(string connectionString)
        {
            executor = new SqlCommandExecutor(connectionString);
        }

        public void SaveMetric(int metricId, string name, int isComplete)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            if (isComplete != 0 && isComplete != 1)
                throw new ArgumentNullException(nameof(isComplete));


            var d = new SaveMetricDataDelegate(metricId, name , isComplete);
            executor.ExecuteNonQuery(d);
        }

        public Metric RetrieveMetric(int metricId)
        {
            var d = new RetrieveMetricDataDelegate(metricId);
            return executor.ExecuteReader(d);
        }
    }
}

