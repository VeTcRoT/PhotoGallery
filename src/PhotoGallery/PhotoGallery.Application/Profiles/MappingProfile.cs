﻿using AutoMapper;
using PhotoGallery.Application.Features.Albums.Commands.CreateAlbum;
using PhotoGallery.Application.Features.Albums.Queries.ListPagedAlbums;
using PhotoGallery.Application.Features.Images.Commands.CreateImage;
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

            CreateMap<CreateImageCommand, Image>();
            CreateMap<Image, CreateImageDto>();
        }
    }
}
