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
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            roomRepository = roomRepository;
        }

        public async Task<bool> AddAsync(RoomDto dto)
        {
            var room = new Room
            {
                HotelId = dto.HotelId,
                RoomType = dto.RoomType,
                Capacity = dto.Capacity,
                BasePrice = dto.BasePrice
            };

            await roomRepository.AddAsync(room);
            return await roomRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingAmenity = await roomRepository.GetByIdAsync(id);
            if (existingAmenity == null)
            {
                return false;
            }
            await roomRepository.DeleteAsync(id);
            
            return await roomRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<RoomDto>> GetAllAsync()
        {
            var rooms = await roomRepository.GetAllAsync();

            return rooms.Select(r => new RoomDto
            {
                Id = r.Id,
                HotelId = r.HotelId,
                RoomType = r.RoomType,
                Capacity = r.Capacity,
                BasePrice = r.BasePrice
            });
        }

        public async Task<RoomDto> GetByIdAsync(int Id)
        {
            var r = await roomRepository.GetByIdAsync(Id);
            if (r == null) return null;

            return new RoomDto
            {
                Id = r.Id,
                HotelId = r.HotelId,
                RoomType = r.RoomType,
                Capacity = r.Capacity,
                BasePrice = r.BasePrice
            };
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await roomRepository.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(RoomDto dto)
        {
            var r = await roomRepository.GetByIdAsync(dto.Id);
            if (r == null) return false;

            r.HotelId = dto.HotelId;
            r.RoomType = dto.RoomType;
            r.Capacity = dto.Capacity;
            r.BasePrice = dto.BasePrice;

            roomRepository.UpdateAsync(r);
            return await roomRepository.SaveChangesAsync();
        }
        


    }
}
