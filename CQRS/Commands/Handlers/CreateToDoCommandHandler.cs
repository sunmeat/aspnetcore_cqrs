using MediatR;
using ToDoListApp.Models;
using ToDoListApp.Services;

namespace ToDoListApp.CQRS.Commands.Handlers
{
    public class CreateToDoCommandHandler : IRequestHandler<CreateToDoCommand, ToDoItem>
    {
        private readonly ToDoRepository _repository; // залежність від репозиторію, в ідеалі - інтерфейсне посилання

        public CreateToDoCommandHandler(ToDoRepository repository)
        {
            _repository = repository;
        }

        public Task<ToDoItem> Handle(CreateToDoCommand request, CancellationToken cancellationToken)
        {
            var item = new ToDoItem
            {
                Title = request.Title,
                Description = request.Description,
                IsCompleted = false
            };

            var created = _repository.Create(item);
            return Task.FromResult(created);
        }
    }
}