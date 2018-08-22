using System.Linq;
using SpeakerMeet.Services.Speakers;
using Xunit;

namespace SpeakerMeet.Services.Tests.Speakers
{
    public class Search
    {
        private readonly ISpeakerService _speakerService;

        public Search()
        {
            _speakerService = new SpeakerService();
        }

        [Theory]
        [InlineData("Joshua")]
        public void GivenExactMatchThenOneSpeakerInCollection(string searchString)
        {
            // Arrange
            // Act
            var result = _speakerService.Search(searchString);

            // Assert
            Assert.NotNull(result);
            var speakers = result.ToList();
            Assert.Single(speakers);
            Assert.Equal(searchString, speakers[0].Name);
        }

        [Theory]
        [InlineData("Joshua")]
        [InlineData("joshua")]
        [InlineData("JoShUa")]
        public void GivenCaseInsensitiveMatchThenSpeakerInCollection(string searchString)
        {
            // Arrange
            // Act
            var result = _speakerService.Search(searchString);

            // Assert
            Assert.NotNull(result);
            var speakers = result.ToList();
            Assert.Equal("Joshua", speakers[0].Name);
        }

        [Fact]
        public void GivenNoMatchThenEmptyCollection()
        {
            // Arrange
            // Act
            var result = _speakerService.Search("ZZX");

            // Assert
            Assert.NotNull(result);
            var speakers = result.ToList();
            Assert.Empty(speakers);
        }


        [Fact]
        public void Given3MatchThenCollectionWith3Speakers()
        {
            // Arrange
            // Act
            var result = _speakerService.Search("jos");

            // Assert
            Assert.NotNull(result);
            var speakers = result.ToList();
            Assert.Equal(3, speakers.Count);
            Assert.Contains(speakers, s => s.Name == "Josh");
            Assert.Contains(speakers, s => s.Name == "Joshua");
            Assert.Contains(speakers, s => s.Name == "Joseph");
        }
    }
}