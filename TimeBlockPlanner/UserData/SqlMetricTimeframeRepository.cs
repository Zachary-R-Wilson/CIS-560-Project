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

        public void SaveMetricTimeframe(int metricTimeframeId, string name, int isComplete)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            if (isComplete != 0 && isComplete != 1)
                throw new ArgumentNullException(nameof(isComplete));


            var d = new SaveMetricTimeframeDataDelegate(metricTimeframeId, name, isComplete);
            executor.ExecuteNonQuery(d);
        }



        public MetricTimeframe GetMetricTimeframeIdGivenName(string name)
        {
            return executor.ExecuteReader(new GetMetricTimeframeIdGivenNameDelegate(name));
        }
    }
}
