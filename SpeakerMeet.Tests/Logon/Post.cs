using System;
using Microsoft.AspNetCore.Mvc;
using SpeakerMeet.API.Logon;
using SpeakerMeet.Services.Logon;
using SpeakerMeet.TestUtils;
using Xunit;

namespace SpeakerMeet.API.Tests.Logon
{
    public class Post
    {
        [Theory]
        [InlineData("invaliduser1@email.com")]
        [InlineData("invaliduser2@email.com")]
        [InlineData("invaliduser3@email.com")]
        [InlineData("invaliduser4@email.com")]
        [InlineData("invaliduser5@email.com")]
        public void ItReturnsUnauthorizedForInvalidUser(string username)
        {
            // Arrange
            var controller = GetController();
            var attempt = new LoginAttempt
            {
                Username = username,
                Password = "AnyPassword"
            };

            // Act, Assert
            var response = (UnauthorizedResult) controller.Post(attempt);
        }

        [Theory]
        [InlineData("validuser@email.com", "ValidPassword")]
        public void ItReturnsOkForValidUser(string username, string password)
        {
            // Arrange
            var controller = GetController();
            var loginAttempt = new LoginAttempt
            {
                Username = username,
                Password = password
            };

            // Act, Assert
            var response = (OkResult) controller.Post(loginAttempt);
        }

        [Theory]
        [InlineData("badpassword1")]
        [InlineData("badpassword2")]
        [InlineData("badpassword3")]
        [InlineData("badpassword4")]
        [InlineData("badpassword5")]
        public void ItReturnsUnauthorizedForInvalidPassword(string password)
        {
            // Arrange
            var controller = GetController();
            var loginAttempt = new LoginAttempt
            {
                Username = "validuser1@email.com",
                Password = password
            };

            // Act, Assert
            var response = (UnauthorizedResult) controller.Post(loginAttempt);
        }

        [Fact]
        public void ItReturnsArgumentNullExceptionForNullLoginAttempt()
        {
            // Arrange
            var controller = GetController();

            // Act
            var exception = Record.Exception(() => controller.Post(null));

            // Assert
            Assert.IsType<ArgumentNullException>(exception);
        }

        private static LogonController GetController()
        {
            var controller = new LogonController(new LogonService(new FakeRepository<UserLogonDto>()));
            return controller;
        }
    }
}