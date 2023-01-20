﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThePlayer.Shared.Data.Context;

#nullable disable

namespace ThePlayer.Shared.Migrations
{
    [DbContext(typeof(ThePlayerContext))]
    partial class ThePlayerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.13");

            modelBuilder.Entity("ThePlayer.Shared.Data.Models.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArtistId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GenreId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Albums");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArtistId = 1,
                            GenreId = 1,
                            Name = "Head Above Water"
                        });
                });

            modelBuilder.Entity("ThePlayer.Shared.Data.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Avril Lavigne"
                        });
                });

            modelBuilder.Entity("ThePlayer.Shared.Data.Models.AudioFile", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AudioFiles");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Path = "/testmusic/head above water.mp3"
                        });
                });

            modelBuilder.Entity("ThePlayer.Shared.Data.Models.Song", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AlbumId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArtistId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AudioFileId")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("BitRate")
                        .HasColumnType("INTEGER");

                    b.Property<long>("DateAdded")
                        .HasColumnType("INTEGER");

                    b.Property<long>("DateFileCreated")
                        .HasColumnType("INTEGER");

                    b.Property<long>("DateFileModified")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("DateLastPlayed")
                        .HasColumnType("INTEGER");

                    b.Property<long>("DateLastSynced")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("DiscCount")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("DiscNumber")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("Duration")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("FileSize")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GenreId")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("HasLyrics")
                        .HasColumnType("INTEGER");

                    b.Property<string>("IndexingFailureReason")
                        .HasColumnType("TEXT");

                    b.Property<long?>("IndexingSuccess")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("Love")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MimeType")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long?>("NeedsAlbumArtworkIndexing")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("NeedsIndexing")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("PlayCount")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("Rating")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("SampleRate")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("SkipCount")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("TrackCount")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("TrackNumber")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Songs");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            AlbumId = 1,
                            ArtistId = 1,
                            AudioFileId = 1,
                            DateAdded = 0L,
                            DateFileCreated = 0L,
                            DateFileModified = 0L,
                            DateLastSynced = 0L,
                            GenreId = 1,
                            Name = "Head Above Water"
                        });
                });

            modelBuilder.Entity("ThePlayer.Shared.Data.Models.SongGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("SongGenres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Alternative Rock"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}