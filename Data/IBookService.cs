using BlazorCrud.Models;

namespace BlazorCrud.Data
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBook();
        Task<Book> GetBookDetails(int id);
        Task<bool> InsertBook(Book Book);
        Task<bool> UpdateBook(Book Book);
        Task<bool> DeleteBook(int Id);
        Task<bool> SaveBook(Book Book);
    }
}
