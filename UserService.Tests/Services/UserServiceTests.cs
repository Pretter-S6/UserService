namespace UserService.Tests
{
    using Moq;
    using System;
    using NUnit.Framework;
    using TweetService.DataAccess;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    [TestFixture]
    public class UserServiceTests
    {
        private IUserService _testClass;
        private UserContext _db;
        private Mock<IUserService> serviceMock;

        [SetUp]
        public void SetUp()
        {
            serviceMock = new Mock<IUserService>();
            List<Models.Users> users = new List<Models.Users>();
            Models.Users u = new Models.Users("Rienk", "WW123", "testemail");
            users.Add(u);
            serviceMock.Setup(x => x.getAll()).Returns(users);
            _db = new UserContext(new DbContextOptions<UserContext>());
            _testClass = (IUserService)serviceMock;

        }
    }
}