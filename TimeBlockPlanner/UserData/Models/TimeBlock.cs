using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserData.Models
{
    public class TimeBlock
    {
        public int TimeBlockId { get; }
        public int UserId { get; }
        public string Name { get; }
        public string Description { get; }
        public DateTime Date { get; }
        public DateTimeOffset TimePeriod { get; }

        public TimeBlock(int timeBlockId, int userID, string name, string description, DateTime date, DateTimeOffset timeP)
        {
            TimeBlockId = timeBlockId;
            UserId = userID;
            Name = name;
            Description = description;
            Date = date;
            TimePeriod = timeP;
        }
    }
}
