using DomainLayer.Models.Booking_Transaction;
using DomainLayer.Models.Hotels___Accommodation;
using DomainLayer.RepositoryInterface.Hotel___Accommodation;
using ServiceAbstraction.Hotel___Accommodation;
using Shared.Dto_s.Hotel___Accommodation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.Hotel___Accommodation
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepo;
        public HotelService(IHotelRepository hotelRepo)
        {
            _hotelRepo = hotelRepo;
        }

        public async Task<bool> AddAsync(HotelDto dto)
        {
            var hotel = new Hotel
            {
                Name = dto.Name,
                Description = dto.Description,
                ImageUrel = dto.ImageUrel,
                Address = dto.Address,
                City = dto.City,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude,
                StarRating = dto.StarRating,
                CheckInTime = dto.CheckInTime,
                CheckOutTime = dto.CheckOutTime
            };

            await _hotelRepo.AddAsync(hotel);
            return await _hotelRepo.SaveAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _hotelRepo.Delete(id);
            return await _hotelRepo.SaveAsync();
        }

        public async Task<IEnumerable<HotelDto>> GetAllAsync()
        {
            var hotels = await _hotelRepo.GetAllAsync();

            return hotels.Select(h => new HotelDto
            {
                Id = h.Id,
                Name = h.Name,
                Description = h.Description,
                ImageUrel = h.ImageUrel,
                Address = h.Address,
                City = h.City,
                Latitude = h.Latitude,
                Longitude = h.Longitude,
                StarRating = h.StarRating,
                CheckInTime = h.CheckInTime,
                CheckOutTime = h.CheckOutTime
            });
        }

        public async Task<HotelDto> GetByIdAsync(int id)
        {
            var h = await _hotelRepo.GetByIdAsync(id);
            if (h == null) return null;
            return new HotelDto
            {
                Id = h.Id,
                Name = h.Name,
                Description = h.Description,
                ImageUrel = h.ImageUrel,
                Address = h.Address,
                City = h.City,
                Latitude = h.Latitude,
                Longitude = h.Longitude,
                StarRating = h.StarRating,
                CheckInTime = h.CheckInTime,
                CheckOutTime = h.CheckOutTime
            };
        }

        public async Task<bool> UpdateAsync(HotelDto dto)
        {
            var h = await _hotelRepo.GetByIdAsync(dto.Id);
            if (h == null) return false;

            h.Name = dto.Name;
            h.Description = dto.Description;
            h.ImageUrel = dto.ImageUrel;
            h.Address = dto.Address;
            h.City = dto.City;
            h.Latitude = dto.Latitude;
            h.Longitude = dto.Longitude;
            h.StarRating = dto.StarRating;
            h.CheckInTime = dto.CheckInTime;
            h.CheckOutTime = dto.CheckOutTime;

            _hotelRepo.Update(h);
            return await _hotelRepo.SaveAsync();
        }
        public async Task<IEnumerable<HotelDto>> GetHotelsByCityAsync(string city)
        {
            var hotels = await _hotelRepo.GetHotelsByCityAsync(city);
            return hotels.Select(h => new HotelDto
            {
                Id = h.Id,
                Name = h.Name,
                Description = h.Description,
                ImageUrel = h.ImageUrel,
                Address = h.Address,
                City = h.City,
                Latitude = h.Latitude,
                Longitude = h.Longitude,
                StarRating = h.StarRating,
                CheckInTime = h.CheckInTime,
                CheckOutTime = h.CheckOutTime
            });
        }

        public async Task<IEnumerable<HotelDto>> SearchPropertiesAsync(string location, DateTime checkIn, DateTime checkOut, int guests)
        {
            var hotels = await _hotelRepo.SearchHotelsAsync(location, checkIn, checkOut, guests);

            return hotels.Select(h => new HotelDto
            {
                Id = h.Id,
                Name = h.Name,
                City = h.City,
                StarRating = h.StarRating
            });
        }
        public async Task<HotelDetailsDto> GetPropertyDetailsAsync(int propertyId)
        {
            var hotel = await _hotelRepo.GetPropertyDetailsAsync(propertyId);

            return new HotelDetailsDto
            {
                Id = hotel.Id,
                Name = hotel.Name,
                City = hotel.City,
                Rooms = hotel.Rooms.ToList(),
                Amenities = hotel.HotelAmenities.Select(a => a.Amenity.Name)
            };
        }
        public async Task<IEnumerable<HotelDto>> GetSimilarPropertiesAsync(int propertyId)
        {
            var hotels = await _hotelRepo.GetSimilarPropertiesAsync(propertyId);
            return hotels.Select(h => new HotelDto { Id = h.Id, Name = h.Name });
        }

        
    }
}
        