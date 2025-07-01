
namespace GitManager.Lib
{
    internal interface IRepositoryManager
    {
        public RepositoryInfo[] GetAllRepositories(Account account);
        public bool DeleteRepository(int id);
        public bool ChangeVisibility(int id, RepositoryVisibilityStatus visibility);
    }
}
