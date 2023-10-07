﻿namespace PhotoGallery.Application.Features.Images.Queries.ListPagedImages
{
    public class ListPagedImageDto
    {
        public string FileName { get; set; } = string.Empty;
        public int AlbumId { get; set; }
        public uint Likes { get; set; }
        public uint Dislikes { get; set; }
    }
}