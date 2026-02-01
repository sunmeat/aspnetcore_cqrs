using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoListApp.CQRS.Commands;
using ToDoListApp.CQRS.Queries;
using ToDoListApp.Queries;

namespace ToDoListApp.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IMediator _mediator; // медіатор для обробки запитів

        public ToDoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: ToDo
        public async Task<IActionResult> Index()
        {
            var todos = await _mediator.Send(new GetToDosQuery());
            return View(todos);
        }

        // GET: ToDo/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var todo = await _mediator.Send(new GetToDoByIdQuery { Id = id });
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }

        // GET: ToDo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ToDo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateToDoCommand command) // використання команди для створення нового завдання
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }

        // GET: ToDo/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var todo = await _mediator.Send(new GetToDoByIdQuery { Id = id });
            if (todo == null)
            {
                return NotFound();
            }

            var command = new UpdateToDoCommand
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description,
                IsCompleted = todo.IsCompleted
            };

            return View(command);
        }

        // POST: ToDo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateToDoCommand command)
        {
            if (id != command.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(command);
                if (result == null)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }

        // GET: ToDo/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var todo = await _mediator.Send(new GetToDoByIdQuery { Id = id });
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }

        // POST: ToDo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _mediator.Send(new DeleteToDoCommand { Id = id });
            return RedirectToAction(nameof(Index));
        }
    }
}