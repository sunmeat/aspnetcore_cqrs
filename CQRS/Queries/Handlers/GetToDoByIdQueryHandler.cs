using MediatR;
using ToDoListApp.Models;
using ToDoListApp.Services;

namespace ToDoListApp.Queries.Handlers
{
    public class GetToDoByIdQueryHandler : IRequestHandler<GetToDoByIdQuery, ToDoItem?>
    {
        private readonly ToDoRepository _repository;

        public GetToDoByIdQueryHandler(ToDoRepository repository)
        {
            _repository = repository;
        }

        public Task<ToDoItem?> Handle(GetToDoByIdQuery request, CancellationToken cancellationToken)
        {
            var item = _repository.GetById(request.Id);
            return Task.FromResult(item);
        }
    }
}