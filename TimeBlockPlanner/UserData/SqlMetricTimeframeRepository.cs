using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using UserData.Models;
using UserData.DataDelegates;

namespace UserData
{
    public class SqlMetricTimeframeRepository : IMetricTimeframeRepository
    {
        private readonly SqlCommandExecutor executor;

        public SqlMetricTimeframeRepository(string connectionString)
        {
            executor = new SqlCommandExecutor(connectionString);
        }

        public MetricTimeframe CreateMetricTimeframe(string name, int isDeleted)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("The parameter cannot be null or empty.", nameof(name));

            if (string.IsNullOrWhiteSpace(isDeleted.ToString()))
                throw new ArgumentException("The parameter cannot be null or empty.", nameof(isDeleted));

            var d = new CreateMetricTimeframeDataDelegate(name, isDeleted);
            return executor.ExecuteNonQuery(d);
        }

        public MetricTimeframe RetrieveMetricTimeframe(int metricTimeframeId)
        {
            var d = new RetrieveMetricTimeframeDataDelegate(metricTimeframeId);
            return executor.ExecuteReader(d);
        }


        public IReadOnlyList<MetricTimeframe> RetrieveMetricTimeframes()   
        {
            return executor.ExecuteReader(new RetrieveMetricTimeframesDataDelegate());
        }
    }
}
