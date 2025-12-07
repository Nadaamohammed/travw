using Shared.Dto_s.Hotel___Accommodation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction.Hotel___Accommodation
{
    public interface IHotelService
    {
        Task<IEnumerable<HotelDto>> GetAllAsync();
        Task<HotelDto> GetByIdAsync(int id);
        Task<bool> AddAsync(HotelDto dto);
        Task<bool> UpdateAsync(HotelDto dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<HotelDto>> SearchPropertiesAsync(string location, DateTime checkIn, DateTime checkOut, int guests);
        Task<HotelDetailsDto> GetPropertyDetailsAsync(int propertyId);
        //Task<CreateBookingDto> CreateBookingAsync(CreateBookingDto dto);
       Task<IEnumerable<HotelDto>> GetSimilarPropertiesAsync(int propertyId);
    }
}
