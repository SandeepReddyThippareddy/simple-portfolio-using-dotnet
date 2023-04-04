using AutoMapper;
using SandeepThippareddy.Dtos;
using SandeepThippareddy.Models;

namespace SmartStand.Profiles
{
    public class SandeepThippareddyProfile : Profile
    {
        public SandeepThippareddyProfile()
        {
            CreateMap<ContactDto, ContactModel>();
            CreateMap<ContactModel, ContactDto>();

            CreateMap<DownloaderDto, DownloaderModel>();
            CreateMap<DownloaderModel, DownloaderDto>();
        }
    }
}
