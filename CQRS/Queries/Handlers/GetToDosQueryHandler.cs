using MediatR;
using ToDoListApp.CQRS.Queries;
using ToDoListApp.Models;
using ToDoListApp.Services;

namespace ToDoListApp.Queries.Handlers
{
    public class GetToDosQueryHandler : IRequestHandler<GetToDosQuery, List<ToDoItem>>
    {
        private readonly ToDoRepository _repository;

        public GetToDosQueryHandler(ToDoRepository repository)
        {
            _repository = repository;
        }

        public Task<List<ToDoItem>> Handle(GetToDosQuery request, CancellationToken cancellationToken)
        {
            var items = _repository.GetAll();
            return Task.FromResult(items);
        }
    }
}