using System.Transactions;
using System;
using UserData;
using UserData.Models;
using DataAccess;


namespace UserDataTests
{
    [TestClass]
    public class UserRepositoryTests
    {
        const string connectionString = @"Server=(localdb)\reaganlocal;Database=rphazell;Integrated Security=SSPI;";

        private static string GetTestString() => Guid.NewGuid().ToString("N");

        private IUserRepository repo;
        private TransactionScope transaction;

        [TestInitialize]
        public void InitializeTest()
        {
            repo = new SqlUserRepository(connectionString);

            transaction = new TransactionScope();
        }

        [TestCleanup]
        public void CleanupTest()
        {
            transaction.Dispose();
        }

        [TestMethod]
        public void CreatePersonShouldWork()
        {
            var username = GetTestString();
            var firstName = GetTestString();
            var lastName = GetTestString();
            var email = $"{GetTestString()}@test.com";
            var passwordHash = GetTestString();
            var isDeleted = 0;

            var actual = repo.CreateUser(firstName, lastName, email, username, passwordHash, isDeleted);

            Assert.IsNotNull(actual);
            Assert.AreEqual(firstName, actual.FirstName);
            Assert.AreEqual(lastName, actual.LastName);
            Assert.AreEqual(email, actual.Email);
        }

        [TestMethod]
        [ExpectedException(typeof(RecordNotFoundException))]
        public void GetUserByIdWithNonExistingIdShouldThrowRecordNotFoundException()
        {
            repo.GetUserById(0);
        }

        [TestMethod]
        public void GetUserByIdShouldWork()
        {
            var expected = CreateTestUser();
            var actual = repo.GetUserById(expected.UserID);

            AssertUsersAreEqual(expected, actual);
        }

        [TestMethod]
        public void GetUserByEmailShouldWork()
        {
            var expected = CreateTestUser();    // canged this from CreatTestPerson(), not sure where that has been declared but need to see, this is now saying itdoesnt recognize the function after I changed it 
            var actual = repo.GetUserByEmail(expected.Email);

            AssertUsersAreEqual(expected, actual);
        }

        [TestMethod]
        public void RetrievePersonsShouldWork()
        {
            var p1 = CreateTestUser();
            var p2 = CreateTestUser();
            var p3 = CreateTestUser();

            var expected = new Dictionary<int, User>
         {
            { p1.UserID, p1 },
            { p2.UserID, p2 },
            { p3.UserID, p3 }
         };

            var actual = repo.RetrieveUsers();

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Count >= 3, "At least three are expected.");

            var matchCount = 0;

            foreach (var a in actual)
            {
                if (!expected.ContainsKey(a.UserID))
                    continue;

                AssertUsersAreEqual(expected[a.UserID], a);

                matchCount += 1;
            }

            Assert.AreEqual(expected.Count, matchCount, "Not all expected persons were returned.");
        }

        private static void AssertUsersAreEqual(User expected, User actual)
        {
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.LastName, actual.LastName);
            Assert.AreEqual(expected.Email, actual.Email);
            Assert.AreEqual(expected.Username, actual.Username);
            Assert.AreEqual(expected.PasswordHash, actual.PasswordHash);
            Assert.AreEqual(expected.IsDeleted, actual.IsDeleted);
        }

        private User CreateTestUser()
        {
            return repo.CreateUser(GetTestString(), GetTestString(), $"{GetTestString()}@test.com", GetTestString(), GetTestString(), 0);
        }
    }
}

