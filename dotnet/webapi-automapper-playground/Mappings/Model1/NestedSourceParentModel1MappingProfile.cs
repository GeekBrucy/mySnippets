using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using webapi_automapper_playground.Models.Model1.Nested;

namespace webapi_automapper_playground.Mappings;

public class NestedSourceParentModel1MappingProfile : Profile
{
  public NestedSourceParentModel1MappingProfile()
  {
    CreateMap<NestedSourceParent, NestedTargetParent>()
      .ForMember(d => d.TargetParentProp, opt => opt.MapFrom(s => s.SourceParentProp))
      .ForMember(d => d.TargetChildren1, opt => opt.MapFrom(s => s.SourceChildren1))
      .ForPath(d => d.TargetChild1.TargetChild1Prop1, opt => opt.MapFrom(s => s.SourceChild1.SourceChild1Prop1));
  }
}
