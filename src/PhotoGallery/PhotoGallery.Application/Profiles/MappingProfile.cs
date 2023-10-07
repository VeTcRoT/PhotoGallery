using AutoMapper;
using PhotoGallery.Application.Features.Albums.Commands.CreateAlbum;
using PhotoGallery.Domain.Entities;

namespace PhotoGallery.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Album, CreateAlbumDto>();
            CreateMap<CreateAlbumCommand, Album>();
        }
    }
}
