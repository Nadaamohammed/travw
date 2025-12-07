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
    public class HotelAmenityService : IHotelAmenityService
    {
        private readonly IHotelAmenityRepository _hotelAmenityRepo;
        public HotelAmenityService(IHotelAmenityRepository hotelAmenityRepo)
        {
            _hotelAmenityRepo = hotelAmenityRepo;
        }
        public async Task<bool> AddAsync(HotelAmenityDto dto)
        {
            var entity = new HotelAmenity
            {
                HotelId = dto.HotelId,
                AmenityId = dto.AmenityId
            };

            await _hotelAmenityRepo.AddAsync(entity);
            return await _hotelAmenityRepo.SaveAsync();
        }

      
      

        public async Task DeleteAsync(int hotelId, int amenityId)
        {
            var existingHotelAmenity = await _hotelAmenityRepo.GetByIdAsync(hotelId, amenityId);
            if (existingHotelAmenity != null)
            {
                await _hotelAmenityRepo.DeleteAsync(hotelId, amenityId);
                await _hotelAmenityRepo.SaveAsync();
            }
        }

        public async Task<IEnumerable<HotelAmenityDto>> GetAllAsync()
        {
            var list = await _hotelAmenityRepo.GetAllAsync();
            return list.Select(x => new HotelAmenityDto
            {
                HotelId = x.HotelId,
                AmenityId = x.AmenityId
            });
        }

        public async Task<HotelAmenityDto> GetByIdAsync(int hotelId, int amenityId)
        {
            var hotelAmenity = await _hotelAmenityRepo.GetByIdAsync(hotelId, amenityId);
            if (hotelAmenity == null)
            {
                return null;

            }
            return new HotelAmenityDto
            {
                HotelId = hotelAmenity.HotelId,
                AmenityId = hotelAmenity.AmenityId
            };
        }

        async Task<bool> IHotelAmenityService.DeleteAsync(int hotelId, int amenityId)
        {
            await _hotelAmenityRepo.DeleteAsync(hotelId, amenityId);
            return await _hotelAmenityRepo.SaveAsync();
        }

        Task<IEnumerable<HotelAmenityDto>> IHotelAmenityService.GetAllAsync()
        {
            throw new NotImplementedException();
        }

    


        Task<HotelAmenityDto> IHotelAmenityService.GetByIdAsync(int hotelId, int amenityId)
        {
            throw new NotImplementedException();
        }
    }
}
