using System.Diagnostics;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Tomat.Framework.Core.Bot;
using XinLoungeHelper.Events.ReactionRoles;

namespace XinLoungeHelper
{
    public class XinLoungeHelperBot : DiscordBot
    {
        private ReactionRoleListener ReactionRoles { get; }

        public XinLoungeHelperBot(string token) : base(token)
        {
            ReactionRoles = new ReactionRoleListener();
        }

        public override async Task OnStartAsync()
        {
            ReactionRoles.Initialize();
            
            DiscordClient.ReactionAdded += async (_, _, reaction) =>
            {
                await ReactionRoles.OnReactionAdd(reaction);
            };
            
            DiscordClient.ReactionRemoved += async (_, _, reaction) =>
            {
                await ReactionRoles.OnReactionRemove(reaction);
            };
            
            await DiscordClient.SetStatusAsync(UserStatus.Online);
        }
        
        public override string GetPrefix(ISocketMessageChannel channel)
        {
            return Debugger.IsAttached ? ":" : ";";
        }
    }
}