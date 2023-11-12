using MediatR;
using Persistence;

namespace Application.Activities;

public class Delete
{
    public class DeleteCommand : IRequest
    {
        public Guid Id { get; set; }
    }
    
    public class DeleteHandler : IRequestHandler<DeleteCommand>
    {
        private DataContext _context;

        public DeleteHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            var activity = await _context.Activities.FindAsync(request.Id);
            _context.Remove(activity);
            await _context.SaveChangesAsync();
            return Unit.Value;
            
        }
    }
}