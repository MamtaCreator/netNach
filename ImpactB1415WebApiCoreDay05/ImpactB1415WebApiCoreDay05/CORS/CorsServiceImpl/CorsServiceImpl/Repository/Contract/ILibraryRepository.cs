using CorsServiceImpl.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorsServiceImpl.Repository.Contract
{
    public interface ILibraryRepository<T>
    {
        IEnumerable<T> GetAllAuthor();
        Author PostAuthor(Author author);
        Author UpdateAuthor(Author author);
        int DeleteAuthor(Guid authorId);
        Author GetAuthor(Guid authorId);
    }
}
