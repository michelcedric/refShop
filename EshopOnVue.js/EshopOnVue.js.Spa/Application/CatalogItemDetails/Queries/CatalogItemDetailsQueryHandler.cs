using EshopOnVue.js.Core.Interfaces.Repositories;
using MediatR;

namespace EshopOnVue.js.Spa.Application.CatalogItem.Queries
{
    /// <summary>
    /// Handler to respond on the CatalogItemsQueryRequest
    /// </summary>
    public class CatalogItemDetailsQueryHandler : IRequestHandler<CatalogItemDetailsQueryRequest, CatalogItemDetailsDto>
    {
        private readonly ICatalogItemRepository _catalogItemsRepository;

        /// <summary>
        /// Default contructor
        /// </summary>
        /// <param name="catalogItemsRepository"></param>
        public CatalogItemDetailsQueryHandler(ICatalogItemRepository catalogItemsRepository)
        {
            _catalogItemsRepository = catalogItemsRepository;
        }

        /// <summary>
        /// Get specific CatalogItemDto corresponding to the request
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CatalogItemDetailsDto> Handle(CatalogItemDetailsQueryRequest request, CancellationToken cancellationToken)
        {
            var item = await _catalogItemsRepository.GetItemWithSize(request.Id, cancellationToken);
            var data = CatalogItemDetailsDtoConverter.Convert(item);
            return data;
        }
    }
}
