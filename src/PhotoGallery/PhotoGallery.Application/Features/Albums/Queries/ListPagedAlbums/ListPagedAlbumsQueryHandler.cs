using AutoMapper;
using MediatR;
using PhotoGallery.Domain.Dtos;
using PhotoGallery.Domain.Interfaces.Repositories;

namespace PhotoGallery.Application.Features.Albums.Queries.ListPagedAlbums
{
    public class ListPagedAlbumsQueryHandler : IRequestHandler<ListPagedAlbumsQuery, IReadOnlyCollection<ListPagedAlbumsDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ListPagedAlbumsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyCollection<ListPagedAlbumsDto>> Handle(ListPagedAlbumsQuery request, CancellationToken cancellationToken)
        {
            var pagedAlbums = await _unitOfWork.AlbumRepository
                .GetPagedAlbumsAsync(request.PageNumber, request.PageSize);

            return _mapper.Map<IReadOnlyCollection<ListPagedAlbumsDto>>(pagedAlbums);
        }
    }
}
