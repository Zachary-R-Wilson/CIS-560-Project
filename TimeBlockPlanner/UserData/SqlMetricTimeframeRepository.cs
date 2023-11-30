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

        public void CreateMetricTimeframe(string name, int isDeleted)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("The parameter cannot be null or empty.", nameof(name));

            if (string.IsNullOrWhiteSpace(isDeleted.ToString()))
                throw new ArgumentException("The parameter cannot be null or empty.", nameof(isDeleted));

            var d = new CreateMetricTimeframeDataDelegate(name, isDeleted);
            executor.ExecuteNonQuery(d);
        }

        /* REAGAN FIX
        public MetricTimeframe RetrieveMetricTimeframe(int metricTimeframeId)
        {
            var d = new RetrieveMetricTimeframesDataDelegate();
            return executor.ExecuteReader(d);
        }

        */
        public IReadOnlyList<MetricTimeframe> RetrieveAllMetricTimeframes()   
        {
            return executor.ExecuteReader(new RetrieveMetricTimeframesDataDelegate());
        }

        public IReadOnlyList<MetricTimeframe> RetrieveMetricTimeframes(int metricTimeframeId)
        {
            //return executor.ExecuteReader(new RetrieveMetricTimeframesDataDelegate());
            var d = new RetrieveMetricTimeframesDataDelegate();
            return executor.ExecuteReader(d);
        }


        public MetricTimeframe GetMetricTimeframeIdGivenName(string name)
        {
            return executor.ExecuteReader(new GetMetricTimeframeIdGivenNameDelegate(name));
        }
    }
}
