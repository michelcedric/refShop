using MediatR;
using MinimalApi.Endpoint;

namespace EshopOnVue.js.Spa.Application.CatalogItem.Queries
{

    /// <summary>
    /// Endpoint to get CatalogItem
    /// </summary>
    public class CatalogItemDetailsEndpoint : IEndpoint<IResult, CatalogItemDetailsQueryRequest>
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="mediator"></param>
        public CatalogItemDetailsEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Define routing of the endpoint
        /// </summary>
        /// <param name="app"></param>
        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapGet("api/Catalog/{id}", async (Guid id)
                => await HandleAsync(new CatalogItemDetailsQueryRequest(id)))
                .Produces<CatalogItemDetailsDto>(StatusCodes.Status200OK);                
        }

        /// <summary>
        /// Get all catalog items available
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IResult> HandleAsync(CatalogItemDetailsQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Results.Ok(result);
        }
    }
}
