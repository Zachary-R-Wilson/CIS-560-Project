using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeBlockData.Models
{
    public class TimeBlock
    {
        public int TimeBlockID { get; }
        public int UserID { get; }
        public string Name { get; }
        public string Description { get; }
        public DateTime Date { get; }
        private string _timePeriod = "";
        public string TimePeriod
        {
            get
            {
                // Get the current time in 24-hour format (HH:mm)
                string time = DateTime.Now.ToString("HH:mm");
                return time;
            }
            set
            {
                _timePeriod = value;
            }
        }
        public TimeBlock(int timeBlockId, int userID, string name, string description, DateTime date, string timeP)
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
