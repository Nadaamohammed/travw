using DomainLayer.Models.Hotels___Accommodation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.RepositoryInterface.Hotel___Accommodation
{
    public interface IAmenityRepository
    {
        Task<IEnumerable<Amenity>> GetAllAsync();
        Task<Amenity> GetByIdAsync(int id);
        Task AddAsync(Amenity amenity);
        void UpdateAsync(Amenity amenity);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> SaveAsync();



    }
}
