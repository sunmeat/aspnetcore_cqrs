using MediatR;
using ToDoListApp.Models;

namespace ToDoListApp.CQRS.Queries
{
    public class GetToDosQuery : IRequest<List<ToDoItem>>
    {
    }
}