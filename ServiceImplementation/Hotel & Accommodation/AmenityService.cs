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
    public class AmenityService : IAmenityService
    {
        public readonly IAmenityRepository _amenityRepository;
        public AmenityService(IAmenityRepository amenityRepository)
        {
            _amenityRepository = amenityRepository;
        }

        public async Task<AmenityDto> GetByIdAsync(int id)
        {
            var a = await _amenityRepository.GetByIdAsync(id);
            if (a == null) return null;

            return new AmenityDto
            {
                Id = a.Id,
                Name = a.Name
            };
        }
        public async Task<IEnumerable<AmenityDto>> GetAllAsync()
        {
            var amenities = await _amenityRepository.GetAllAsync();

            return amenities.Select(a => new AmenityDto
            {
                Id = a.Id,
                Name = a.Name
            });
        }
        public async Task<bool> UpdateAsync(AmenityDto dto)
        {
            var entity = await _amenityRepository.GetByIdAsync(dto.Id);
            if (entity == null) return false;

            entity.Name = dto.Name;

            _amenityRepository.UpdateAsync(entity);
            return await _amenityRepository.SaveAsync();
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var existingAmenity = await _amenityRepository.GetByIdAsync(id);
            if (existingAmenity == null)
            {
                return false;
            }
            await _amenityRepository.DeleteAsync(id);
            return true;
        }
        public async Task<bool> AddAsync(AmenityDto dto)
        {
            var entity = new Amenity
            {
                Name = dto.Name
            };

            await _amenityRepository.AddAsync(entity);
            return await _amenityRepository.SaveAsync();
        }
    }
}
