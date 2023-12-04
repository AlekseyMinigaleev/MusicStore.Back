using AutoMapper;
using MusicStore.DB.Models;

namespace MusicStore.Api.Features.CompactDisks.ViewModels
{
    public class CDViweModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CreationDate { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal WhosalerPrice { get; set; }
        public string ManufacturingCompanyName { get; set; }
        public int CountInStock { get; set; }
        public Guid MusicId { get; set; }
    }

    public class CDViewModelProfiler : Profile
    {
        public CDViewModelProfiler()
        {
            CreateMap<CompactDisk, CDViweModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.MusicId))
                .ForMember(dest => dest.ManufacturingCompanyName, opt => opt.MapFrom(src => src.ManufacturingCompany.Name))
                .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src=> src.CreationDate.ToString("yyyy-MM-dd")));
        }
    }
}