using System;
using LMS.DataBase.Entities;
using LMS.Services.DTO;

namespace LMS.Services.Interfaces;

public interface IBookServices
{
    void AddBook(BookDTO bookDTO);
    List<Book> GetBook(int pageNumber, int pageSize);
    void Update(int id, BookDTO bookDTO);
    void Delete(int id);
    List<Book> Search(SearchDTO searchDTO);
    List<Book> Sort(SortDTO sortDTO, int pageNumber, int pageSize);
}
