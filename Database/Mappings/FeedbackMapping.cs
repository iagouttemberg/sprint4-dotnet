using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Database.Models;

namespace Database.Mappings
{
    public class FeedbackMapping : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.ToTable("DOTNET_FEEDBACK");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Avaliacao)
                .IsRequired();

            builder.Property(u => u.Comentario)
                .IsRequired();

            builder.Property(u => u.DataPublicacao)
                .IsRequired();
        }
    }
}
