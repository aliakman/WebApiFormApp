namespace WebApiFormApp.Statics
{
    public class Info
    {
        public Guid? ID { get; private set; }

        public string? AccessToken { get; private set; }
        public string? RefreshToken { get; private set; }

        public void SetID(Guid id)
        {
            ID = id;
        }

        public void SetAccessToken(string accessToken)
        {
            AccessToken = accessToken;
        }

        public void SetRefreshToken(string refreshToken)
        {
            RefreshToken = refreshToken;
        }

    }
}
