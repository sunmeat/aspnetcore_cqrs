using MediatR;

namespace ToDoListApp.CQRS.Commands
{
    public class DeleteToDoCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}