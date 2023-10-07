using MediatR;

namespace PhotoGallery.Application.Features.Images.Commands.DeleteImage
{
    public class DeleteImageCommand : IRequest
    {
        public int Id { get; set; }
    }
}
