using AutoMapper;
using LMS.DataBase.Entities;
using LMS.DataBase.Interfaces;
using LMS.Services.DTO;
using LMS.Services.Interfaces;
using LMS.Utilities.Exceptions;
using LMS.Utilities.SortInput;

namespace LMS.Services.Implementations;

public class BookServices : IBookServices
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;
    List<Book> books;
    public BookServices(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
        books = _bookRepository.LoadBooks();


    }
    public void AddBook(BookDTO book)
    {
        var books1 = _mapper.Map<Book>(book);
        _bookRepository.AddBook(books1);
    }

    public void Update(int id, BookDTO book)
    {
        Book book1 = _mapper.Map<Book>(book);
        var exists = books.Find(b => b.ID == id);
        if (exists == null)
        {
            throw new BookNotFoundException("Book With Id not Found");
        }
        else
        {
            exists.Title = book1.Title;
            exists.Author = book1.Author;
            exists.Genre = book1.Genre;
            exists.PublishedYear = book1.PublishedYear;
            _bookRepository.UpdateBook(exists);
        }
    }
    public void Delete(int id)
    {
        var delbook = books.Find(book => book.ID == id);
        if (delbook == null)
        {
            throw new BookNotFoundException("Book with Id not found");
        }
        else
        {
            _bookRepository.DeleteBook(delbook);
        }
    }
    public List<Book> Search(SearchDTO searchDTO)
    {
        var searchbook = books.Where(b => (string.IsNullOrEmpty(searchDTO.Author) || b.Author == searchDTO.Author)
        && (string.IsNullOrEmpty(searchDTO.Title) || b.Title == searchDTO.Title)
        && (string.IsNullOrEmpty(searchDTO.Genre) || b.Genre == searchDTO.Genre));
        if (!searchbook.Any())
        {
            throw new BookNotFoundException("No books found matching the search criteria");
        }
        else
        {
            return searchbook.ToList();
        }
    }
    public List<Book> Sort(SortDTO sortDTO, int pageNumber, int pageSize)
    {
        List<Book> books = GetBook(pageNumber, pageSize);
        switch (sortDTO.PropertyName)
        {
            case Property.ID:
                books = sortDTO.OrderType == Order.Asce ? books.OrderBy(b => b.ID).ToList() :
                books.OrderByDescending(b => b.ID).ToList();
                break;
            case Property.Title:
                books = sortDTO.OrderType == Order.Asce ? books.OrderBy(b => b.Title).ToList() :
                books.OrderByDescending(b => b.Title).ToList();
                break;
            case Property.Author:
                books = sortDTO.OrderType == Order.Asce ? books.OrderBy(b => b.Author).ToList() :
                books.OrderByDescending(b => b.Author).ToList();
                break;
            case Property.Genre:
                books = sortDTO.OrderType == Order.Asce ? books.OrderBy(b => b.Genre).ToList() :
                books.OrderByDescending(b => b.Genre).ToList();
                break;
            case Property.PublishedYear:
                books = sortDTO.OrderType == Order.Asce ? books.OrderBy(b => b.PublishedYear).ToList() :
                books.OrderByDescending(b => b.PublishedYear).ToList();
                break;
            default:
                Console.WriteLine("Invalid PropertyNAme");
                break;
        }
        return books;
    }
    public List<Book> GetBook(int pageNumber, int pageSize)
    {
        if (books == null)
        {
            throw new NullReferenceException("BookRepository is null");
        }
        else
        {
            return books.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }

    }
}

