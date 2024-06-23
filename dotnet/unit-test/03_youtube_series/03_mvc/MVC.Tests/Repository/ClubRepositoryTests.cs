using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Data.Enum;
using MVC.Models;
using MVC.Repository;
using Xunit;

namespace MVC.Tests.Repository;

public class ClubRepositoryTests
{
    private async Task<AppDbContext> GetDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        var dbContext = new AppDbContext(options);
        dbContext.Database.EnsureCreated();
        if (await dbContext.Clubs.CountAsync() < 0)
        {
            for (int i = 0; i < 10; i++)
            {
                dbContext.Clubs.Add(
                    new Club()
                    {
                        Title = "Running Club 1",
                        Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                        Description = "This is the description of the first cinema",
                        ClubCategory = ClubCategory.City,
                        Address = new Address()
                        {
                            Street = "123 Main St",
                            City = "Charlotte",
                            State = "NC"
                        }
                    }
                );
                await dbContext.SaveChangesAsync();
            }
        }

        return dbContext;
    }

    [Fact]
    public async void ClubRepository_Add_ReturnsBool()
    {
        var club = new Club
        {
            Title = "Running Club 1",
            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
            Description = "This is the description of the first cinema",
            ClubCategory = ClubCategory.City,
            Address = new Address()
            {
                Street = "123 Main St",
                City = "Charlotte",
                State = "NC"
            }
        };

        var dbContext = await GetDbContext();
        var clubRepository = new ClubRepository(dbContext);

        //Act
        var result = clubRepository.Add(club);

        //Assert
        result.Should().BeTrue();
    }
    [Fact]
    public async void ClubRepository_GetByIdAsync_ReturnsClub()
    {
        //Arrange
        var id = 1;
        var dbContext = await GetDbContext();
        var clubRepository = new ClubRepository(dbContext);

        //Act
        var result = clubRepository.GetByIdAsync(id);

        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Task<Club>>();
    }

    [Fact]
    public async void ClubRepository_GetAll_ReturnsList()
    {
        //Arrange
        var dbContext = await GetDbContext();
        var clubRepository = new ClubRepository(dbContext);

        //Act
        var result = await clubRepository.GetAll();

        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<List<Club>>();
    }

    [Fact]
    public async void ClubRepository_SuccessfulDelete_ReturnsTrue()
    {
        //Arrange
        var club = new Club()
        {
            Title = "Running Club 1",
            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
            Description = "This is the description of the first cinema",
            ClubCategory = ClubCategory.City,
            Address = new Address()
            {
                Street = "123 Main St",
                City = "Charlotte",
                State = "NC"
            }
        };
        var dbContext = await GetDbContext();
        var clubRepository = new ClubRepository(dbContext);

        //Act
        clubRepository.Add(club);
        var result = clubRepository.Delete(club);
        var count = await clubRepository.GetCountAsync();

        //Assert
        result.Should().BeTrue();
        count.Should().Be(0);
    }

    [Fact]
    public async void ClubRepository_GetCountAsync_ReturnsInt()
    {
        //Arrange
        var club = new Club()
        {
            Title = "Running Club 1",
            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
            Description = "This is the description of the first cinema",
            ClubCategory = ClubCategory.City,
            Address = new Address()
            {
                Street = "123 Main St",
                City = "Charlotte",
                State = "NC"
            }
        };
        var dbContext = await GetDbContext();
        var clubRepository = new ClubRepository(dbContext);

        //Act
        clubRepository.Add(club);
        var result = await clubRepository.GetCountAsync();

        //Assert
        result.Should().Be(1);
    }

    [Fact]
    public async void ClubRepository_GetAllStates_ReturnsList()
    {
        //Arrange
        var dbContext = await GetDbContext();
        var clubRepository = new ClubRepository(dbContext);

        //Act
        var result = await clubRepository.GetAllStates();

        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<List<State>>();
    }

    [Fact]
    public async void ClubRepository_GetClubsByState_ReturnsList()
    {
        //Arrange
        var state = "NC";
        var club = new Club()
        {
            Title = "Running Club 1",
            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
            Description = "This is the description of the first cinema",
            ClubCategory = ClubCategory.City,
            Address = new Address()
            {
                Street = "123 Main St",
                City = "Charlotte",
                State = "NC"
            }
        };
        var dbContext = await GetDbContext();
        var clubRepository = new ClubRepository(dbContext);

        //Act
        clubRepository.Add(club);
        var result = await clubRepository.GetClubsByState(state);

        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<List<Club>>();
        result.First().Title.Should().Be("Running Club 1");
    }
}
