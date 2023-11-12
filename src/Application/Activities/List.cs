using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities;

public class List
{
    public class ListQuery : IRequest<List<Activity>> { }
    
    public class ListHandler : IRequestHandler<ListQuery, List<Activity>>
    {
        private readonly DataContext _context;

        public ListHandler(DataContext context)
        {
            _context = context;
        }
        
        public async Task<List<Activity>> Handle(ListQuery request, CancellationToken cancellationToken)
        {
            return await _context.Activities.ToListAsync();
        }
    }
}