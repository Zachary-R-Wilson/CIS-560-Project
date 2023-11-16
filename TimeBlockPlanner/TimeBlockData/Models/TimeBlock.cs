using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeBlockData.Models
{
    public class TimeBlock
    {
        public int GoalsID { get; }
        public int UserID { get; }
        public string Name { get; }
        public string Description { get; }
        public DateTime Date { get; }
        
    }
}
