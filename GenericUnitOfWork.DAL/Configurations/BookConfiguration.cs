using GenericUnitOfWork.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GenericUnitOfWork.DAL.Configurations;

internal class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable(nameof(Book));

        builder.HasOne(b => b.Publisher)
            .WithMany(p => p.Books)
            .HasConstraintName("FK_Publisher_Book")
            .HasForeignKey(b => b.PublisherId);

        builder.HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasConstraintName("FK_Author_Book")
            .HasForeignKey(b => b.AuthorId);
    }
}
