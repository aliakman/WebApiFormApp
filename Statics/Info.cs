using System.IdentityModel.Tokens.Jwt;

namespace WebApiFormApp.Statics
{
    public class Info
    {
        //SESSION
        public string? AccessToken { get; private set; }
        public string? RefreshToken { get; private set; }

        public void SetAccessToken(string token)
        {
            AccessToken = token;

            //// Token'ı çözüp ID'yi çekelim
            //var handler = new JwtSecurityTokenHandler();
            //var jwtToken = handler.ReadJwtToken(token);

            //// JWT içinde ID genellikle "nameid" veya "sub" olarak saklanır
            //var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "nameid")
            //               ?? jwtToken.Claims.FirstOrDefault(c => c.Type == "sub");

            //if (userIdClaim != null)
            //{
            //    SetUserId(Guid.Parse(userIdClaim.Value));
            //}
        }
        public void SetRefreshToken(string refreshToken) { RefreshToken = refreshToken; }

        //USER
        public Guid? UserId { get; private set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public void SetUserId(Guid id) { UserId = id; }
        public void SetEmail(string email) { Email = email; }
        public void SetPassword(string password) { Password = password; }
    }
}
