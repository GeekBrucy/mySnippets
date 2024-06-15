using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebAPI.Controllers;
using WebAPI.Core.Dtos;
using WebAPI.Core.Interfaces;
using WebAPI.Core.Model;

namespace WebAPI.Tests.Tests;

public class HomeControllerTests
{
  private List<BrainstormSession> GetTestSessions()
  {
    var sessions = new List<BrainstormSession>();
    sessions.Add(new BrainstormSession()
    {
      DateCreated = new DateTime(2016, 7, 2),
      Id = 1,
      Name = "Test One"
    });
    sessions.Add(new BrainstormSession()
    {
      DateCreated = new DateTime(2016, 7, 1),
      Id = 2,
      Name = "Test Two"
    });
    return sessions;
  }

  [Fact]
  public async Task ReturnViewModel_ListOfBrainstormSessions()
  {
    // Arrange
    var mockRepo = new Mock<IBrainstormSessionRepository>();
    mockRepo.Setup(repo => repo.ListAsync())
      .ReturnsAsync(GetTestSessions());

    var controller = new HomeController(mockRepo.Object);

    // Act
    var result = await controller.ListSessions();

    // Assert
    var viewResult = Assert.IsType<OkObjectResult>(result);
    var model = Assert.IsAssignableFrom<IEnumerable<StormSessionViewModel>>(
      viewResult.Value
    );

    Assert.Equal(2, model.Count());
  }
}
