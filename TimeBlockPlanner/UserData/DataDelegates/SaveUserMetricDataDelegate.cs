using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserData.Models;

namespace UserData.DataDelegates
{
    public class SaveUserMetricDataDelegate : DataDelegate
    {
        private readonly int userId;
        private readonly int metricTimeframeId;
        private readonly int metricId;
        private readonly DateTime date;
        private readonly int value;

        public SaveUserMetricDataDelegate(int userId, int metricTimeframeId, int metricId, DateTime date, int value)
           : base("User.SaveUserMetric")
        {
            this.userId = userId;
            this.metricTimeframeId = metricTimeframeId;
            this.metricId = metricId;
            this.date = date;
            this.value = value;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("UserId", userId);
            command.Parameters.AddWithValue("MetricTimeframeId", metricTimeframeId);
            command.Parameters.AddWithValue("MetricId", metricId);
            command.Parameters.AddWithValue("Date", date);
            command.Parameters.AddWithValue("Value", value);
        }
    }
}

