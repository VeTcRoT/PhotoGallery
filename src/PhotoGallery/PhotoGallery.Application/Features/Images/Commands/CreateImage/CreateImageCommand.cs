using MediatR;
using Microsoft.AspNetCore.Http;

namespace PhotoGallery.Application.Features.Images.Commands.CreateImage
{
    public class CreateImageCommand : IRequest<CreateImageDto>
    {
        public IFormFile Image { get; set; } = null!;
        public int AlbumId { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}
