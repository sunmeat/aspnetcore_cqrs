using MediatR;
using ToDoListApp.Models;
using ToDoListApp.Services;

namespace ToDoListApp.CQRS.Commands.Handlers
{
    public class UpdateToDoCommandHandler : IRequestHandler<UpdateToDoCommand, ToDoItem?>
    {
        private readonly ToDoRepository _repository;

        public UpdateToDoCommandHandler(ToDoRepository repository)
        {
            _repository = repository;
        }

        public Task<ToDoItem?> Handle(UpdateToDoCommand request, CancellationToken cancellationToken)
        {
            var item = new ToDoItem
            {
                Id = request.Id,
                Title = request.Title,
                Description = request.Description,
                IsCompleted = request.IsCompleted
            };

            var updated = _repository.Update(item);
            return Task.FromResult(updated);
        }
    }
}