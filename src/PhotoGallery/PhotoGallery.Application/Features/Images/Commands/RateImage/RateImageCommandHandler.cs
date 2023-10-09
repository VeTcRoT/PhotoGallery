using AutoMapper;
using MediatR;
using PhotoGallery.Domain.Entities;
using PhotoGallery.Domain.Interfaces.Repositories;

namespace PhotoGallery.Application.Features.Images.Commands.RateImage
{
    public class RateImageCommandHandler : IRequestHandler<RateImageCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RateImageCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(RateImageCommand request, CancellationToken cancellationToken)
        {
            var rate = await _unitOfWork.RateRepository
                .GetByImageAndUserIdsAsync(request.ImageId, request.UserId);

            if (rate == null)
            {
                rate = _mapper.Map<Rate>(request);
                await _unitOfWork.RateRepository.CreateAsync(rate);
            }
            else if (rate.IsLike == request.IsLike)
            {
                _unitOfWork.RateRepository.Delete(rate);
            }
            else
            {
                rate.IsLike = request.IsLike;
            }

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
