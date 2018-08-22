using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SpeakerMeet.API;
using SpeakerMeet.Services;
using SpeakerMeet.Services.Speakers;
using Xunit;

namespace SpeakerMeet.Tests
{
    public class SearchForSpeakersTests
    {
        private static Mock<ISpeakerService> _speakerServiceMock;
        private readonly List<Speaker> _speakers;

        private readonly SpeakerController _controller;

        public SearchForSpeakersTests()
        {
            _speakers = new List<Speaker> { new Speaker("test")};

            _speakerServiceMock = new Mock<ISpeakerService>();
            _speakerServiceMock.Setup(x => x.Search(It.IsAny<string>())).Returns(_speakers);

            _controller = new SpeakerController(_speakerServiceMock.Object);
        }

        [Fact]
        public void ItReturnsCollectionOfSpeakers()
        {
            // Arrange
            // Act
            var result = _controller.Search("Jobs") as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.IsType<List<Speaker>>(result.Value);
        }

        [Fact]
        public void ItAcceptsInterface()
        {
            // Arrange
            ISpeakerService testSpeakerService = new TestSpeakerService();

            // Act
            var controller = new SpeakerController(testSpeakerService);

            // Assert
            Assert.NotNull(controller);
        }

        [Fact]
        public void ItCallsSearchServiceOnce()
        {
            // Arrange
            // Act
            _controller.Search("jobs");

            // Assert
            _speakerServiceMock.Verify(mock => mock.Search(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public void ItCallsSearchServiceWithSearchString()
        {
            // Arrange
            string searchString = "jos";

            // Act
            _controller.Search(searchString);

            // Assert
            _speakerServiceMock.Verify(mock => mock.Search(searchString), Times.Once());
        }

        [Fact]
        public void GivenSpeakerServiceThenResultsReturned()
        {
            // Arrange
            var searchString = "jobs";

            // Act
            var result = _controller.Search(searchString) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            var speakers = ((IEnumerable<Speaker>) result.Value).ToList();
            Assert.Equal(_speakers, speakers);
        }
    }
}