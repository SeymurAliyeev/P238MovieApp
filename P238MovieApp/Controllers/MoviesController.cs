using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P238MovieApp.Data;
using P238MovieApp.DTOs.MovieDTOs;
using P238MovieApp.Entities;

namespace P238MovieApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public MoviesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var movies = await _appDbContext.Movies.ToListAsync();
            List <MovieGetAllDto> movieDtos = new List<MovieGetAllDto>();

            movieDtos = movies.Select(movie => new MovieGetAllDto()
            {
                Id = movie.Id,
                GenreId = movie.GenreId,
                Name = movie.Name,
                Desc = movie.Desc,
                Price = movie.Price
            }).ToList();

            //foreach (var movie in movies)
            //{
            //    MovieGetAllDto dto = new MovieGetAllDto()
            //    {
            //        Id = movie.Id,
            //        GenreId = movie.GenreId,
            //        Name = movie.Name,
            //        Desc = movie.Desc,
            //        Price = movie.Price
            //    };
            //    movieDtos.Add(dto);
            //}

            return Ok(movieDtos);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var movie = await _appDbContext.Movies.FindAsync(id);

            if (movie is null) return NotFound();

            MovieGetDto movieGetDto = new MovieGetDto()
            {
                Id = movie.Id,
                GenreId = movie.GenreId,
                Name = movie.Name,
                Desc = movie.Desc,
                Price = movie.Price
            };

            return Ok(movieGetDto);
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> Create(MovieCreateDto dto)
        {
            Movie movie = new Movie()
            {
                GenreId = dto.GenreId,
                Name = dto.Name,
                Desc = dto.Desc,
                Price = dto.Price,
                CostPrice = dto.CostPrice,
                IsDeleted = dto.IsDeleted,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            await _appDbContext.Movies.AddAsync(movie);
            await _appDbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
