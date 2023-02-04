using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context.EntityConfiguration
{
    class SongGenreConfig : IEntityTypeConfiguration<SongGenre>
    {

        public void Configure(EntityTypeBuilder<SongGenre> builder)
        {
            builder.HasData(
                    new List<SongGenre>
                    {
                        new SongGenre{
                            Id = 1,
                            Name = "Alternative Rock"
                        }
                    }
                );
        }

    }
}
