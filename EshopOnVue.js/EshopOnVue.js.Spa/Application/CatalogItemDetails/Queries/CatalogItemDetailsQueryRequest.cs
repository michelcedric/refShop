using MediatR;

namespace EshopOnVue.js.Spa.Application.CatalogItem.Queries
{
    public class CatalogItemDetailsQueryRequest : IRequest<CatalogItemDetailsDto>
    {
        public Guid Id { get; set; }
        public CatalogItemDetailsQueryRequest(Guid id)
        {
            Id = id;
        }
    }
}
