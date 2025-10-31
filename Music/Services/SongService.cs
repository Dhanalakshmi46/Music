using AutoMapper;
using Music.DTOs;
using Music.Models;
using Music.Repositories;
using Music.Services;

namespace Music.Services
{
    public class SongService : ISongService
    {
        private readonly ISongRepository _repo;
        private readonly IMapper _mapper;
        public SongService(ISongRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SongDto>> GetAllAsync() =>
            _mapper.Map<IEnumerable<SongDto>>(await _repo.GetAllAsync());

        public async Task<SongDto> GetByIdAsync(int id)
        {
            var song = await _repo.GetByIdAsync(id);
            return song == null ? null : _mapper.Map<SongDto>(song);
        }

        public async Task<IEnumerable<SongDto>> GetByMovieAsync(string movieName) =>
            _mapper.Map<IEnumerable<SongDto>>(await _repo.GetByMovieAsync(movieName));

        public async Task<IEnumerable<SongDto>> GetBySingerAsync(string singerName) =>
            _mapper.Map<IEnumerable<SongDto>>(await _repo.GetBySingerAsync(singerName));

        public async Task<IEnumerable<SongDto>> GetByYearAsync(int year) =>
            _mapper.Map<IEnumerable<SongDto>>(await _repo.GetByYearAsync(year));

        public async Task<IEnumerable<SongDto>> SearchAsync(string keyword) =>
            _mapper.Map<IEnumerable<SongDto>>(await _repo.SearchAsync(keyword));

        public async Task<SongDto> CreateAsync(SongDto dto)
        {
            var song = _mapper.Map<Song>(dto);
            await _repo.AddAsync(song);
            return _mapper.Map<SongDto>(song);
        }

        public async Task<bool> UpdateAsync(int id, SongDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return false;
            _mapper.Map(dto, existing);
            await _repo.UpdateAsync(existing);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var song = await _repo.GetByIdAsync(id);
            if (song == null || song.IsDeleted == "true") 
                return false;

            song.IsDeleted = "true";   
            await _repo.UpdateAsync(song); 
            return true;
        }
    }
}
