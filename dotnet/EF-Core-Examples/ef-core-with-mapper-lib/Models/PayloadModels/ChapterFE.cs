using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ef_core_with_mapper_lib.Models.PayloadModels;

public class ChapterFE
{
  public int? ChapterId { get; set; }
  public string ChapterTitle { get; set; }
  public int ChapterNumber { get; set; }
}