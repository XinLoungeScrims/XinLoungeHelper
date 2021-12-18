using System.Collections.Generic;

namespace XinLoungeHelper.Events.ReactionRoles
{
    public readonly struct ReactionRoleMessage
    {
        // emote name, role id
        public Dictionary<string, ulong> ReactionRoles { get; }
        
        public ulong MessageId { get; }

        public ReactionRoleMessage(Dictionary<string, ulong> reactionRoles, ulong messageId)
        {
            ReactionRoles = reactionRoles;
            MessageId = messageId;
        }
    }
}