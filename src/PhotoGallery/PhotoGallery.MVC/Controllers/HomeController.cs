using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoGallery.Application.Features.Albums.Commands.CreateAlbum;
using PhotoGallery.Application.Features.Albums.Commands.DeleteAlbum;
using PhotoGallery.Application.Features.Albums.Queries.GetAlbumsByUserId;
using PhotoGallery.Application.Features.Albums.Queries.ListPagedAlbums;
using System.Security.Claims;

namespace PhotoGallery.MVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(ListPagedAlbumsQuery query)
        {
            var albums = await _mediator.Send(query);

            return View(albums);
        }

        public async Task<IActionResult> UserAlbums(GetAlbumsByUserIdQuery query)
        {
            query.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var albums = await _mediator.Send(query);
            return View(albums);
        }

        public async Task<IActionResult> CreateAlbum(CreateAlbumCommand command)
        {
            await _mediator.Send(command);

            return RedirectToAction(nameof(UserAlbums));
        }

        public async Task<IActionResult> DeleteAlbum(DeleteAlbumCommand command)
        {
            await _mediator.Send(command);

            return RedirectToAction(nameof(UserAlbums));
        }
    }
}
