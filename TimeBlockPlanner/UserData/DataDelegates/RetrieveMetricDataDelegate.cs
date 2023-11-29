using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserData.Models;

namespace UserData.DataDelegates
{
    public class RetrieveMetricDataDelegate : DataReaderDelegate<Metric>
    {
        private readonly int metricId;

        public RetrieveMetricDataDelegate(int metricId)
           : base("User.RetrieveMetric")
        {
            this.metricId = metricId;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            var p = command.Parameters.Add("MetricId", SqlDbType.Int);
            p.Value = metricId;
        }

        public override Metric Translate(Command command, IDataRowReader reader)
        {
            if (!reader.Read())
                throw new RecordNotFoundException(metricId.ToString());

            return new Metric(metricId,
               reader.GetString("name"),
               reader.GetInt32("IsDeleted"));
        }
    }
}
