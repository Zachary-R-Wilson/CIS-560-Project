using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserData.Models
{
    public class TimeBlock
    {
        public int TimeBlockID { get; }
        public int UserID { get; }
        public string Name { get; }
        public string Description { get; }
        public DateTime Date { get; }
        private DateTimeOffset TimePeriod { get; }

        public TimeBlock(int timeBlockId, int userID, string name, string description, DateTime date, DateTimeOffset timeP)
        {
            TimeBlockID = timeBlockId;
            UserID = userID;
            Name = name;
            Description = description;
            Date = date;
            TimePeriod = timeP;
        }
    }
}
