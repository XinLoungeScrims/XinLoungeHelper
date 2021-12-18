using System.Collections.Generic;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace XinLoungeHelper.Events.ReactionRoles
{
    public class ReactionRoleListener
    {
        private readonly List<ReactionRoleMessage> reactionRoleMessages;
        
        public ReactionRoleListener() {
            reactionRoleMessages = new List<ReactionRoleMessage>();
        }
        
        public void Initialize()
        {
            ReactionRoleMessage infoReactionRoles = new ReactionRoleMessageBuilder()
                .SetMessageId(921774100312129576)
                .AddReactionRole("❓", 921169000178802708)
                .AddReactionRole("🤝", 916586509304463411)
                .AddReactionRole("📣", 911160200055128067)
                .AddReactionRole("🗳️", 911160329449402389)
                .Build();
            
            reactionRoleMessages.Add(infoReactionRoles);
        }

        public async Task OnReactionAdd(SocketReaction reaction)
        {
            // if in a guild, not a dm
            if (reaction.User.Value is IGuildUser user)
            {
                foreach (ReactionRoleMessage reactionRoleMessage in reactionRoleMessages)
                {
                    if (reactionRoleMessage.MessageId != reaction.MessageId) 
                        continue;
                    
                    foreach ((var emoteName, ulong roleId) in reactionRoleMessage.ReactionRoles)
                    {
                        if (reaction.Emote.Name != emoteName) 
                            continue;
                        
                        await user.AddRoleAsync(roleId);
                    }
                }
            }
        }

        public async Task OnReactionRemove(SocketReaction reaction)
        {
            // if in a guild, not a dm
            if (reaction.User.Value is IGuildUser user)
            {
                foreach (ReactionRoleMessage reactionRoleMessage in reactionRoleMessages)
                {
                    if (reactionRoleMessage.MessageId != reaction.MessageId) 
                        continue;
                    
                    foreach ((var emoteName, ulong roleId) in reactionRoleMessage.ReactionRoles)
                    {
                        if (reaction.Emote.Name != emoteName) 
                            continue;
                        
                        await user.RemoveRoleAsync(roleId);
                    }
                }
            }
        }
    }
}