
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace GitManager.Core
{
    public class GitHubRepositoryManager
    {
        private string token;
        private const string HEADERS_ACCEPT_VALUE = "application/vnd.github+json";
        private const string HEADERS_NAME_VERSION_API_GIT_HUB = "X-GitHub-Api-Version";
        private const string HEADERS_API_GIT_HUB_VALUE = "2022-11-28";

        public GitHubRepositoryManager()
        {

        }
        public async Task<RepositoryInfo[]> GetAllRepositorieas(Account account)
        {
            var http = new HttpClient();
            http.DefaultRequestHeaders.Add("Accept", HEADERS_ACCEPT_VALUE);
            http.DefaultRequestHeaders.Add(HEADERS_NAME_VERSION_API_GIT_HUB, HEADERS_API_GIT_HUB_VALUE);
            http.DefaultRequestHeaders.Add("Authorization", token);
            //Надо ли задавать заголовок User-Agent?
            //Проверить кол-во возвращаемых Репозииториев. Возможно вернет не более 30.
            //Тогда необходимо задать заголовок per_page значением до 100 и обрабатывать
            //link адреса из ответа для получения следующей порции информации
            var json = await http.GetStringAsync("https://api.github.com/users/" + account.Name + "/repos");
            try
            {
                var ListRoot = JsonSerializer.Deserialize<List<Root>>(json);
                var Array = new RepositoryInfo[ListRoot.Count];
                for (int i = 0; i < ListRoot.Count; i++)
                {
                    Array[i].Id = ListRoot[i].id;
                    Array[i].NoteId = ListRoot[i].node_id;
                    Array[i].Name = ListRoot[i].name;
                    Array[i].Description = ListRoot[i].description;
                    Array[i].Url = new Uri(ListRoot[i].html_url);
                    Array[i].IsPrivate = bool.Parse(ListRoot[i].visibility);
                    if (Array[i].IsPrivate) Array[i].Visibility = RepositoryVisibilityStatus.Public;
                    else Array[i].Visibility = RepositoryVisibilityStatus.Private;
                }
                return Array;
            }
            catch
            {
                //на текущем этапе - Игнорирование ошибок
                return null;
            }
        }

        public bool DeleteRepository(int id)
        {

        }

        public bool ChangeVisibility(int id, RepositoryVisibilityStatus visibility)
        {

        }
    }
}
