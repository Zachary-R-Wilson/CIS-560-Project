﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using UserData.Models;

namespace UserData.DataDelegates
{
    internal class RetrieveTimeBlocksForUserDataDelegate : DataReaderDelegate<IReadOnlyList<TimeBlock>>
    {
        private readonly int userId;

        public RetrieveTimeBlocksForUserDataDelegate(int userId)
           : base("User.RetrieveTimeBlocksForUser")
        {
            this.userId = userId;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            var p = command.Parameters.Add("UserId", SqlDbType.Int);
            p.Value = userId;
        }
        public override IReadOnlyList<TimeBlock> Translate(Command command, IDataRowReader reader)
        {
            var timeBlocks = new List<TimeBlock>();
            while (reader.Read())
            {
                timeBlocks.Add(new TimeBlock(
                    reader.GetInt32("TimeBlockId"),
                   reader.GetInt32("UserId"),
                   reader.GetString("Name"),
                   reader.GetString("Description"),
                   reader.GetDateTime("Date", DateTimeKind.Utc),
                   reader.GetDateTimeOffset("TimePeriod")));
            }

            return timeBlocks;
        }
    }
}