using LMS.DataBase.DbContextClass;
using LMS.DataBase.Entities;
using LMS.DataBase.Interfaces;


namespace LMS.DataBase.Implementations;

public class BookRepository : IBookRepository
{
    private readonly BookDbContext _bookDbContext;
    public BookRepository(BookDbContext bookDbContext)
    {
        _bookDbContext = bookDbContext;
    }
    public List<Book> LoadBooks()
    {
        return _bookDbContext.books.ToList();
    }

    public void UpdateBook(Book book)
    {
        _bookDbContext.books.Update(book);
        _bookDbContext.SaveChanges();
    }
    public void AddBook(Book book)
    {
        _bookDbContext.books.Add(book);
        _bookDbContext.SaveChanges();
    }
    public void DeleteBook(Book books)
    {
        _bookDbContext.books.RemoveRange(books);
        _bookDbContext.SaveChanges();

    }
  


}
