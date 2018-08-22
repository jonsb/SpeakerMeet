using System;
using System.Collections.Generic;

namespace Todo
{
    public class TodoList
    {
        private readonly List<Todo> _items = new List<Todo>();

        public IEnumerable<Todo> Items => _items;

        public void AddTodo(Todo item)
        {
            if (item == null)
                throw new ArgumentNullException();

            item.Validate();

            _items.Add(item);
        }

        public void RemoveTodo(Todo item)
        {
            _items.Remove(item);
        }
    }
}
//