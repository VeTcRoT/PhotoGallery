﻿using MediatR;

namespace PhotoGallery.Application.Features.Albums.Commands.CreateAlbum
{
    public class CreateAlbumCommand : IRequest<CreateAlbumDto>
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}