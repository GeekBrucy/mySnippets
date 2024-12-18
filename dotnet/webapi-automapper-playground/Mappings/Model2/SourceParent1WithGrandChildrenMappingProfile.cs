using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using webapi_automapper_playground.Models.Model2;

namespace webapi_automapper_playground.Mappings.Model2;

public class SourceParent1WithGrandChildrenMappingProfile : Profile
{
  public SourceParent1WithGrandChildrenMappingProfile()
  {

    CreateMap<SourceModel2Parent, TargetModel2Parent1>()
      .ForMember(dest => dest.TargetChildren, opt => opt.MapFrom(src =>
          src.SourceChildren.GroupBy(c => c.SourceChildProp1)));
    CreateMap<IGrouping<int, SourceModel2Child>, TargetModel2Child1>()
      .ForMember(dest => dest.TargetModel2ChildProp1, opt => opt.MapFrom(src => src.Key))
      .ForMember(dest => dest.TargetGrandChildren1, opt => opt.Ignore()) // Will handle in AfterMap
      .ForMember(dest => dest.TargetGrandChildren2, opt => opt.Ignore())
      .AfterMap((src, dest) =>
      {
        foreach (var child in src)
        {

          // Append to GrandChildren1 if Type is "Type1"
          if (child.Type == "Type1")
          {
            dest.TargetGrandChildren1.Add(new TargetModel2GrandChild1
            {
              TargetChild1Prop2 = child.SourceChildProp2,
              TargetChild1Prop3 = child.SourceChildProp3,
              TargetChild1Prop4 = child.SourceChildProp4,
              TargetChild1Prop5 = child.SourceChildProp5,
              TargetChild1Prop6 = child.SourceChildProp6,
              TargetChild1Prop7 = child.SourceChildProp7,
            });
          }

          // Append to GrandChildren2 if Type is "Type2"
          if (child.Type == "Type2")
          {
            dest.TargetGrandChildren2.Add(new TargetModel2GrandChild2
            {
              TargetChild2Prop2 = child.SourceChildProp2,
              TargetChild2Prop3 = child.SourceChildProp3,
              TargetChild2Prop4 = child.SourceChildProp4,
              TargetChild2Prop5 = child.SourceChildProp5,
              TargetChild2Prop6 = child.SourceChildProp6,
              TargetChild2Prop7 = child.SourceChildProp7,
            });
          }
        }
      });
  }
}
