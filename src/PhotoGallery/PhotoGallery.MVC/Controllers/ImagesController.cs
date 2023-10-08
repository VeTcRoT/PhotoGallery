using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoGallery.Application.Features.Images.Commands.CreateImage;
using PhotoGallery.Application.Features.Images.Commands.DeleteImage;
using PhotoGallery.Application.Features.Images.Queries.ListPagedImages;
using PhotoGallery.MVC.Models;

namespace PhotoGallery.MVC.Controllers
{
    [Authorize]
    public class ImagesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ImagesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(ListPagedImagesQuery query)
        {
            var images = await _mediator.Send(query);

            ViewBag.AlbumId = query.AlbumId;

            return View(images);
        }

        public async Task<IActionResult> UserImages(ListPagedImagesQuery query)
        {
            var images = await _mediator.Send(query);

            ViewBag.AlbumId = query.AlbumId;

            return View(images);
        }

        public IActionResult CreateImage(int albumId)
        {
            ViewBag.AlbumId = albumId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateImage(CreateImageCommand command)
        {
            await _mediator.Send(command);

            return RedirectToAction(nameof(UserImages), new { command.AlbumId });
        }

        public async Task<IActionResult> DeleteImage(DeleteImageDto dto)
        {
            var command = _mapper.Map<DeleteImageCommand>(dto);

            await _mediator.Send(command);

            return RedirectToAction(nameof(UserImages), new { dto.AlbumId });
        }
    }
}
