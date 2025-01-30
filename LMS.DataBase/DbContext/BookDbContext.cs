using LMS.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace LMS.DataBase.DbContextClass;

public class BookDbContext : DbContext
{
    public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
    {
    }
    public DbSet<Book> books { get; set; }

}
