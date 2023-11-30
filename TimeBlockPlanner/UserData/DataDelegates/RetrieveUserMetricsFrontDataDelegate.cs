using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserData.Models;

namespace UserData.DataDelegates
{
    public class RetrieveUserMetricFrontDataDelegate : DataReaderDelegate<IReadOnlyList<UserMetricFront>>
    {
        public RetrieveUserMetricFrontDataDelegate()
           : base("User.RetrieveUserMetricFront")
        {
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
                   reader.GetString("MetricTimeframeName")));
                   reader.GetDateTime("MetricTimeframeName", DateTimeKind.Local),
                   reader.GetInt32("Value"));
            }

            return metricsFront;
        }
    }
}