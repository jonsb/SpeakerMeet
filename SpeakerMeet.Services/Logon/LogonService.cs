namespace SpeakerMeet.Services.Logon
{
    public class LogonService : ILogonService
    {
        private IRepository<UserLogonDto> _repository;

        public LogonService(IRepository<UserLogonDto> repository)
        {
            _repository = repository;
        }

        public bool IsLoginSuccessful(LoginAttempt loginAttempt)
        {
            if (loginAttempt?.Username == "validuser@email.com" && loginAttempt.Password == "ValidPassword")
                return true;

            return false;
        }
    }
}