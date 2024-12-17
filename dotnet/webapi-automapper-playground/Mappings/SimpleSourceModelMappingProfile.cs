using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using webapi_automapper_playground.Models.Model1;

namespace webapi_automapper_playground.Mappings;

public class SimpleSourceModelMappingProfile : Profile
{
  public SimpleSourceModelMappingProfile()
  {
    CreateMap<SimpleSourceModel1, SimpleTargetModel1>()
      .ForMember(d => d.TargetProp1, opt => opt.MapFrom(s => s.SourceProp1))
      .ForMember(d => d.TargetProp2, opt => opt.MapFrom(s => s.SourceProp2))
      .ForMember(d => d.TargetProp3, opt => opt.MapFrom(s => s.SourceProp3))
      .ForMember(d => d.TargetProp4, opt => opt.MapFrom(s => s.SourceProp4))
      .ReverseMap();
  }
}
