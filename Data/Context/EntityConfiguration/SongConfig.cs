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
    class SongConfig : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.HasData(
                    new List<Song>
                    {
                        new Song{
                            Id = 1,
                            Name = $"Head Above Water",
                            ArtistId = 1,
                            AlbumId = 1,
                            GenreId = 1,
                            AudioFileId = 1
                        }
                    }
                );

        }

    }
}
