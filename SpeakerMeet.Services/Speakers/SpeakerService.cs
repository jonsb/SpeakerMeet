using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeakerMeet.Services.Speakers
{
    public class SpeakerService : ISpeakerService
    {
        public IEnumerable<Speaker> Search(string searchString)
        {
            var speakers = GetSpeakers();
            var filteredSpeakers = speakers.Where(s => s.Name.StartsWith(searchString, StringComparison.OrdinalIgnoreCase));
            return filteredSpeakers;
        }

        private static List<Speaker> GetSpeakers()
        {
            var speakers = new List<Speaker>()
            {
                new Speaker("Joshua"),
                new Speaker("Josh"),
                new Speaker("Joseph")
            };
            return speakers;
        }
    }
}
