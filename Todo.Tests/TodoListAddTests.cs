using System;
using Xunit;

namespace Todo.Tests
{
    public class TodoListAddTests
    {
        [Fact]
        public void ItAddsATodoItemToTheTodoList()
        {
            // Arrange
            var todo = new TodoList();
            var item = new Todo { Description = "Test Description"};

            // Act
            todo.AddTodo(item);

            // Assert
            Assert.Single(todo.Items);
        }

        [Fact]
        public void OnNullAnArgumentNullErrorOccurs()
        {
            // Arrange
            var todo = new TodoList();
            Todo item = null;

            // Act
            var exception = Record.Exception(() => todo.AddTodo(item));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullException>(exception);
        }
    }
}