using MediatR;
using ToDoListApp.Models;

namespace ToDoListApp.Queries
{
    public class GetToDoByIdQuery : IRequest<ToDoItem?>
    {
        public int Id { get; set; }
    }
}