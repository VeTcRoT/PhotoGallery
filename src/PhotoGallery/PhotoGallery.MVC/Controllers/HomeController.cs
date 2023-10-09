using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoGallery.Application.Features.Albums.Commands.CreateAlbum;
using PhotoGallery.Application.Features.Albums.Commands.DeleteAlbum;
using PhotoGallery.Application.Features.Albums.Queries.GetAlbumsByUserId;
using PhotoGallery.Application.Features.Albums.Queries.ListPagedAlbums;
using System;

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
            var albums = await _mediator.Send(query);
            return View(albums);
        }

        public IActionResult CreateAlbum()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAlbum(CreateAlbumCommand command)
        {
            if (!ModelState.IsValid)
                return View(nameof(CreateAlbum), command);

            await _mediator.Send(command);

            return RedirectToAction(nameof(UserAlbums), new { command.UserId });
        }

        public async Task<IActionResult> DeleteAlbum(DeleteAlbumCommand command)
        {
            await DeleteAlbumAsync(command);

            return RedirectToAction(nameof(UserAlbums), new { command.UserId });
        }

        public async Task<IActionResult> DeleteAlbumAdmin(DeleteAlbumCommand command)
        {
            await DeleteAlbumAsync(command);

            return RedirectToAction(nameof(Index));
        }

        private async Task DeleteAlbumAsync(DeleteAlbumCommand command)
        {
            await _mediator.Send(command);
        }
    }
}
