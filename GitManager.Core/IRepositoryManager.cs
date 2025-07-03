using System.Threading.Tasks;

namespace GitManager.Core;

public interface IRepositoryManager
{
    public Task<RepositoryInfo[]> GetAllRepositories(Account account);
    public bool DeleteRepository(int id);
    public bool ChangeVisibility(int id, RepositoryVisibilityStatus visibility);
}
