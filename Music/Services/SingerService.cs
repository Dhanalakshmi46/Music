using AutoMapper;
using Music.DTOs;
using Music.Repositories;
using Music.Services;


namespace Music.Services
{
    public class SingerService : ISingerService
    {
        private readonly ISingerRepository _repo;
        private readonly IMapper _mapper;

        public SingerService(ISingerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SingerDto>> GetAllAsync() =>
            _mapper.Map<IEnumerable<SingerDto>>(await _repo.GetAllAsync());

        public async Task<SingerDto> GetByIdAsync(int id)
        {
            var singer = await _repo.GetByIdAsync(id);
            return singer == null ? null : _mapper.Map<SingerDto>(singer);
        }
    }
}
