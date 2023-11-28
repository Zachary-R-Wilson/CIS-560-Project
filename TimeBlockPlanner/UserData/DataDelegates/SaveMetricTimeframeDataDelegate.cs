using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserData.DataDelegates
{
    internal class SaveMetricTimeframeDataDelegate : DataDelegate
    {
        public readonly int metricTimeframeId;
        public readonly string name;
        public readonly int isDeleted;

        public SaveMetricTimeframeDataDelegate(int metricTimeframeId, string name, int isDeleted)
           : base("User.SaveMetricTimeframe")
        {
            this.metricTimeframeId = metricTimeframeId;
            this.name = name;
            this.isDeleted = isDeleted;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("MetricTimeframeId", metricTimeframeId);
            command.Parameters.AddWithValue("Name", name);
            command.Parameters.AddWithValue("IsDeleted", isDeleted);

        }

    }
}
