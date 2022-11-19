using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Generic
{
    public interface IGeneric<T> where T : class
    {
        Task Add(T Object);
        Task Update(T Object);
        Task<bool> Delete(T Object);
        Task<T> GetById(int Id);
        Task<List<T>> GetAll();
    }
}
