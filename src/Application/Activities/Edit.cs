using AutoMapper;
using Domain.Entities;
using MediatR;
using Persistence;

namespace Application.Activities;

public class Edit
{
    public class EditCommand : IRequest
    {
        public Activity Activity { get; set; }
    }

    public class EditHandler : IRequestHandler<EditCommand>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public EditHandler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(EditCommand request, CancellationToken cancellationToken)
        {
            var activity = await _context.Activities.FindAsync(request.Activity.Id);
            
            //activity.Title = request.Activity.Title ?? activity.Title;
            _mapper.Map(request.Activity, activity);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}