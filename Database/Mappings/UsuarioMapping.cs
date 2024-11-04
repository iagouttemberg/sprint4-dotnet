using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("DOTNET_USUARIO");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.NomeCompleto)
                .IsRequired();

            builder.Property(u => u.NomeUsuario)
                .IsRequired();

            builder.Property(u => u.DataNascimento)
                .IsRequired();

            builder.Property(u => u.Email)
                .IsRequired();

            builder.Property(u => u.Senha)
                .IsRequired();
        }
    }
}
