using DataAccess;
using UserData.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace UserData.DataDelegates
{
    public class RetrieveUserMetricsForUserDataDelegate : DataReaderDelegate<IReadOnlyList<UserMetric>>
    {
        private readonly int userId;

        public RetrieveUserMetricsForUserDataDelegate(int userId)
           : base("User.RetrieveUserMetricsForUser")
        {
            this.userId = userId;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            var p = command.Parameters.Add("UserId", SqlDbType.Int);
            p.Value = userId;
        }
        public override IReadOnlyList<UserMetric> Translate(Command command, IDataRowReader reader)
        {
            var userMetrics = new List<UserMetric>();
            while (reader.Read())
            {
                userMetrics.Add(new UserMetric(
                   reader.GetInt32("UserId"),
                   reader.GetInt32("MetricTimeframeId"),
                   reader.GetInt32("MetricId"),
                   reader.GetDateTime("Date", DateTimeKind.Local),
                   reader.GetInt32("Value")));
            }

            return userMetrics;
        }
    }
}

