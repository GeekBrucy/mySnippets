using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ef_core_with_mapper_lib.Models.DBModels;
using ef_core_with_mapper_lib.Models.PayloadModels;

namespace ef_core_with_mapper.Mappings;

public class ChapterMappingProfile : Profile
{
  public ChapterMappingProfile()
  {
    CreateMap<Chapter, ChapterFE>()
        .ForMember(dest => dest.ChapterId, opt => opt.MapFrom(src => src.Id))
        .ForMember(dest => dest.ChapterTitle, opt => opt.MapFrom(src => src.Title))
        .ForMember(dest => dest.ChapterNumber, opt => opt.MapFrom(src => src.Number))
        .ForMember(dest => dest.IsArchived, opt => opt.MapFrom(src => src.IsDeleted))
        .ReverseMap();
  }
}
