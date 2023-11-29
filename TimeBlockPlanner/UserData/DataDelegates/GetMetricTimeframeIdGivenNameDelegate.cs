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
    public class GetMetricTimeframeIdGivenNameDelegate : DataReaderDelegate<MetricTimeframe>
    {
        private readonly string name;

        public GetMetricTimeframeIdGivenNameDelegate(string name)
           : base("User.GetMetricTimeframeIdGivenName")
        {
            this.name = name;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("Name", name);
        }

        public override MetricTimeframe Translate(Command command, IDataRowReader reader)
        {
            if (!reader.Read())
                return null;

            return new MetricTimeframe(
               reader.GetInt32("MetricTimeframeId"),
               name,
               reader.GetInt32("IsDeleted"));
        }
    }
}

