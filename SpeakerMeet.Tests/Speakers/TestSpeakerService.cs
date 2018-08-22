using System.Collections.Generic;
using SpeakerMeet.Services;
using SpeakerMeet.Services.Speakers;

namespace SpeakerMeet.Tests
{
    public class TestSpeakerService : ISpeakerService
    {
        public IEnumerable<Speaker> Search(string searchString)
        {
            return null;
        }
    }
}