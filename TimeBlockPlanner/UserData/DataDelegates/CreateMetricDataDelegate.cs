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
    public class CreateMetricDataDelegate : NonQueryDataDelegate<Metric>
    {

        public readonly string name;
        public readonly int isDeleted;


        public CreateMetricDataDelegate(string name, int isDeleted)
           : base("User.CreateMetric")
        {
            this.name = name;
            this.isDeleted = isDeleted;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("Name", name);
            command.Parameters.AddWithValue("IsDeleted", isDeleted);


            var p = command.Parameters.Add("MetricId", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;                       // declaring the command as output for the store procedure 
        }

        public override Metric Translate(Command command)
        {
            return new Metric(command.GetParameterValue<int>("MetricId"), name, isDeleted);
        }
    }
}


