using AutoMapper;
using PhotoGallery.Application.Features.Images.Commands.DeleteImage;
using PhotoGallery.MVC.Models;

namespace PhotoGallery.MVC.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DeleteImageDto, DeleteImageCommand>();
        }
    }
}
