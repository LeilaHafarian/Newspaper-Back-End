using DAL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.ModelExtensions
{

    public class ArticleEntityConfig : IEntityTypeConfiguration<Article>
    {
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.Property(article => article.Title)
            .IsRequired()
            .HasMaxLength(75);
    }

       
    }
}
