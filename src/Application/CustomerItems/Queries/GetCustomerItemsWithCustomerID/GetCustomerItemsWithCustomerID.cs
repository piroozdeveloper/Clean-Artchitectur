using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudWebApi.Application.Common.Interfaces;
using CrudWebApi.Application.Common.Mappings;
using CrudWebApi.Application.Common.Models;
using CrudWebApi.Application.CustomerItems.Queries;

namespace CrudWebApi.Application.CustomerItems.Queries.GetCustomerItemsWithCustomerID;

public record GetCustomerItemsWithCustomerIDQuery : IRequest<PaginatedList<CustomerItemsBriefDto>>
{
    public int CustomerId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;

}

public class GetCustomerItemsWithCustomerIDQueryHandler : IRequestHandler<GetCustomerItemsWithCustomerIDQuery, PaginatedList<CustomerItemsBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCustomerItemsWithCustomerIDQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<CustomerItemsBriefDto>> Handle(GetCustomerItemsWithCustomerIDQuery request, CancellationToken cancellationToken)
    {

        //PageNumber and Pagesize for list by default equal 1
        return await _context.Customers
         .Where(x => x.CustomerId == request.CustomerId)
         .OrderBy(x => x.CustomerId)
         .ProjectTo<CustomerItemsBriefDto>(_mapper.ConfigurationProvider)
         .PaginatedListAsync(1,1);
         //.PaginatedListAsync(request.PageNumber, request.PageSize);

    }
}




