using MediatR;
using ToDoListApp.Models;

namespace ToDoListApp.CQRS.Commands
{
    public class CreateToDoCommand : IRequest<ToDoItem>
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}