using Xunit;

namespace Todo.Tests
{
    public class TodoModelTests
    {
        [Fact]
        public void ItHasDescription()
        {
            // Arrange
            var todo = new Todo();

            // Act
            todo.Description = "Test Description";
        }

        [Fact]
        public void OnNullADescriptionRequiredValidationErrorOccurs()
        {
            // Arrange
            var todoList = new TodoList();
            var item = new Todo() {Description = null};

            // Act
            var exception = Record.Exception(() => todoList.AddTodo(item));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<DescriptionRequiredException>(exception);
        }
    }

    public class TodoModelValidateTests
    {
        [Fact]
        public void OnNullADescriptionRequiredValidationErrorOccurs()
        {
            // Arrange
            var todo = new Todo() { Description = null };

            // Act
            var exception = Record.Exception(() => todo.Validate());

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<DescriptionRequiredException>(exception);
        }
    }
}