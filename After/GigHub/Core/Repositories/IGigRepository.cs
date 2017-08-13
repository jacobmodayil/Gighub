using System.Collections.Generic;
using GigHub.Core.Models;

namespace GigHub.Core.Repositories
{
    public interface IGigRepository
    {
        IEnumerable<Gig> GetGigsUserAttending(string userId);
        Gig GetGigWithAttendees(int gigId);
        IEnumerable<Gig> GetAllFutureGigsByArtist(string userId);
        Gig GetGig(int id);
        void Add(Gig gig);
        IEnumerable<Gig> GetAllUpcomingGigs();
    }
}