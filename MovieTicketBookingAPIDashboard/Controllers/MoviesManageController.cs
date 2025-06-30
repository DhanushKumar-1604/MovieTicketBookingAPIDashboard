using APIDashboard.Application.Interfaces;
using APIDashboard.Domain;
using APIDashboard.Domain.Dto_Model;
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

        /// <summary>
        ///   Add a new movie to the database.
        /// </summary>
        /// <param name="moviesModel"></param>
        /// <returns> return the action response once added return success or false </returns>
        [HttpPost("AddMovies")]
        public async Task<ActionResult<ActionResponse>> AddMovies(AddMoviesModelDto addMoviesDtoModel)
        {
            try
            {
                MoviesModel moviesModel = new MoviesModel
                {
                   Title=addMoviesDtoModel.Title,
                   Genre=addMoviesDtoModel.Genre,
                   DurationMinutes=addMoviesDtoModel.DurationMinutes,
                   ReleaseDate=addMoviesDtoModel.ReleaseDate,

                };
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

        /// <summary>
        ///    Get all movies from the database.
        /// </summary>
        /// <returns> returns the Movies list in GetAllMovieResponse </returns>
        [HttpGet("GetAllMovies")]
        public async Task<ActionResult<GetAllMoviesResponse>?> GetAllMoviesList() {
            try
            {
                var result = await _moviesManageService.GetAllMoviesList();

                if (result != null)
                {
                    return Ok(new GetAllMoviesResponse
                    {
                        MoviesList=new GetAllMoviesList
                        {
                            getAllMovies=result.Select(result=> new GetMoviesModelDto
                            {
                                MovieId=result.MovieId,
                                Title=result.Title,
                                ReleaseDate=result.ReleaseDate
                            }).ToList()
                        },
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

        /// <summary>
        ///    Get a movie by its ID from the database.
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns> return the movie detail given id and returns to the GetMovieByIdResponse </returns>
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
                       MovieDetails=new GetMoviesModelDto
                       {
                           MovieId=response.MovieId,
                           Title=response.Title,
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
