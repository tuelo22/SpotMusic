using SpotMusic.STS.Model;

namespace SpotMusic.STS.Data
{
    public interface IIdentityRepository
    {
        Task<Usuario> FindByEmailAndPasswordAsync(string email, string password);
        Task<Usuario> FindByIdAsync(Guid id);
    }
}
