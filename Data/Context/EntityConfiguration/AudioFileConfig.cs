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
    class AudioFileConfig : IEntityTypeConfiguration<AudioFile>
    {
        public void Configure(EntityTypeBuilder<AudioFile> builder)
        {
            builder.HasData(
                    new List<AudioFile>
                    {
                        new AudioFile{
                            Id = 1,
                            Path = $"/testmusic/head above water.mp3"
                        }
                    }
                );

        }

    }
}
