using DomainLayer.Models.Hotels___Accommodation;
using Microsoft.EntityFrameworkCore;
using DomainLayer.RepositoryInterface.Hotel___Accommodation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.RepositoryImplementation.Hotel___Accommodation
{
    public class AmenityRepository : IAmenityRepository
    {
        private readonly ApplicationDbContext _context;
        public AmenityRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Amenity amenity)
        {
            await _context.Amenities.AddAsync(amenity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var amenity = await GetByIdAsync(id);
            if (amenity != null)
            {
                _context.Amenities.Remove(amenity);
                await _context.SaveChangesAsync();
            }
        }

        public Task<bool> ExistsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Amenity>> GetAllAsync()
        {
            return await _context.Amenities
            .Include(a => a.HotelAmenities)
            .ToListAsync();
        }

        public async Task<Amenity> GetByIdAsync(int Id)
        {
            return await _context.Amenities
                        .Include(a => a.HotelAmenities)
                        .FirstOrDefaultAsync(a => a.Id == Id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateAsync(Amenity amenity)
        {
            _context.Amenities.Update(amenity);
        }
        public async Task<bool> SaveAsyc()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public Task<bool> SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}

