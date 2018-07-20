using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Dialogs;
using SendGrid;
using System.Diagnostics;
using System.Threading;
using SendGrid.Helpers.Mail;

namespace SimpleEchoBot.ApplicationServices
{
    public class MessageService
    {
        //private readonly IUnitOfWork unitOfWork;
        //private readonly IMemoryCache memoryCache;
        //private readonly IWordCache wordCache;
        private readonly ISendGridClient sendGridClient;
        //BotCredentials botCredentials;
        //private readonly IConfiguration configurationRoot;

        //public MessageService(
        //    IUnitOfWork unitOfWork
        //    //IMemoryCache memoryCache,
        //    //IOptions<BotCredentials> botCredentials,
        //    //IWordCache wordCache,
        //    //IConfiguration configurationRoot)
        //    )
        //{
        //    //this.unitOfWork = unitOfWork;
        //    //this.memoryCache = memoryCache;
        //    //this.wordCache = wordCache;
        //    //this.configurationRoot = configurationRoot;
        //    //this.botCredentials = botCredentials.Value;
        //    this.sendGridClient = new SendGridClient(Environment.GetEnvironmentVariable("BOBTHEBOT_SENDGRID_EMAIL_APIKEY"));
        //}




        public async void CheckSentences(Activity activity)
        {

            //var appCredentials = new MicrosoftAppCredentials(configurationRoot);
            //var connector = new ConnectorClient(new Uri(activity.ServiceUrl), appCredentials);
            var connector = new ConnectorClient(new Uri(activity.ServiceUrl));

            string messages = activity.Text?.ToString().ToLower();


            //Email variables
            var senderEmail = Environment.GetEnvironmentVariable("BOBTHEBOT_SENDER_EMAIL");
            var senderName = Environment.GetEnvironmentVariable("BOBTHEBOT_SENDER_NAME");

            #region Is Typing Activity

            // var activity = context.Activity as Activity;
            Trace.TraceInformation($"Type={activity.Type} Text={activity.Text}");
            if (activity.Type == ActivityTypes.Message)
            {
                //var connector = new ConnectorClient(new System.Uri(activity.ServiceUrl));
                var isTyping = activity.CreateReply("Nerdibot is thinking...");
                isTyping.Type = ActivityTypes.Typing;
                await connector.Conversations.ReplyToActivityAsync(isTyping);

                // DEMO: I've added this for demonstration purposes, so we have time to see the "Is Typing" integration in the UI. Else the bot is too quick for us :)
                Thread.Sleep(2500);
            }

            #endregion

            await connector.Conversations.SendToConversationAsync(activity.Conversation.Id, activity: activity.CreateReply("Hello"));
            //await connector.Conversations.ReplyToActivityAsync(activity: activity.CreateReply("Hello Reply"));


            //if (activity.Conversation.IsGroup != null)
            //{
                //Words to search for in conversation
                var wordsEntity = new List<string>();//await wordCache.GetAsync();
                wordsEntity.Add("rosen");
                wordsEntity.Add("marinchev");
                //var words = wordsEntity.Select(x => x.Word);


                // Get the conversation id so the bot answers.
                var conversationId = activity.From.Id.ToString();

                // Get a valid token 
                //string token = await this.GetBotApiToken();

                // send the message back
                using (var client = new System.Net.Http.HttpClient())
                {
                    string from = activity.From.Name.ToString();
                    string conv = activity.Conversation.Id;
                    //var group = conv.Split("|").Last().Split("\"").First();


                    // Set the toekn in the authorization header.
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    if (wordsEntity.Any(c => messages.Contains(c.ToLower())))
                    {
                    // var userToResponse = await unitOfWork.UserToReplyRepository.GetActiveUsers();

                    //foreach (var user in userToResponse)
                    //{
                    //send private message to user 


                    await connector.Conversations.SendToConversationAsync(activity.Conversation.Id, activity: activity.CreateReply("Hello from other side :D"));
                    //await connector.Conversations.SendToConversationAsync(
                    //    user.ConversationId,
                    //    activity: activity.CreateReply("Group: " + activity.ChannelId + "\n" + "User: " + from + "\n" + "Message: " + "\"" + activity.Text.ToString() + "\""));


                    //send email to user
                    //if (user.SendEmail)
                    //{

                    //    var msg = MailHelper.CreateSingleEmail(
                    //    new EmailAddress(senderEmail, senderName),
                    //        new EmailAddress(user.Email, user.SkypeUserName),
                    //        "Subject",
                    //        "",
                    //        "Group: " + activity.ChannelId + "\n" + "User: " + from + "\n" + "Message: " + "\"" + activity.Text.ToString() + "\"");

                    //    var response2 = await sendGridClient.SendEmailAsync(msg);
                    //}
                    //}
                }
                }
            //}
            //else
            //{
            //    if (messages.Contains("spamm me bob"))
            //    {

            //        var user = await unitOfWork.UserToReplyRepository.GetUserByIdAndName(activity.From.Id, activity.From.Name);
            //        if (user == null)
            //        {
            //            var newUser = new UserToReply(activity.Conversation.Id, activity.From.Id, activity.From.Name);
            //            await unitOfWork.UserToReplyRepository.InsertAsync(newUser);
            //            await unitOfWork.SaveChangesAsync();
            //            await connector.Conversations.SendToConversationAsync(activity.Conversation.Id, activity: activity.CreateReply("User are now added as recipient"));
            //        }
            //        else
            //        {
            //            await connector.Conversations.SendToConversationAsync(activity.Conversation.Id, activity: activity.CreateReply("User already is added as recipient"));
            //        }
            //    }
            //}
            //return null;
        }
    }
}