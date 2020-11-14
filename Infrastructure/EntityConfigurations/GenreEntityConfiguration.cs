using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using net_api_swagger.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace net_api_swagger.Infrastructure.EntityConfigurations
{

    public class GenreEntityConfiguration: IEntityTypeConfiguration<Genre>{
      
      public void Configure(EntityTypeBuilder<Genre> genreConfiguration)
      {
          genreConfiguration.HasKey(g => g.Id);
          genreConfiguration.Property(g => g.Name)
          .HasMaxLength(20)
          .IsRequired(false);

      }



    }

}