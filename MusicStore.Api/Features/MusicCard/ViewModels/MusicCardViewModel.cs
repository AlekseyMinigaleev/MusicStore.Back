using AutoMapper;
using MusicStore.DB.Models;

namespace MusicStore.Api.Features.MusicCard.ViewModels
{
    public class MusicCardViewModel
    {
        public Guid Id { get; set; }

        public string MusicName { get; set; }

        public string Genre { get; set; }

        public string Author { get; set; }

        public int PerformanceCount { get; set; }
    }

    public class MusicCardViewModelProfiler : Profile
    {
        public MusicCardViewModelProfiler()
        {
            CreateMap<Music, MusicCardViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.MusicName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => $"{src.Author.LastName} {src.Author.FirstName}"))
                .ForMember(dest => dest.PerformanceCount, opt => opt.MapFrom(src => src.Performances.Count()));
        }
    }
}
