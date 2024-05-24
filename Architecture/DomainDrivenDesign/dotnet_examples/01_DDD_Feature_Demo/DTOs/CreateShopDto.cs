using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_DDD_Feature_Demo.Models;

namespace _01_DDD_Feature_Demo.DTOs;

public record CreateShopDto(string Name, Geo Location);
