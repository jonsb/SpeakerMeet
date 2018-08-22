using System;
using Microsoft.AspNetCore.Mvc;
using SpeakerMeet.Services.Logon;

namespace SpeakerMeet.API.Logon
{
    public class LogonController : Controller
    {
        private readonly ILogonService _logonService;

        public LogonController(ILogonService logonService)
        {
            _logonService = logonService;
        }

        public object Post(LoginAttempt loginAttempt)
        {
            if (loginAttempt == null)
                throw new ArgumentNullException();

            if (_logonService.IsLoginSuccessful(loginAttempt))
                return Ok();
            
            return Unauthorized();
        }

    }
}