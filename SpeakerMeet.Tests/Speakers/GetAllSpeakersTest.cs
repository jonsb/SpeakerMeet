using Moq;
using SpeakerMeet.API;
using SpeakerMeet.Services;
using SpeakerMeet.Services.Speakers;
using Xunit;

namespace SpeakerMeet.Tests
{
    public class GetAllSpeakersTest
    {
        [Fact]
        public void ItExists()
        {
            // Arrange
            var speakerServiceMock = new Mock<ISpeakerService>();
            var controller = new SpeakerController(speakerServiceMock.Object);

            // Act
            controller.GetAll();
        }
    }
}