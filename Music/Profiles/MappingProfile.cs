using AutoMapper;
using Music.DTOs;
using Music.Models;

namespace Music.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Song -> SongDto
            CreateMap<Song, SongDto>()
                .ForMember(dest => dest.Movie, opt => opt.MapFrom(src => src.Movie.Name))
                .ForMember(dest => dest.Singer, opt => opt.MapFrom(src => src.Singer.Name));

            // SongDto -> Song
            CreateMap<SongDto, Song>()
                .ForMember(dest => dest.Movie, opt => opt.MapFrom(src => new Movie { Name = src.Movie }))
                .ForMember(dest => dest.Singer, opt => opt.MapFrom(src => new Singer { Name = src.Singer }));

            // Movie and Singer mappings
            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<Singer, SingerDto>().ReverseMap();
        }
    }
}










