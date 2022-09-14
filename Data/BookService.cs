using BlazorCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrud.Data
{
    public class BookService : IBookService
    {
        private readonly MyBooksContext _context;

        public BookService(MyBooksContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteBook(int Id)
        {
            var book = await _context.books.FindAsync(Id);
            _context.books.Remove(book);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Book>> GetAllBook()
        {
            return await _context.books.ToListAsync();
        }

        public async Task<Book> GetBookDetails(int id)
        {
            return await _context.books.FindAsync(id);

        }

        public async Task<bool> InsertBook(Book Book)
        {
            _context.books.Add(Book);
            return await _context.SaveChangesAsync() > 0;

        }

        public async Task<bool> SaveBook(Book Book)
        {
           if(Book.BookId > 0)
                return await UpdateBook(Book);
           else
                return await InsertBook(Book);
        }

        public async Task<bool> UpdateBook(Book Book)
        {
            _context.Entry(Book).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
