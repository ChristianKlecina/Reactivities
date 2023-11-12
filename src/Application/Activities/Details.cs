using Domain.Entities;
using MediatR;
using Persistence;

namespace Application.Activities;

public class Details
{
    public class DetailsQuery : IRequest<Activity>
    {
        public Guid Id { get; set; }
    }

    public class DetailsHandler : IRequestHandler<DetailsQuery, Activity>
    {
        private readonly DataContext _context;

        public DetailsHandler(DataContext context)
        {
            _context = context;
        }
        public async Task<Activity> Handle(DetailsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Activities.FindAsync(request.Id);
        }
    }
}