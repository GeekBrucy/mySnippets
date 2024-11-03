using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ef_core_with_mapper_lib.Models.DBModels;
using ef_core_with_mapper_lib.Models.PayloadModels;

namespace ef_core_with_mapper.Mappings;

public class BookMappingProfile : Profile
{
  public BookMappingProfile()
  {
    CreateMap<Book, BookFE>()
        .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => src.Id))
        .ForMember(dest => dest.BookTitle, opt => opt.MapFrom(src => src.Title))
        .ForMember(dest => dest.BookAuthor, opt => opt.MapFrom(src => src.Author))
        .ForMember(dest => dest.IsArchived, opt => opt.MapFrom(src => src.IsDeleted))
        .ReverseMap() // Enables BookViewModel to Book mapping
        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BookId))
        .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.BookTitle))
        .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.BookAuthor))
        .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsArchived));
  }
}
