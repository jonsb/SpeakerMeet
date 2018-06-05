using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SpeakerMeet.API;
using Xunit;

namespace SpeakerMeet.Tests
{
    public class Tests
    {
        private readonly SpeakerController _controller;

        public Tests()
        {
            _controller = new SpeakerController();        
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
        public void GivenExactMatchThenOneSpeakerInCollection()
        {
            // Arrange
            // Act
            var result = _controller.Search("Joshua") as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            var speakers = ((IEnumerable<Speaker>) result.Value).ToList();
            Assert.Single(speakers);
            Assert.Equal("Joshua", speakers[0].Name);
        }

        [Theory]
        [InlineData("Joshua")]
        [InlineData("joshua")]
        [InlineData("JoShUa")]
        public void GivenCaseInsensitiveMatchThenSpeakerInCollection(string searchString)
        {
            // Arrange
            // Act
            var result = _controller.Search(searchString) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            var speakers = ((IEnumerable<Speaker>) result.Value).ToList();
            Assert.Equal("Joshua", speakers[0].Name);
        }

        [Fact]
        public void GivenNoMatchThenEmptyCollection()
        {
            // Arrange
            // Act
            var result = _controller.Search("ZZX") as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            var speakers = ((IEnumerable<Speaker>) result.Value).ToList();
            Assert.Empty(speakers);
        }

        [Fact]
        public void Given3MatchThenCollectionWith3Speakers()
        {
            // Arrange
            // Act
            var result = _controller.Search("jos") as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            var speakers = ((IEnumerable<Speaker>) result.Value).ToList();
            Assert.Equal(3, speakers.Count);
            Assert.Contains(speakers, s => s.Name == "Josh");
            Assert.Contains(speakers, s=> s.Name == "Joshua");
            Assert.Contains(speakers, s => s.Name == "Joseph");
        }
    }
}