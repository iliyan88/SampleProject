using SimpleEchoBot.Entities;
using SimpleEchoBot.Repositories;
using SimpleEchoBot.RequestAndResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace SimpleEchoBot.ApplicationServices
{
    public class UserService
    {

        private UnitOfWork unitOfWork = new UnitOfWork();
        public async Task<IReadOnlyList<UserToReply>> GetAsync()
        {

            var users = await unitOfWork.UserToReplyRepository.GetAsync();
            return users;
        }

        public async Task<HttpResponseMessage> UpdateAsync(int entityId, UserUpdateRequest request)
        {
            var user = await unitOfWork.UserToReplyRepository.GetByIDAsync(entityId);
            if (user == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            user.Email = request.Email;
            user.SendEmail = request.SendEmail;
            user.IsActive = request.IsActive;

            unitOfWork.UserToReplyRepository.Update(user);
            await unitOfWork.SaveChangesAsync();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public async Task<HttpResponseMessage> DeleteAsync(int entityId)
        {
            var user = await unitOfWork.UserToReplyRepository.GetByIDAsync(entityId);
            if (user == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            unitOfWork.UserToReplyRepository.Delete(user);
            await unitOfWork.SaveChangesAsync();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}