using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ef_core_with_mapper_lib.Models.DBModels;
using ef_core_with_mapper_lib.Models.PayloadModels;

namespace ef_core_with_mapper.Mappings;

public class LibraryMappingProfile : Profile
{
  public LibraryMappingProfile()
  {
    CreateMap<Library, LibraryFE>()
        .ForMember(dest => dest.LibraryId, opt => opt.MapFrom(src => src.Id))
        .ForMember(dest => dest.LibraryName, opt => opt.MapFrom(src => src.Name))
        .ForMember(dest => dest.LibraryLocation, opt => opt.MapFrom(src => src.Location))
        .ForMember(dest => dest.IsArchived, opt => opt.MapFrom(src => src.IsDeleted))
        .ForMember(dest => dest.BookList, opt => opt.MapFrom(src => src.Books))
        .ReverseMap()
        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.LibraryId))
        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.LibraryName))
        .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.LibraryLocation))
        .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsArchived))
        .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.BookList));
  }
}
