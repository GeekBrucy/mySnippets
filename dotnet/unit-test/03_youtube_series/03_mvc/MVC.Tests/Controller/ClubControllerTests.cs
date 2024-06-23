using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Controllers;
using MVC.Interfaces;
using MVC.Models;
using Xunit;

namespace MVC.Tests.Controller;

public class ClubControllerTests
{
  private IClubRepository _clubRepo;
  private IPhotoService _photoService;
  private IHttpContextAccessor _httpCtxAccessor;
  private ClubController _controller;
  public ClubControllerTests()
  {
    _clubRepo = A.Fake<IClubRepository>();
    _photoService = A.Fake<IPhotoService>();
    _httpCtxAccessor = A.Fake<IHttpContextAccessor>();
    _controller = new ClubController(_clubRepo, _photoService);
  }

  [Fact]
  public void ClubController_Index_ReturnsSuccess()
  {
    // Arrange
    var clubs = A.Fake<IEnumerable<Club>>();
    A.CallTo(() => _clubRepo.GetAll()).Returns(clubs);
    // Act
    var result = _controller.Index();
    // Assert
    result.Should().BeOfType<Task<IActionResult>>();
  }

  [Fact]
  public void ClubController_Detail_ReturnsSuccess()
  {
    // Arrange
    var id = 1;
    var club = A.Fake<Club>();
    A.CallTo(() => _clubRepo.GetByIdAsync(id)).Returns(club);
    // Act
    var result = _controller.DetailClub(id);
    // Assert
    result.Should().BeOfType<Task<IActionResult>>();
  }
}
