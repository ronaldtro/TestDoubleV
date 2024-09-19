using NUnit.Framework;
using Moq;
using System.Threading.Tasks; // Importa este namespace para usar System.Threading.Tasks.Task
using tasksSystem.Services;
using tasksSystem.Requests;
using tasksSystem.Models;

[TestFixture]
public class AuthServiceTests
{
    [Test]
    public async Task Authentication_ShouldReturnToken_WhenCredentialsAreValid()
    {
        // Arrange
        var mockDbContext = new Mock<TasksSystemDbContext>();
        var mockJwtService = new Mock<JwtService>();
        var authService = new AuthService(mockDbContext.Object, mockJwtService.Object);
        var request = new AuthRequest { email = "test@example.com", password = "password123" };

        // Act
        var result = await authService.Authentication(request);

        // Assert
        Assert.NotNull(result); // Asegúrate de usar NotNull para verificar que result no es null
        // Agrega más aserciones basadas en el resultado esperado
    }
}
