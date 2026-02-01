using ToDoListApp.Models;

namespace ToDoListApp.Services
{
    public class ToDoRepository
    {
        private readonly List<ToDoItem> _todos = new();
        private int _nextId = 1;

        public ToDoRepository()
        {
            // Тестові дані
            _todos.Add(new ToDoItem
            {
                Id = _nextId++,
                Title = "Вивчити CQRS",
                Description = "Розібратись з патерном CQRS",
                IsCompleted = false,
                CreatedAt = DateTime.Now
            });
            _todos.Add(new ToDoItem
            {
                Id = _nextId++,
                Title = "Вивчити MediatR",
                Description = "Імплементувати MediatR у проєкт",
                IsCompleted = false,
                CreatedAt = DateTime.Now
            });
        }

        public List<ToDoItem> GetAll() => _todos.ToList();

        public ToDoItem? GetById(int id) => _todos.FirstOrDefault(t => t.Id == id);

        public ToDoItem Create(ToDoItem item)
        {
            item.Id = _nextId++;
            item.CreatedAt = DateTime.Now;
            _todos.Add(item);
            return item;
        }

        public ToDoItem? Update(ToDoItem item)
        {
            var existing = GetById(item.Id);
            if (existing == null) return null;

            existing.Title = item.Title;
            existing.Description = item.Description;
            existing.IsCompleted = item.IsCompleted;
            return existing;
        }

        public bool Delete(int id)
        {
            var item = GetById(id);
            if (item == null) return false;
            return _todos.Remove(item);
        }
    }
}