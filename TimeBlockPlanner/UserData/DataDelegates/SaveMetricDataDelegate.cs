using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserData.DataDelegates
{
    public class SaveMetricDataDelegate : DataDelegate
    {
        public readonly int metricId;
        public readonly string name;
        public readonly int isDeleted;

        public SaveMetricDataDelegate(int metricId, string name, int isDeleted)
           : base("User.SaveMetric")
        {
            this.metricId = metricId;
            this.name = name;
            this.isDeleted = isDeleted;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("MetricTimeframeId", metricId);
            command.Parameters.AddWithValue("Name", name);
            command.Parameters.AddWithValue("IsDeleted", isDeleted);

        }

    }
}