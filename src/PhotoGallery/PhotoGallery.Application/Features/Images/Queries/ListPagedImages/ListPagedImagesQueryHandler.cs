using AutoMapper;
using MediatR;
using PhotoGallery.Domain.Helpers;
using PhotoGallery.Domain.Interfaces.Repositories;

namespace PhotoGallery.Application.Features.Images.Queries.ListPagedImages
{
    public class ListPagedImagesQueryHandler : IRequestHandler<ListPagedImagesQuery, PagedList<ListPagedImageDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ListPagedImagesQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedList<ListPagedImageDto>> Handle(ListPagedImagesQuery request, CancellationToken cancellationToken)
        {
            var album = await _unitOfWork.AlbumRepository.GetByIdAsync(request.AlbumId);

            if (album == null)
            {
                throw new ArgumentException(
                    $"Album with id: {request.AlbumId} can't be found.", nameof(request.AlbumId));
            }

            var images = await _unitOfWork.ImageRepository
                .GetImagesByAlbumIdAndPagedAsync(request.AlbumId, request.PageNumber, request.PageSize);

            return _mapper.Map<PagedList<ListPagedImageDto>>(images);
        }
    }
}
