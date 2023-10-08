using AutoMapper;
using MediatR;
using PhotoGallery.Domain.Helpers;
using PhotoGallery.Domain.Interfaces.Repositories;

namespace PhotoGallery.Application.Features.Albums.Queries.ListPagedAlbums
{
    public class ListPagedAlbumsQueryHandler : IRequestHandler<ListPagedAlbumsQuery, PagedList<ListPagedAlbumsDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ListPagedAlbumsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedList<ListPagedAlbumsDto>> Handle(ListPagedAlbumsQuery request, CancellationToken cancellationToken)
        {
            if (request.PageNumber == 0 && request.PageSize == 0)
            {
                request.PageNumber = 1;
                request.PageSize = 5;
            }

            if (request.PageSize > 10)
                request.PageSize = 10;

            var pagedAlbums = await _unitOfWork.AlbumRepository
                .GetPagedAlbumsAsync(request.PageNumber, request.PageSize);

            return _mapper.Map<PagedList<ListPagedAlbumsDto>>(pagedAlbums);
        }
    }
}
