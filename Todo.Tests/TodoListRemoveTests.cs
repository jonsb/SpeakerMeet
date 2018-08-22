using Xunit;

namespace Todo.Tests
{
    public class TodoListRemoveTests
    {
        [Fact]
        public void ItRemovedATodoItemFromTheTodoList()
        {
            // Arrange
            var todo = new TodoList();
            var item = new Todo { Description = "Test Description" };

            // Act
            todo.AddTodo(item);
            todo.RemoveTodo(item);

            // Assert
            Assert.Empty(todo.Items);
        }
    }
}