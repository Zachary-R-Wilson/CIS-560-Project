using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using UserData.Models;
using System.Data.SqlClient;



namespace UserData
{
    public class SqlTimeBlockRepository : ITimeBlockRepository
    {
        private readonly string connectionString;

        public SqlTimeBlockRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void SaveTimeBlock(int timeBlockId, int userId, string name, string description, DateTime date, DateTimeOffset timePeriod)
        {
            // Verify parameters.
            if (timeBlockId == null)
                throw new ArgumentNullException(nameof(timeBlockId));

            if (userId == null)
                throw new ArgumentNullException(nameof(userId));

            if (name == null)
                throw new ArgumentNullException(nameof(name));

            if (description == null)
                throw new ArgumentNullException(nameof(description));

            if (date == null)
                throw new ArgumentNullException(nameof(date));

            if (timePeriod == null)
                throw new ArgumentNullException(nameof(timePeriod));


            // Save address to the database.
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("User.SaveTimeBlock", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("TimeBlockId", timeBlockId);
                        command.Parameters.AddWithValue("UserId", userId);
                        command.Parameters.AddWithValue("Name", name);
                        command.Parameters.AddWithValue("Description", description);
                        command.Parameters.AddWithValue("Date", date);
                        command.Parameters.AddWithValue("Time", timePeriod);


                        connection.Open();

                        command.ExecuteNonQuery();

                        transaction.Complete();
                    }
                }
            }
        }


        public IReadOnlyList<TimeBlock> RetrieveTimeBlocks(int userId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("User.RetrieveTimeBlock", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("UserId", userId);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                        return TranslateAddresses(reader);
                }
            }
        }



        private IReadOnlyList<TimeBlock> TranslateAddresses(SqlDataReader reader)
        {
            var addresses = new List<TimeBlock>();

            var timeBlockIdIdOrdinal = reader.GetOrdinal("TimeBlockId");
            var userIdOrdinal = reader.GetOrdinal("UserId");
            var nameOrdinal = reader.GetOrdinal("name");
            var descriptionOrdinal = reader.GetOrdinal("description");
            var dateOrdinal = reader.GetOrdinal("Date");
            var timePeriodOrdinal = reader.GetOrdinal("TimePeriod");

            while (reader.Read())
            {
                addresses.Add(new TimeBlock(
                   reader.GetInt32(timeBlockIdIdOrdinal),
                   reader.GetInt32(userIdOrdinal),
                   reader.GetString(nameOrdinal),
                   reader.GetString(descriptionOrdinal),
                   reader.GetDateTime(dateOrdinal),
                   reader.GetDateTimeOffset(timePeriodOrdinal)));
            }

            return addresses;
        }

        
    }
}
