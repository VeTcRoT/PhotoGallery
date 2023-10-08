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

        public ImagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(ListPagedImagesQuery query)
        {
            var images = await _mediator.Send(query);

            ViewBag.AlbumId = query.AlbumId;

            return View(images);
        }
    }
}
