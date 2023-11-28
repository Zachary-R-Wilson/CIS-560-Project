using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserData.Models
{
    public class Goal
    {
        public int GoalId { get; }
        public int UserId { get; }
        public string Name { get; }
        public string Description { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public int IsComplete { get; }
        public string Progress { get; }

        public Goal(int goalsID, int userID, string name, string description, DateTime start, DateTime end, int isComplete, string progress)
        {
            GoalId = goalsID;
            UserId = userID;
            Name = name;
            Description = description;
            StartDate = start;
            EndDate = end;
            IsComplete = isComplete;
            Progress = progress;
        }

    }
}
