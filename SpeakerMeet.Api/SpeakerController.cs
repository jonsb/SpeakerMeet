using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SpeakerMeet.Services;
using SpeakerMeet.Services.Speakers;

namespace SpeakerMeet.API
{
    public class SpeakerController : Controller
    {
        private ISpeakerService _speakerService;

        public SpeakerController(ISpeakerService speakerService1)
        {
            _speakerService = speakerService1;
        }

        public IActionResult Search(string searchString)
        {
            var speakers =_speakerService.Search(searchString);

            if (speakers.Any())
            {
                return Ok(speakers);
            }

            return Ok(new List<Speaker>());
        }

        private static IEnumerable<Speaker> FilterSpeakers(string query, List<Speaker> speakers)
        {
            var filteredSpeakers = speakers.Where(s => s.Name.StartsWith(query, StringComparison.OrdinalIgnoreCase));
            return filteredSpeakers;
        }

        public void GetAll()
        {
            
        }
    }
}