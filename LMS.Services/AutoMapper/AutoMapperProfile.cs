namespace LMS.Services.AutoMapper;
using global::AutoMapper;
using LMS.DataBase.Entities;
using LMS.Services.DTO;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<BookDTO, Book>();
        CreateMap<SearchDTO, Book>();
    }

}
