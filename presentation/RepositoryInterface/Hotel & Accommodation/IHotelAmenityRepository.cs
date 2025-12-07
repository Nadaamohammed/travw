using DomainLayer.Models.Hotels___Accommodation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.RepositoryInterface.Hotel___Accommodation
{
    public interface IHotelAmenityRepository
    {
        Task<IEnumerable<HotelAmenity>> GetAllAsync();
        Task<HotelAmenity> GetByIdAsync(int hotelId, int amenityId);
        Task AddAsync(HotelAmenity entity);
        Task DeleteAsync(int hotelId, int amenityId);
        Task<bool> SaveAsync();
    }
}
