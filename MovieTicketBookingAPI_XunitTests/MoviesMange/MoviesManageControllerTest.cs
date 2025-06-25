using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIDashboard.Application.Interfaces;
using APIDashboard.Domain;
using Castle.Components.DictionaryAdapter.Xml;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MovieTicketBookingAPIDashboard.Controllers;
using MovieTicketBookingAPIDashboard.Models;
using MovieTicketBookingAPIDashboard.Models.MoviesManage;

namespace MovieTicketBookingAPI_XunitTests.MoviesMange
{
    public class MoviesManageControllerTest
    {
        private readonly Mock<IMoviesManageService> _moviesMangeServiceMock;
        private readonly MoviesManageController _moviesManageController;
        public MoviesManageControllerTest()
        {
            _moviesMangeServiceMock = new Mock<IMoviesManageService>(); 
            _moviesManageController = new MoviesManageController(_moviesMangeServiceMock.Object);
        }

        [Fact]
        public async Task AddMovies_ShouldReturnOk_WhenDataAddedSuccessfully()
        {
            // Arrange
            var moviesModel = new MoviesModel { Title = "Theri", Genre = "Family", DurationMinutes = 148 };
            _moviesMangeServiceMock.Setup(service => service.AddMovies(moviesModel)).ReturnsAsync(1);
            
            // Act
            var result = await _moviesManageController.AddMovies(moviesModel);
            
            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult);
            var actionResponse = okResult.Value as ActionResponse;
            Assert.NotNull(actionResponse);
            Assert.True(actionResponse.Success);
        }
        [Fact]
        public async Task AddMovies_ShouldReturnBadRequest_WhenDataNotAdded() 
        {
            //Arrange
            var moviesModel = new MoviesModel { Title = "Theri", Genre = "Family", DurationMinutes = 148 };
            _moviesMangeServiceMock.Setup(service => service.AddMovies(moviesModel)).ReturnsAsync(0);

            //Act
            var result = await _moviesManageController.AddMovies(moviesModel);

            //Assert
            var objectResult = result.Result as BadRequestObjectResult;
            objectResult.StatusCode.Should().Be(400);
            objectResult.Should().NotBeNull();
            var actionResponse=objectResult.Value as ActionResponse;
            actionResponse.Should().NotBeNull();
            actionResponse.Success.Should().BeFalse();
        }

        [Fact]
        public async Task GetAllMovies_ShouldReturnOk_WhenDataFetchedSuccessfully()
        {
            //Arrange
            var movieList=new List<MoviesModel>()
            {
                new MoviesModel { Title = "Theri", Genre = "Family", DurationMinutes = 148 },
                new MoviesModel { Title = "Jananayangan", Genre = "Politics", DurationMinutes = 168 }
            };
            _moviesMangeServiceMock.Setup(service=>service.GetAllMoviesList()).ReturnsAsync(movieList);

            //Act
            var result = await _moviesManageController.GetAllMoviesList();

            //Assert
            var objectResult = result?.Result as OkObjectResult;
            objectResult.Should().NotBeNull();
            objectResult.StatusCode.Should().Be(200);

            var response = objectResult.Value as GetAllMoviesResponse;
            response.Should().NotBeNull();
            response.MoviesList.Should().NotBeNull();
            response.ActionResponse.Success.Should().BeTrue();        } 
    }
}
