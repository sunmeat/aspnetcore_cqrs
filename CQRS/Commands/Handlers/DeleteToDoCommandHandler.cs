using MediatR;
using ToDoListApp.Services;

namespace ToDoListApp.CQRS.Commands.Handlers
{
    public class DeleteToDoCommandHandler : IRequestHandler<DeleteToDoCommand, bool>
    {
        private readonly ToDoRepository _repository;

        public DeleteToDoCommandHandler(ToDoRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> Handle(DeleteToDoCommand request, CancellationToken cancellationToken)
        {
            var result = _repository.Delete(request.Id);
            return Task.FromResult(result);
        }
    }
}