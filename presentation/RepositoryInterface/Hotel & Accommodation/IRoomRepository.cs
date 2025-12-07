using DomainLayer.Models.Hotels___Accommodation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.RepositoryInterface.Hotel___Accommodation
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAllAsync();
        Task<Room> GetByIdAsync(int Id);
        Task AddAsync(Room room);
        void UpdateAsync(Room room);
        Task DeleteAsync(int id);
        Task<bool> SaveChangesAsync();
    }
}
