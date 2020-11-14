using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using net_api_swagger.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace net_api_swagger.Infrastructure.EntityConfigurations
{

    public class AuthorEntityConfiguration: IEntityTypeConfiguration<Author>{
      
      public void Configure(EntityTypeBuilder<Author> authorConfiguration)
      {
          authorConfiguration.HasKey(a => a.Id);
          authorConfiguration.Property(a => a.Name)
          .HasMaxLength(20)
          .IsRequired();

      }

    }

}