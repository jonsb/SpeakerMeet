using System.Collections.Generic;

namespace SpeakerMeet.Services.Speakers
{
    public interface ISpeakerService
    {
        IEnumerable<Speaker> Search(string searchString);
    }
}