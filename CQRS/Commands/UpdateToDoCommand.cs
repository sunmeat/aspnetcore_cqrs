using MediatR;
using ToDoListApp.Models;

namespace ToDoListApp.CQRS.Commands
{
    public class UpdateToDoCommand : IRequest<ToDoItem?>
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }
}