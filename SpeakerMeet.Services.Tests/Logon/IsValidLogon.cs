using SpeakerMeet.Services.Logon;
using SpeakerMeet.TestUtils;
using Xunit;

namespace SpeakerMeet.Services.Tests.Logon
{
    public class IsValidLogon
    {
        private readonly LogonService _logonService;

        public IsValidLogon()
        {
                
        }

        [Fact]
        public void ItAcceptsRepository()
        {
            var repository = new FakeRepository<UserLogonDto>();
            var service = new LogonService(repository);
            var attempt = new LoginAttempt();

            service.IsLoginSuccessful(attempt);
        }
    }
}