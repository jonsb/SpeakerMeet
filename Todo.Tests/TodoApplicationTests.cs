using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Todo.Tests
{
    public class TodoApplicationTests
    {
        [Fact]
        public void TodoListExists()
        {
            var todo = new TodoList();
            Assert.NotNull(todo);
        }

        [Fact]
        public void CanGetTodos()
        {
            // Arrange
            var todo = new TodoList();

            // Act
            var result = todo.Items;

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<Todo>>(result);
            Assert.Empty(result);
        }

        [Fact]
        public void RemoveTodoExists()
        {
            // Arrange
            var todo = new TodoList();
            var item = new Todo();

            // Act
            todo.RemoveTodo(item);
        }
    }
}
