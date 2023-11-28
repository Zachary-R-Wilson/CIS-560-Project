using System.Collections.Generic;
using DataAccess;
using UserData.Models;
using UserData.DataDelegates;
using System;

namespace UserData
{
    public class SqlGoalRepository : IGoalRepository
    {
        private readonly SqlCommandExecutor executor;

        public SqlGoalRepository(string connectionString)
        {
            executor = new SqlCommandExecutor(connectionString);
        }

        public void SaveGoal(int goalId, int userId, string name, string description, DateTime startDate, DateTime endDate, int isComplete, string progress)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            if (description == null)
                throw new ArgumentNullException(nameof(description));

            if (progress == null)
                throw new ArgumentNullException(nameof(progress));

            if (isComplete != 0 && isComplete != 1)
                throw new ArgumentNullException(nameof(isComplete));


            var d = new SaveUserGoalDataDelegate(goalId,  userId,  name,  description,  startDate,  endDate,  isComplete, progress);
            executor.ExecuteNonQuery(d);
        }

        public IReadOnlyList<Goal> RetrieveGoals(int userId)
        {
            var d = new RetrieveGoalsForUserDataDelegate(userId);
            return executor.ExecuteReader(d);
        }
    }
}

