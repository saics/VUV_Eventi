using AutoMapper;
using PIS.DAL.DataModel;
using PIS.Model;
using System;

namespace PIS.Repository.Automapper
{
    public class RepositoryMappingProfile : Profile
    {
        public RepositoryMappingProfile()
        {
            //Korisnici
            CreateMap<Korisnici, KorisniciDomain>();
            CreateMap<KorisniciDomain, Korisnici>();

            //Eventi
            CreateMap<Eventi, EventiDomain>()
                .ForMember(dest => dest.VrijemePocetka, opt => opt.MapFrom(src => src.VrijemePocetka.HasValue ? src.VrijemePocetka.Value.ToString(@"hh\:mm\:ss") : null))
                .ForMember(dest => dest.VrijemeZavrsetka, opt => opt.MapFrom(src => src.VrijemeZavrsetka.HasValue ? src.VrijemeZavrsetka.Value.ToString(@"hh\:mm\:ss") : null))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl));
            CreateMap<EventiDomain, Eventi>()
                .ForMember(dest => dest.VrijemePocetka, opt => opt.MapFrom(src => TimeSpan.Parse(src.VrijemePocetka)))
                .ForMember(dest => dest.VrijemeZavrsetka, opt => opt.MapFrom(src => TimeSpan.Parse(src.VrijemeZavrsetka)))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl));

            //Aktivnosti
            CreateMap<Aktivnosti, AktivnostiDomain>()
                .ForMember(dest => dest.VrijemePocetka, opt => opt.MapFrom(src => src.VrijemePocetka.HasValue ? src.VrijemePocetka.Value.ToString(@"hh\:mm\:ss") : null))
                .ForMember(dest => dest.VrijemeZavrsetka, opt => opt.MapFrom(src => src.VrijemeZavrsetka.HasValue ? src.VrijemeZavrsetka.Value.ToString(@"hh\:mm\:ss") : null))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl));
            CreateMap<AktivnostiDomain, Aktivnosti>()
                .ForMember(dest => dest.VrijemePocetka, opt => opt.MapFrom(src => TimeSpan.Parse(src.VrijemePocetka)))
                .ForMember(dest => dest.VrijemeZavrsetka, opt => opt.MapFrom(src => TimeSpan.Parse(src.VrijemeZavrsetka)))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl));

            //KorisniciAktivnosti
            CreateMap<KorisniciAktivnosti, KorisniciAktivnostiDomain>();
            CreateMap<KorisniciAktivnostiDomain, KorisniciAktivnosti>();

            //Status
            CreateMap<Status, StatusDomain>();
            CreateMap<StatusDomain, Status>();

            //Uloge
            CreateMap<Uloge, UlogeDomain>();
            CreateMap<UlogeDomain, Uloge>();
        }

        private static TimeSpan? ParseTimeSpanSafe(string time)
        {
            if (TimeSpan.TryParse(time, out TimeSpan result))
            {
                return result;
            }
            return null; // Or throw an appropriate exception if necessary
        }
    }
}
