using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePlayer.Client.Data.Models;

namespace ThePlayer.Context.EntityConfigurations
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
                            Path = $"/testmusic/head above water.mp3",
                            FileName = $"Head Above Water"                            
                        }
                    }
                );

        }

    }
}
