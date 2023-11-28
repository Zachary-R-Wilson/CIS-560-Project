using System.Collections.Generic;
using System.Net;
using UserData.Models;

namespace UserData
{
    public interface IGoalRepository
    {
        IReadOnlyList<Goal> RetrieveGoals(int userId);

        void SaveGoal(int goalId, int userId, string name, string description, DateTime startDate, DateTime endDate, int IsComplete, string progress);
    }
}

