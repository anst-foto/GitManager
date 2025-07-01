using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace GitManager.Lib
{
    public class RepositoryInfo
    {
        public int Id { get; set; }
        public string NoteId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Uri Url { get; set; }
        public bool IsPrivate { get; set; }
        public RepositoryVisibilityStatus Visibility { get; set; }
        public Account Account { get; set; }
    }
}
