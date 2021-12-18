using System.Collections.Generic;

namespace XinLoungeHelper.Events.ReactionRoles
{
    public class ReactionRoleMessageBuilder
    {
        private readonly Dictionary<string, ulong> reactionRoles;
        private ulong messageId;

        public ReactionRoleMessageBuilder()
        {
            reactionRoles = new Dictionary<string, ulong>();
        }
        
        public ReactionRoleMessageBuilder AddReactionRole(string emoteId, ulong roleId)
        {
            reactionRoles.Add(emoteId, roleId);
            return this;
        }
        
        public ReactionRoleMessageBuilder SetMessageId(ulong id)
        {
            messageId = id;
            return this;
        }

        public ReactionRoleMessage Build()
        {
            return new ReactionRoleMessage(reactionRoles, messageId);
        }
    }
}