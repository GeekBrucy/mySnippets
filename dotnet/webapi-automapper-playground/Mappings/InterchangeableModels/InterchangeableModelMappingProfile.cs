using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using webapi_automapper_playground.Models.InterchangeableModels;

namespace webapi_automapper_playground.Mappings.InterchangeableModels;

public class InterchangeableModelMappingProfile : Profile
{
  public InterchangeableModelMappingProfile()
  {
    // Mapping for DBMasterData to MasterDataDTO
    CreateMap<DBMasterData, MasterDataDTO>()
        .ForMember(dest => dest.MasterDTOProp1, opt => opt.MapFrom(src => src.MasterProp1))
        .ForMember(dest => dest.MasterDTOProp2, opt => opt.MapFrom(src => src.MasterProp2))
        .ForMember(dest => dest.DataDTO, opt => opt.MapFrom<DataDTOResolver>());
  }
}
