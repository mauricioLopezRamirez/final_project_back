using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using net_api_swagger.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace net_api_swagger.Infrastructure.EntityConfigurations
{

    public class BookEntityConfiguration: IEntityTypeConfiguration<Book>{
      
      public void Configure(EntityTypeBuilder<Book> bookConfiguration)
      {

          bookConfiguration.HasKey(b => b.Id);
          bookConfiguration.Property(b => b.Name)
          .HasMaxLength(20)
          .IsRequired(false);
          
          bookConfiguration.Property<Guid>("AuthorId")
          .UsePropertyAccessMode(PropertyAccessMode.Field)
          .HasColumnName("AuthorId")
          .IsRequired();

          bookConfiguration.HasOne(b => b.Author)
            .WithMany()
            .HasForeignKey("AuthorId");

          bookConfiguration.Property<Guid>("GenreId")
          .UsePropertyAccessMode(PropertyAccessMode.Field)
          .HasColumnName("GenreId")
          .IsRequired();

          bookConfiguration.HasOne(g => g.Genre)
            .WithMany()
            .HasForeignKey("GenreId");

      }



    }

}