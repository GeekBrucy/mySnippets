using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_datetime_string_test.Models;

namespace _01_datetime_string_test.Services.Interfaces;

public interface ICosmosService
{
  Task<IEnumerable<TestModel>> RetrieveAllTestDatasAsync();
}
