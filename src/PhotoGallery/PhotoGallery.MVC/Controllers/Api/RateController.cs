using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoGallery.Application.Features.Images.Commands.RateImage;

namespace PhotoGallery.MVC.Controllers.Api
{
    [Route("api/rate")]
    [Authorize]
    [ApiController]
    public class RateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> RateImage(RateImageCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
