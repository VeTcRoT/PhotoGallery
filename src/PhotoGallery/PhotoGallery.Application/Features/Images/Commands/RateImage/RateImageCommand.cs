using MediatR;

namespace PhotoGallery.Application.Features.Images.Commands.RateImage
{
    public class RateImageCommand : IRequest
    {
        public int ImageId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public bool IsLike { get; set; }
    }
}
