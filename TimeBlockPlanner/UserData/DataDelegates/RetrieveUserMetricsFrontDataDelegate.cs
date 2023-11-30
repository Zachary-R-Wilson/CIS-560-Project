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
    public class RetrieveUserMetricFrontDataDelegate : DataReaderDelegate<IReadOnlyList<UserMetricFront>>
    {
        private readonly int userId;

        public RetrieveUserMetricFrontDataDelegate(int userId)
           : base("User.UserMetricFront")
        {
            this.userId = userId;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            var p = command.Parameters.Add("UserId", SqlDbType.Int);
            p.Value = userId;
        }

        public override IReadOnlyList<UserMetricFront> Translate(Command command, IDataRowReader reader)
        {
            var metricsFront = new List<UserMetricFront>();

            while (reader.Read())
            {
                metricsFront.Add(new UserMetricFront(
                   reader.GetInt32("UserId"),
                   reader.GetInt32("MetricTimeframeId"),
                   reader.GetInt32("MetricId"),
                   reader.GetString("MetricName"),
                   reader.GetString("MetricTimeframeName"),
                   reader.GetDateTime("Date", DateTimeKind.Local),
                   reader.GetInt32("Value")));
            }

            return metricsFront;
        }
    }
}