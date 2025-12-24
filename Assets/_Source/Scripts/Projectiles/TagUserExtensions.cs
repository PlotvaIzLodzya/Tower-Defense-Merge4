using System.Collections.Generic;

namespace _Source.Scripts.Projectiles
{
    public static class TagUserExtensions
    {
        public static Tags GetTags(this IEnumerable<ITagUser> tagUsers)
        {
            var tags = new Tags();

            foreach (var tagUser in tagUsers)
            {
                tags |= tagUser.Tags;
            }

            return tags;
        }
    }
}