using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GigHub.Core.Models;
using GigHub.Core.Repositories;

namespace GigHub.Persistence.Repositories
{
    public class GigRepository : IGigRepository
    {
        private readonly ApplicationDbContext _context;

        public GigRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Gig> GetGigsUserAttending(string userId)
        {
            return _context.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Gig)
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .ToList();
        }

        public Gig GetGigWithAttendees(int gigId)
        {
            return _context.Gigs
                    .Include(g => g.Attendances
                    .Select(h => h.Attendee))
                    .SingleOrDefault(g => g.Id == gigId);
        }

        public IEnumerable<Gig> GetAllFutureGigsByArtist(string userId)
        {
            return _context.Gigs
                        .Where(g => g.ArtistId == userId &&
                                g.DateTime > DateTime.Now &&
                                g.IsCanceled == false)
                        .Include(g => g.Genre)
                        .ToList();
        }


        public Gig GetGig(int id)
        {
           return _context.Gigs
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .SingleOrDefault(g => g.Id == id);
        }

        public void Add(Gig gig)
        {
            _context.Gigs.Add(gig);
        }

        public IEnumerable<Gig> GetAllUpcomingGigs()
        {
            return _context.Gigs
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .Where(g => g.DateTime > DateTime.Now &&
                            g.IsCanceled == false).ToList();
        }
    }
}