using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using webapi_automapper_playground.Models.Model2;

namespace webapi_automapper_playground.Mappings.Model2;

public class SourceParent2WithGrandChildrenMappingProfile : Profile
{
    public SourceParent2WithGrandChildrenMappingProfile()
    {
        // Map SourceModel2Parent to TargetModel2Parent2
        CreateMap<SourceModel2Parent, TargetModel2Parent2>()
            .ForMember(dest => dest.TargetChildren, opt => opt.MapFrom(src =>
                src.SourceChildren.GroupBy(c => c.SourceChildProp1))); // Group by SourceChildProp1

        // Map grouped children to TargetModel2Child2
        CreateMap<IGrouping<int, SourceModel2Child>, TargetModel2Child2>()
            .ForMember(dest => dest.TargetModel2ChildProp1, opt => opt.MapFrom(src => src.Key))
            .ForMember(dest => dest.TargetGrandChildren1, opt => opt.Ignore()) // Handled in AfterMap
            .AfterMap((src, dest) =>
            {
                foreach (var child in src)
                {
                    // Assign the first matching Type1 child to TargetGrandChild1
                    if (child.Type == "Type1" && dest.TargetGrandChildren1 == null)
                    {
                        dest.TargetGrandChildren1 = new TargetModel2GrandChild1
                        {
                            TargetChild1Prop2 = child.SourceChildProp2,
                            TargetChild1Prop3 = child.SourceChildProp3,
                            TargetChild1Prop4 = child.SourceChildProp4,
                            TargetChild1Prop5 = child.SourceChildProp5,
                            TargetChild1Prop6 = child.SourceChildProp6,
                            TargetChild1Prop7 = child.SourceChildProp7,
                        };
                    }
                }
            });
    }
}
