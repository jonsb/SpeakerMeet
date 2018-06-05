using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace SpeakerMeet.API
{
    public class SpeakerController : Controller
    {
        public IActionResult Search(string searchString)
        {
            var speakers = GetSpeakers();

            var filteredSpeakers = FilterSpeakers(searchString, speakers);

            if (filteredSpeakers.Any())
            {
                return Ok(filteredSpeakers);
            }

            return Ok(new List<Speaker>());
        }

        private static IEnumerable<Speaker> FilterSpeakers(string query, List<Speaker> speakers)
        {
            var filteredSpeakers = speakers.Where(s => s.Name.StartsWith(query, StringComparison.OrdinalIgnoreCase));
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

    public class Speaker
    {
        public Speaker(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}