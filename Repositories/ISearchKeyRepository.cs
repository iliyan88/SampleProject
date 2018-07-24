using SimpleEchoBot.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SimpleEchoBot.Repositories
{
    public interface ISearchKeyRepository : IDisposable
    {
        void Insert(SearchKey user);
        void Update(SearchKey user);
        void Delete(SearchKey user);
        Task<IReadOnlyList<SearchKey>> GetAllWords();
        Task<SearchKey> GetWordById(int id);
    }
}