using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UserData.Models;

namespace UserData
{
    public interface ITimeBlockRepository
    {
        IReadOnlyList<TimeBlock> RetrieveTimeBlocks(int userId);

        void SaveTimeBlock(int timeBlockId, int userId, string name, string description, DateTime date, DateTimeOffset timePeriod);

    }
}
