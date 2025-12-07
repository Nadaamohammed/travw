using DomainLayer.Models.Hotels___Accommodation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.RepositoryInterface.Hotel___Accommodation
{
    public interface IHotelRepository
    {
        Task<IEnumerable<Hotel>> GetAllAsync();
        Task<Hotel> GetByIdAsync(int id);
        Task AddAsync(Hotel entity);
        void Update(Hotel entity);
        Task Delete(int id);
        Task<bool> SaveAsync();
        Task<IEnumerable<Hotel>> GetHotelsByCityAsync(string city);
        //Task<IEnumerable<object>> SearchHotelsAsync(string location, DateTime checkIn, DateTime checkOut, int guests);
        Task<IEnumerable<Hotel>> SearchHotelsAsync(string location, DateTime checkIn, DateTime checkOut, int guests);
        Task<Hotel> GetPropertyDetailsAsync(int propertyId);
        //Task<Hotel> CreateBookingAsync(Hotel dto);
        Task<IEnumerable<Hotel>> GetSimilarPropertiesAsync(int propertyId);

    }
}
