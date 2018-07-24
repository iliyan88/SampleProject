using SimpleEchoBot.ApplicationServices;
using SimpleEchoBot.Entities;
using SimpleEchoBot.RequestAndResponse;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SimpleEchoBot.Controllers
{
    [RoutePrefix("api/[controller]")]
    public class UserController : ApiController
    {
        private  UserService userService = new UserService();

        [HttpGet()]
        public async Task<IReadOnlyList<UserToReply>> GetUsersAsync()
        {
            var result = await userService.GetAsync();
            return result;
        }

        [HttpPut()]
        [Route("{entityId}")]
        public async Task<HttpResponseMessage> UpdateSchoolPageLanguageAsync(
            int entityId,
            [FromBody]UserUpdateRequest request)
        {
            var result = await userService.UpdateAsync(entityId, request);
            return result;
        }

        [HttpDelete()]
        [Route("{entityId}")]
        public async Task<HttpResponseMessage> DeleteSchoolPageAsync(
           int entityId)
        {
            var result = await userService.DeleteAsync(entityId);
            return result;
        }
    }
}