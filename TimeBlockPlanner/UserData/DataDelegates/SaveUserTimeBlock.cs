using UserData.Models;
using DataAccess;
using System.Reflection.PortableExecutable;

namespace PersonData.DataDelegates
{
    internal class SavePersonAddressDataDelegate : DataDelegate
    {
        private readonly int timeBlockId;
        private readonly int userId;
        private readonly string name;
        private readonly string description;
        private readonly DateTime date;
        private readonly DateTimeOffset timePeriod;
 
        public SavePersonAddressDataDelegate(int timeBlockId, int userId, string name, string description, DateTime date,  DateTimeOffset timePeriod)
           : base("User.SaveUserTimeBlock")
        {
            this.timeBlockId = timeBlockId;
            this.userId = userId;
            this.name = name;
            this.description = description;
            this.date = date;
            this.timePeriod = timePeriod;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("TimeBlockId", timeBlockId);
            command.Parameters.AddWithValue("UserId", userId);
            command.Parameters.AddWithValue("Name", name);
            command.Parameters.AddWithValue("Description", description);
            command.Parameters.AddWithValue("Date", date);
            command.Parameters.AddWithValue("TimePeriod", timePeriod);
        }
    }
}