using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using webapi_automapper_playground.Models.Model1.Nested;

namespace webapi_automapper_playground.Mappings;

public class NestedSourceChildMappingProfile : Profile
{
  public NestedSourceChildMappingProfile()
  {
    CreateMap<NestedSourceChild, NestedTargetChild>()
      .ForMember(d => d.TargetChildProp1, opt => opt.MapFrom(s => s.SourceChildProp1))
      .ForMember(d => d.TargetChildProp2, opt => opt.MapFrom(s => s.SourceChildProp2));
  }
}
