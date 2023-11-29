using DataAccess;
using UserData.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace UserData.DataDelegates
{
    public class RetrieveGoalsForUserDataDelegate : DataReaderDelegate<IReadOnlyList<Goal>>
    {
        private readonly int userId;

        public RetrieveGoalsForUserDataDelegate(int userId)
           : base("User.RetrieveGoalsForUser")
        {
            this.userId = userId;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            var p = command.Parameters.Add("UserId", SqlDbType.Int);
            p.Value = userId;
        }
        public override IReadOnlyList<Goal> Translate(Command command, IDataRowReader reader)
        {
            var goals = new List<Goal>();

            while (reader.Read())
            {
                goals.Add(new Goal(
                   reader.GetInt32("GoalId"),
                   reader.GetInt32("UserId"),
                   reader.GetString("Name"),
                   reader.GetString("Description"),
                   reader.GetDateTime("StartDate", DateTimeKind.Local),
                   reader.GetDateTime("EndDate", DateTimeKind.Local),
                   reader.GetInt32("IsComplete"),
                   reader.GetString("Progress")));
            }

            return goals;
        }
    }
}