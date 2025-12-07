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
    public class PriceAndAvailbilityService : IPriceAndAvailbilityService
    {
        private readonly IPriceAndAvailabilityRepository _priceAndAvailbilityRepo;
        public PriceAndAvailbilityService(IPriceAndAvailabilityRepository priceAndAvailbilityRepo)
        {
            _priceAndAvailbilityRepo = priceAndAvailbilityRepo;
        }

        public async Task<bool> AddAsync(PriceAndAvailabilityDto dto)
        {
            var entity = new PricesAndAvailability
            {
                RoomId = dto.RoomId,
                Date = dto.Date,
                Price = dto.Price,
                AvailableUnits = dto.AvailableUnits
            };

            await _priceAndAvailbilityRepo.AddAsync(entity);
            return await _priceAndAvailbilityRepo.SaveAsync();
        }

        public async Task<bool> DeleteAsync(int roomId, DateTime date)
        {
            await _priceAndAvailbilityRepo.DeleteAsync(roomId, date);
            return await _priceAndAvailbilityRepo.SaveAsync();
        }

        public async Task<IEnumerable<PriceAndAvailabilityDto>> GetAllAsync()
        {
            var list = await _priceAndAvailbilityRepo.GetAllAsync();
            return list.Select(x => new PriceAndAvailabilityDto
            {
                RoomId = x.RoomId,
                Date = x.Date,
                Price = x.Price,
                AvailableUnits = x.AvailableUnits
            });
        }

        public async Task<PriceAndAvailabilityDto> GetByIdAsync(int roomId, DateTime date)
        {
            var entity = await _priceAndAvailbilityRepo.GetByIdAsync(roomId, date);
            if (entity == null)
            {
                return null;
            }
            return new PriceAndAvailabilityDto
            {
                RoomId = entity.RoomId,
                Date = entity.Date,
                Price = entity.Price,
                AvailableUnits = entity.AvailableUnits
            };
        }

        public async Task<bool> UpdateAsync(PriceAndAvailabilityDto dto)
        {
            var entity = await _priceAndAvailbilityRepo.GetByIdAsync(dto.RoomId, dto.Date);
            if (entity == null) return false;

            entity.Price = dto.Price;
            entity.AvailableUnits = dto.AvailableUnits;

            _priceAndAvailbilityRepo.Update(entity);
            return await _priceAndAvailbilityRepo.SaveAsync();
        }

        public async Task<IEnumerable<RoomAvailabilityDto>> GetRoomAvailabilityAsync(int propertyId, DateTime start, DateTime end)
        {
            var data = await _priceAndAvailbilityRepo.GetRoomAvailabilityAsync(propertyId, start, end);

            return data.Select(p => new RoomAvailabilityDto
            {
                RoomId = p.RoomId,
                Date = p.Date,
                Price = p.Price,
                AvailableUnits = p.AvailableUnits
            });
        }


    }
}
