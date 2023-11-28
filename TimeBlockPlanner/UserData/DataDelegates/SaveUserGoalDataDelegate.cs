using UserData.Models;
using DataAccess;

namespace UserData.DataDelegates
{
    public class SaveUserGoalDataDelegate : DataDelegate
    {
        private readonly int goalId;
        private readonly int userId;
        private readonly string name;
        private readonly string description;
        private readonly DateTime startDate;
        private readonly DateTime endDate;
        private readonly int isComplete;
        private readonly string progress;

        public SaveUserGoalDataDelegate(int goalId, int userId, string name, string description, DateTime startDate, DateTime endDate, int isComplete, string progress)
           : base("Person.SavePersonAddress")
        {
            this.goalId = goalId;
            this.userId = userId;
            this.name = name;
            this.description = description;
            this.startDate = endDate;
            this.isComplete = isComplete;
            this.progress = progress;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("GoalId", goalId);
            command.Parameters.AddWithValue("UserId", userId);
            command.Parameters.AddWithValue("Name", name);
            command.Parameters.AddWithValue("Description", description);
            command.Parameters.AddWithValue("StatDate", startDate);
            command.Parameters.AddWithValue("EndDate", endDate);
            command.Parameters.AddWithValue("IsComplete", isComplete);
            command.Parameters.AddWithValue("Progress", progress);
        }
    }
}
