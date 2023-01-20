﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePlayer.Shared.Data.Models;

namespace ThePlayer.Shared.Context.EntityConfigurations
{
    class ArtistConfig : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.HasData(
                    new List<Artist>
                    {
                        new Artist{
                            Id = 1,
                            Name = "Avril Lavigne"                        
                        }
                    }
                );

        }

    }
}