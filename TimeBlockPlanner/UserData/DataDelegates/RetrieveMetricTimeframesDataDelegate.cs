using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UserData.Models;

namespace UserData.DataDelegates
{
    public class RetrieveMetricTimeframesDataDelegate : DataReaderDelegate<IReadOnlyList<MetricTimeframe>>
    {
        public RetrieveMetricTimeframesDataDelegate()
           : base("User.RetrieveMetricTimeframe")
        {
        }

        public override IReadOnlyList<MetricTimeframe> Translate(Command command, IDataRowReader reader)
        {
            var metricTimeframes = new List<MetricTimeframe>();

            while (reader.Read())
            {
                metricTimeframes.Add(new MetricTimeframe(
                   reader.GetInt32("MetricTimeframeId"),
                   reader.GetString("Name"),
                   reader.GetInt32("IsDeleted")));
            }

            return metricTimeframes;
        }
    }
}