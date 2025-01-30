using LMS.DataBase.Entities;

namespace LMS.DataBase.Interfaces;

public interface IBookRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    List<Book> LoadBooks();
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="book"></param>
    void AddBook(Book book);
    void UpdateBook(Book book);
    void DeleteBook(Book book);
}
