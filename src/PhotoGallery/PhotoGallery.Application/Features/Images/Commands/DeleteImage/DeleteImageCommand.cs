using MediatR;

namespace PhotoGallery.Application.Features.Images.Commands.DeleteImage
{
    public class DeleteImageCommand : IRequest
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}
