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
    class AlbumConfig : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.HasData(
                    new List<Album>
                    {
                        new Album{
                            Id = 1,
                            Name = "Head Above Water",
                            ArtistId = 1,
                            GenreId = 1
                        }
                    }
                );

        }

    }
}
