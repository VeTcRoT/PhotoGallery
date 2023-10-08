using AutoMapper;
using MediatR;
using PhotoGallery.Domain.Interfaces.Repositories;

namespace PhotoGallery.Application.Features.Albums.Queries.GetAlbumsByUserId
{
    public class GetAlbumsByUserIdQueryHandler : IRequestHandler<GetAlbumsByUserIdQuery, IReadOnlyCollection<GetAlbumsByUserIdDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetAlbumsByUserIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyCollection<GetAlbumsByUserIdDto>> Handle(GetAlbumsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var albums = await _unitOfWork.AlbumRepository.GetPagedAlbumsByUserIdAsync(request.UserId, request.PageNumber, request.PageSize);

            return _mapper.Map<IReadOnlyCollection<GetAlbumsByUserIdDto>>(albums);
        }
    }
}
