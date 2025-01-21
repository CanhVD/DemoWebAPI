using DemoWebAPI.Dtos;
using DemoWebAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Newtonsoft.Json;

namespace DemoWebAPI.Utilities
{
    public class JwtBearerEventsHandler : JwtBearerEvents
    {
        private SessionService _sessionService;

        public JwtBearerEventsHandler(SessionService sessionService)
        {
            _sessionService = sessionService;
        }

        public override async Task TokenValidated(TokenValidatedContext context)
        {
            var username = context.Principal?.Identity?.Name;
            if (string.IsNullOrWhiteSpace(username))
            {
                context.Fail("Unauthorized");
            }
            else
            {
                var userSession = context.Principal?.Claims?.Where(i => i.Type == "UserSession")?.FirstOrDefault()?.Value;
                if (userSession is not null)
                {
                    _sessionService.SetInfo(JsonConvert.DeserializeObject<UserInfoDTO>(userSession));
                }

                context.HttpContext.Request.Headers.Add("UserSession", JsonConvert.SerializeObject(username));
            }

            await Task.CompletedTask;
        }
    }
}
