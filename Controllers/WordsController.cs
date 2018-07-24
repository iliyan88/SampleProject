using SimpleEchoBot.ApplicationServices;
using SimpleEchoBot.RequestAndResponse;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SimpleEchoBot.Controllers
{
    [RoutePrefix("api/[controller]")]
    public class WordsController : ApiController
    {

        private readonly SearchKeyService searchKeyService = new SearchKeyService();


        [HttpPost()]
        public async Task<HttpResponseMessage> InsertWordAsync([FromBody]WordsRequest request)
        {
            var result = await searchKeyService.Add(request);
            return result;
        }


        [HttpGet()]
        public async Task<IEnumerable<WordsResponse>> GetWordsAsync()
        {
            var words = await searchKeyService.GetAsync();
            return words;
        }

        [HttpDelete()]
        [Route("{entityId}")]
        public async Task<HttpResponseMessage> DeleteWordAsync(int entityId)
        {
            var result = await searchKeyService.DeleteAsync(entityId);
            return result;
        }
    }
}