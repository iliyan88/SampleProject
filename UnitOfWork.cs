using SimpleEchoBot.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SimpleEchoBot
{
    public class UnitOfWork : IDisposable // : IUnitOfWork
    {

        private readonly AppDbContext dbContext = new AppDbContext();
        private SearchKeyRepository searchKeyRepository;
        private UserToReplyRepository userToReplyRepository;

        public SearchKeyRepository SearchKeyRepository
        {
            get
            {

                if (this.searchKeyRepository == null)
                {
                    this.searchKeyRepository = new SearchKeyRepository(dbContext);
                }
                return searchKeyRepository;
            }
        }

        public UserToReplyRepository UserToReplyRepository
        {
            get
            {

                if (this.userToReplyRepository == null)
                {
                    this.userToReplyRepository = new UserToReplyRepository(dbContext);
                }
                return userToReplyRepository;
            }
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public void SaveChange()
        {
            dbContext.SaveChanges();
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