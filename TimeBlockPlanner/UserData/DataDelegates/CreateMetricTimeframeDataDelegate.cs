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
    public class CreateMetricTimeframeDataDelegate : NonQueryDataDelegate<MetricTimeframe>
    {

        public readonly string name;
        public readonly int isDeleted;


        public CreateMetricTimeframeDataDelegate(string name, int isDeleted)
           : base("User.CreateMetricTimeframe")
        {
            this.name = name;
            this.isDeleted = isDeleted;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("Name", name);
            command.Parameters.AddWithValue("IsDeleted", isDeleted);


            var p = command.Parameters.Add("MetricTimeframeId", SqlDbType.Int);     
            p.Direction = ParameterDirection.Output;                       // declaring the command as output for the store procedure 
        }

        public override MetricTimeframe Translate(Command command)
        {
            return new MetricTimeframe(command.GetParameterValue<int>("MetricTimeframeId"), name, isDeleted);
        }
    }
}
