using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TimeBlockData.Models;

namespace UserData.SQL
{
    public class ITimeBlockRepository
    {
        IReadOnlyList<TimeBlock> RetrieveTimeBlock(int userId);

        void SaveTimeBlock(int timeBlockId, int userId, string name, string description, DateTime date, DateTime timePeriod);


    }
}
