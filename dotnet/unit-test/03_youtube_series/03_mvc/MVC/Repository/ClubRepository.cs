using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC.Data;
using MVC.Data.Enum;
using MVC.Interfaces;
using MVC.Models;

namespace MVC.Repository;

public class ClubRepository : IClubRepository
{
  private readonly DummyContext _context;
  public ClubRepository(DummyContext context)
  {
    _context = context;
  }

  public bool Add(Club club)
  {
    _context.Clubs.Add(club);

    return true;
  }

  public bool Delete(Club club)
  {
    _context.Clubs.Remove(club);

    return true;
  }

  public async Task<IEnumerable<Club>> GetAll()
  {
    return await Task.FromResult(_context.Clubs);
  }

  public async Task<List<City>> GetAllCitiesByState(string state)
  {
    return await Task.FromResult(_context.Cities.ToList());
  }

  public async Task<List<State>> GetAllStates()
  {
    return await Task.FromResult(_context.States.ToList());
  }

  public async Task<Club?> GetByIdAsync(int id)
  {
    return await Task.FromResult(_context.Clubs.FirstOrDefault(c => c.Id == id));
  }

  public async Task<Club?> GetByIdAsyncNoTracking(int id)
  {
    return await Task.FromResult(_context.Clubs.FirstOrDefault(c => c.Id == id));
  }

  public async Task<IEnumerable<Club>> GetClubByCity(string city)
  {
    return await Task.FromResult(_context.Clubs.Where(c => c.Address.City.Contains(city)).Distinct());
  }

  public async Task<IEnumerable<Club>> GetClubsByCategoryAndSliceAsync(ClubCategory category, int offset, int size)
  {
    return await Task.FromResult
    (
      _context.Clubs
        .Where(c => c.ClubCategory == category)
        .Skip(offset)
        .Take(size)
    );
  }

  public async Task<IEnumerable<Club>> GetClubsByState(string state)
  {
    return await Task.FromResult(_context.Clubs.Where(c => c.Address.State.Contains(state)));
  }

  public async Task<int> GetCountAsync()
  {
    return await Task.FromResult(_context.Clubs.Count);
  }

  public async Task<int> GetCountByCategoryAsync(ClubCategory category)
  {
    return await Task.FromResult(_context.Clubs.Count(c => c.ClubCategory == category));
  }

  public async Task<IEnumerable<Club>> GetSliceAsync(int offset, int size)
  {
    return await Task.FromResult(_context.Clubs.Skip(offset).Take(size));
  }

  public bool Save()
  {
    return true;
  }

  public bool Update(Club club)
  {
    return true;
  }
}
