using Microsoft.AspNetCore.Identity;

namespace TriantaWeb.API.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWToken(IdentityUser user, List<string> roles);
    }
}
