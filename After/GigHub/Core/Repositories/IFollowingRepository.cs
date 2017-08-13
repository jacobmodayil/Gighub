using System.Collections.Generic;
using GigHub.Core.Models;

namespace GigHub.Core.Repositories
{
    public interface IFollowingRepository
    {
        Following GetFollowing(string followeeId, string followerId);
        List<ApplicationUser> GetFollowingArtists(string userId);
        void Add(Following following);
        void Remove(Following following);
    }
}