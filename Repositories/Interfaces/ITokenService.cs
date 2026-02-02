using WebApiCoreWithAllFeatures.Models;
namespace WebApiCoreWithAllFeatures.Repositories.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
