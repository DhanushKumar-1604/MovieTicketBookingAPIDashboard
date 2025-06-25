using APIDashboard.Application.Interfaces;
using APIDashboard.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MovieTicketBookingAPIDashboard.Models;
using MovieTicketBookingAPIDashboard.Models.MoviesManage;

namespace MovieTicketBookingAPIDashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesManageController : ControllerBase
    {
        private readonly IMoviesManageService _moviesManageService;
        public MoviesManageController(IMoviesManageService manageService)
        {
            _moviesManageService = manageService;
        }


        [HttpPost("AddMovies")]
        public async Task<ActionResult<ActionResponse>> AddMovies(MoviesModel moviesModel)
        {
            try
            {
                var result=await _moviesManageService.AddMovies(moviesModel);
                if (result != 0) 
                {
                    return Ok(new ActionResponse
                    {
                        Message="Data Added Successfully!",
                        Success=true

                    });
                }
                else
                {
                    return BadRequest(new ActionResponse
                    {
                        Message="Cannot add the data!",
                        Success=false
                    });
                }
            }
            catch
            {
                return StatusCode(500);
            }
        } 

        [HttpGet("GetAllMovies")]
        public async Task<ActionResult<GetAllMoviesResponse>?> GetAllMoviesList() {
            try
            {
                var result = await _moviesManageService.GetAllMoviesList();

                if (result != null)
                {
                    return Ok(new GetAllMoviesResponse
                    {
                        MoviesList=new GetAllMoviesList { getAllMovies=result},
                        ActionResponse=new ActionResponse
                        {
                            Message="Retrive All data Successfully!",
                            Success=true
                        }
                    });
                }
                else
                {
                    return BadRequest(new GetAllMoviesResponse
                    {
                        ActionResponse=new ActionResponse
                        {
                            Message="No data is there!",
                            Success=false
                        }
                    });
                }
            }
            catch 
            {
                return StatusCode(500);
            }


        }

        [HttpGet("GetMovieById")]
        public async Task<ActionResult<GetMovieByIdResponse>?> GetMovieById(int movieId)
        {
            try
            {
                var result = await _moviesManageService.GetMovieById(movieId);
                if (result == null)
                {
                    return BadRequest(new GetMovieByIdResponse
                    {
                        ActionResponse=new ActionResponse
                        {
                            Message="Error occured! returned null value",
                            Success=false
                        }
                    });
                }
                var response = result.FirstOrDefault();
                if (response == null)
                {
                    return BadRequest(new GetMovieByIdResponse
                    {
                        ActionResponse=new ActionResponse
                        {
                            Message="No data is there given Movie Id!",
                            Success=false
                        }
                    });
                }
                else
                {
                    return Ok(new GetMovieByIdResponse
                    {
                        MovieDetails=new GetMovieByIdModel
                        {
                            MovieId=response.MovieId,
                            Title=response.Title,
                            Genre=response.Genre,
                            DurationMinutes=response.DurationMinutes,
                            ReleaseDate=response.ReleaseDate
                        },
                        ActionResponse=new ActionResponse
                        {
                            Message="Data fetched successfully!",
                            Success=true
                        }
                    });
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
