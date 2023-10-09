using FluentValidation;

namespace PhotoGallery.Application.Features.Albums.Commands.CreateAlbum
{
    public class CreateAlbumCommandValidator : AbstractValidator<CreateAlbumCommand>
    {
        public CreateAlbumCommandValidator()
        {
            RuleFor(p => p.Title)
                .NotNull().WithMessage("Title should not be null.")
                .MinimumLength(4).WithMessage("Title length should be more or equal to 4.")
                .MaximumLength(20).WithMessage("Title length should be less or equal to 20.");

            RuleFor(p => p.Description)
                .NotNull().WithMessage("Description should not be null.")
                .MinimumLength(4).WithMessage("Description length should be more or equal to 4.")
                .MaximumLength(50).WithMessage("Description length should be less or equal to 50.");
        }
    }
}
