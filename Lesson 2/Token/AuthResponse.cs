namespace Lesson_2.Token
{
    internal sealed class AuthResponse
    {
        public string Password { get; set; }
        public RefreshToken LatestRefreshToken { get; set; }
    }
}
