using AutoMapper;
using PhotoGallery.Application.Features.Albums.Commands.CreateAlbum;
using PhotoGallery.Application.Features.Albums.Queries.GetAlbumsByUserId;
using PhotoGallery.Application.Features.Albums.Queries.ListPagedAlbums;
using PhotoGallery.Application.Features.Images.Commands.CreateImage;
using PhotoGallery.Application.Features.Images.Queries.ListPagedImages;
using PhotoGallery.Domain.Dtos;
using PhotoGallery.Domain.Entities;

namespace PhotoGallery.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateAlbumCommand, Album>();
            CreateMap<Album, AlbumDto>();
            CreateMap<Album, ListPagedAlbumsDto>();
            CreateMap<Album, CreateAlbumDto>();
            CreateMap<Album, GetAlbumsByUserIdDto>();

            CreateMap<CreateImageCommand, Image>();
            CreateMap<Image, CreateImageDto>();
            CreateMap<Image, ListPagedImageDto>()
                .ForMember(i => i.Likes, opt => opt.MapFrom(i => i.Rate.Where(r => r.IsLike).Count()))
                .ForMember(i => i.Dislikes, opt => opt.MapFrom(i => i.Rate.Where(r => !r.IsLike).Count()));
        }
    }
}
