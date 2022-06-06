using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserFile = BNP.Domain.Entities.UserFile;

namespace BNP.DataAccess.Configuration
{
    public class FileConfiguration : IEntityTypeConfiguration<UserFile>
    {
        public void Configure(EntityTypeBuilder<UserFile> builder)
        {
            builder.HasMany(c => c.FileHistory).WithOne(e => e.UserFile);
        }
    }
}
