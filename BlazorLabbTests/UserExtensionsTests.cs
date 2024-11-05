using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlazorLabb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorLabb.Tests
{
    [TestClass()]
    public class UserExtensionsTests
    {
        [TestMethod()]
        public void GetSomeUsersTest()
        {
            //Arrange
            var data = new RandomlyGeneratedUserDataAccess();
            var users = data.Users;

            //Act
            var actualUsers = users.GetSomeUsers(0, 5);

            //Assert
            var expectedUsersTotal = 5;
            Assert.AreEqual(expectedUsersTotal, actualUsers.Count());
        }
    }
}

namespace BlazorLabbTests
{
    class UserExtensionsTests
    {
    }
}
