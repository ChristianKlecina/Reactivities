using Domain.Entities;
using MediatR;
using Persistence;

namespace Application.Activities;

public class Create
{
    public class CreateCommand : IRequest
    {
        
        public Activity Activity { get; set; }
        
    }
    public class CreateHandler : IRequestHandler<CreateCommand>
    {
        
        private readonly DataContext _context;

        public CreateHandler(DataContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            _context.Activities.Add(request.Activity);
            await _context.SaveChangesAsync();
            return Unit.Value;
            
        }
    }
    

        
        
    
}