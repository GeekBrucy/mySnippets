using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using webapi_automapper_playground.Models.InterchangeableModels;

namespace webapi_automapper_playground.Mappings.InterchangeableModels;

public class DataDTOResolver : IValueResolver<DBMasterData, MasterDataDTO, BaseDataDTO>
{
  public BaseDataDTO Resolve(DBMasterData source, MasterDataDTO destination, BaseDataDTO destMember, ResolutionContext context)
  {
    if (source.PreviousMasterId.HasValue && source.PreviousSubId.HasValue)
    {
      return new PreviousDataDTO
      {
        PreviousMasterIdDTO = source.PreviousMasterId.Value,
        PreviousSubIdDTO = source.PreviousSubId.Value
      };
    }

    if (source.Data != null)
    {
      return new CurrentDataDTO
      {
        Prop1DTO = source.Data.Prop1,
        Prop2DTO = source.Data.Prop2,
        Prop3DTO = source.Data.Prop3
      };
    }

    return null; // Fallback for when no conditions are met
  }
}
