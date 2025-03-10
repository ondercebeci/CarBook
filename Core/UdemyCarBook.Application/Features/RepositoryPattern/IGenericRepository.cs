using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.RepositoryPattern
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();
        void Create(T item);
        void Update(T item);
        void Remove(T item);
        T GetById(int id);
        List<T> GetCommentsByBlogId(int id);
        public int GetCountCommentByBlg(int id);
    }
}
