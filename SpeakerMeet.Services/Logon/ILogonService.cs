namespace SpeakerMeet.Services.Logon
{
    public interface ILogonService
    {
        bool IsLoginSuccessful(LoginAttempt loginAttempt);
    }
}