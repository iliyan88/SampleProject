using SimpleEchoBot.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SimpleEchoBot.Repositories
{
    public class SearchKeyRepository : ISearchKeyRepository
    {
        private readonly AppDbContext dbContext;

        public SearchKeyRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Insert(SearchKey searchKey)
        {
            dbContext.SearchKeys.Add(searchKey);
        }

        public void Update(SearchKey searchKey)
        {
            dbContext.SearchKeys.Attach(searchKey);
        }

        public void Delete(SearchKey searchKey)
        {
            dbContext.SearchKeys.Remove(searchKey);
        }

        public async Task<IReadOnlyList<SearchKey>> GetAllWords()
        {
            return await dbContext.SearchKeys.ToListAsync();
        }
        public async Task<SearchKey> GetWordById(int id)
        {
            return await dbContext.SearchKeys.FirstOrDefaultAsync(x => x.Id == id);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}