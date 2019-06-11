using Boards.API.Domain.Security.Tokens;

namespace Boards.API.Domain.Services.Communication
{
    public class TokenResponse : BaseResponse
    {
        public AccessToken Token { get; set; } 
        public TokenResponse(bool success, string message, AccessToken token) : base(success, message)
        {
            Token = token;
        }

        public TokenResponse(AccessToken token) : this(true, string.Empty, token) { }
        public TokenResponse(string message) : this(false, message, null) { }
    }
}