using SimpleEchoBot.Entities;
using SimpleEchoBot.Repositories;
using SimpleEchoBot.RequestAndResponse;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimpleEchoBot.ApplicationServices
{
    public class SearchKeyService
    {
        private UnitOfWork unitOfWork = new UnitOfWork();



        public async Task<HttpResponseMessage> Add(WordsRequest request)
        {
            var existingWordsEntity = await unitOfWork.SearchKeyRepository.GetAllWords();
            var existingWords = existingWordsEntity.Select(x => x.Word);

            foreach (var item in request.Words)
            {
                if (!existingWords.Contains(item))
                {
                    var word = new SearchKey(item);
                    unitOfWork.SearchKeyRepository.Insert(word);
                }
            }
            await unitOfWork.SaveChangesAsync();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public async Task<IEnumerable<WordsResponse>> GetAsync()
        {
            var existingWords = await unitOfWork.SearchKeyRepository.GetAllWords();
            return existingWords.Select(x => WordsResponse.Create(x));
        }

        public async Task<HttpResponseMessage> DeleteAsync(int wordId)
        {
            var word = await unitOfWork.SearchKeyRepository.GetWordById(wordId);
            if (word == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            unitOfWork.SearchKeyRepository.Delete(word);
            await unitOfWork.SaveChangesAsync();
            return new HttpResponseMessage(HttpStatusCode.OK);

        }
    }
}