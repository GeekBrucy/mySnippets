using Bogus;
using linq.Models;
using static Bogus.DataSets.Name;

namespace linq.Data;

public class EmployeeFaker : Faker<Employee>
{
  public EmployeeFaker()
  {
    RuleFor(d => d.Name, f => f.Name.FullName());
    RuleFor(d => d.Age, f => f.Random.Int(18, 70));
    RuleFor(d => d.Salary, f => f.Random.Int(5000, 50000));
    RuleFor(d => d.Gender, f => f.PickRandom<Gender>().ToString());
  }
}
