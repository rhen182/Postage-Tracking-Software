using Microsoft.VisualStudio.TestTools.UnitTesting;
using WGUCapstoneProject.Models;
using Xunit;

namespace WGUCapstone.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [Theory]
        [TestMethod]
        [InlineData("wrongUser", "wrongPass", false)]
        [InlineData("test1", "test2", true)]
        [InlineData("", "", false)]
        [InlineData("username", "password", true)]

        

        public void TestCanLoginList(string username, string password, bool expectedResult)
        {
            Employee employee = new Employee();

            bool result = employee.CanLoginList(username, password);

            Xunit.Assert.Equal(expectedResult, result);
        }
    }
}