using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Task<Category?> GetByID(int id);
        Task<DBOperationStatus> AddAsync(Category category);
        Task<DBOperationStatus> UpdateAsync(Category category);
        Task<DBOperationStatus> DeleteAsync(int id);
    }
}
