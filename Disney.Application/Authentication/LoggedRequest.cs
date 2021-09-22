namespace Disney.Application.Authentication
{
    public class LoggedRequest
    {
        private string userId;

        public string GetUser()
            => userId;
        public void SetUser(string userId)
            => this.userId = userId;
    }
}
