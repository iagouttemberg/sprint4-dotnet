using Database.Models;
using Microsoft.EntityFrameworkCore;
using Repository;
using Database;

public class UsuarioRepositoryTest
{
    private readonly DbContextOptions<OracleDbContext> _options;

    public UsuarioRepositoryTest()
    {
        // Configura um banco de dados em memória para os testes
        _options = new DbContextOptionsBuilder<OracleDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
    }

    [Fact]
    public void Add_ShouldAddEntityToDatabase()
    {
        // Arrange
        using (var context = new OracleDbContext(_options))
        {
            var repository = new Repository<Usuario>(context);
            var usuario = new Usuario { NomeCompleto = "Test User", NomeUsuario = "testuser", Email = "test@example.com", Senha = "password", DataNascimento = new DateTime(1990, 1, 1) };

            // Act
            repository.Add(usuario);
        }

        // Assert
        using (var context = new OracleDbContext(_options))
        {   
            Assert.Equal(1, context.Set<Usuario>().Count()); // Verifica se um usuário foi adicionado
            var addedUser = context.Set<Usuario>().First();
            Assert.Equal("Test User", addedUser.NomeCompleto); // Verifica se os dados estão corretos
            Assert.Equal("testuser", addedUser.NomeUsuario);
            Assert.Equal("test@example.com", addedUser.Email);
        }
    }
}