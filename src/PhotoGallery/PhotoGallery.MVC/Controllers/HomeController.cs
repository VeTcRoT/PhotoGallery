using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhotoGallery.Application.Features.Albums.Queries.ListPagedAlbums;

namespace PhotoGallery.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(ListPagedAlbumsQuery query)
        {
            var albums = await _mediator.Send(query);

            return View(albums);
        }
    }
}
