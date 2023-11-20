using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserData.Models
{
    public class Goals
    {
        public int GoalsID { get; }
        public int UserID { get; }
        public string Name { get; }
        public string Description { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public bool IsComplete = false;
        public string Progress { get; }

        public Goals(int goalsID, int userID, string name, string description, DateTime start, DateTime end, bool isComplete, string progress)
        {
            GoalsID = goalsID;
            UserID = userID;
            Name = name;
            Description = description;
            StartDate = start;
            EndDate = end;
            IsComplete = isComplete;
            Progress = progress;
        }

    }
}
