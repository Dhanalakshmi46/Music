using AutoMapper;
using Music.DTOs;
using Music.Repositories;
using Music.Services;

namespace Music.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repo;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MovieDto>> GetAllAsync() =>
            _mapper.Map<IEnumerable<MovieDto>>(await _repo.GetAllAsync());

        public async Task<MovieDto> GetByIdAsync(int id)
        {
            var movie = await _repo.GetByIdAsync(id);
            return movie == null ? null : _mapper.Map<MovieDto>(movie);
        }
    }
}
