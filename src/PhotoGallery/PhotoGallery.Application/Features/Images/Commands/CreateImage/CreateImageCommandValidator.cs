using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace PhotoGallery.Application.Features.Images.Commands.CreateImage
{
    public class CreateImageCommandValidator : AbstractValidator<CreateImageCommand>
    {
        public CreateImageCommandValidator()
        {
            RuleFor(c => c.Image)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Please upload a file.")
                .Must(BeAValidFile).WithMessage("Invalid file format. Allowed formats: .jpg, .jpeg, .png")
                .Must(BeAValidFileSize).WithMessage("File size exceeds the maximum allowed size 5mb."); ;
        }
        private bool BeAValidFile(IFormFile file)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            var fileExtension = Path.GetExtension(file.FileName);

            return allowedExtensions.Contains(fileExtension.ToLower());
        }
        private bool BeAValidFileSize(IFormFile file)
        {
            var maxFileSizeBytes = 5 * 1024 * 1024;

            return file.Length <= maxFileSizeBytes;
        }
    }
}
