﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoviesApp.Entities;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MoviesApp.Migrations
{
    [DbContext(typeof(MovieDbContext))]
    partial class MovieDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "uuid-ossp");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MoviesApp.Entities.Actor", b =>
                {
                    b.Property<int>("ActorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ActorId"));

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.HasKey("ActorId");

                    b.ToTable("Actors");

                    b.HasData(
                        new
                        {
                            ActorId = 1,
                            FirstName = "Humphrey",
                            LastName = "Bogart"
                        },
                        new
                        {
                            ActorId = 2,
                            FirstName = "Ingrid",
                            LastName = "Bergman"
                        },
                        new
                        {
                            ActorId = 3,
                            FirstName = "Keanu",
                            LastName = "Reeves"
                        },
                        new
                        {
                            ActorId = 4,
                            FirstName = "Carrie-Anne",
                            LastName = "Moss"
                        },
                        new
                        {
                            ActorId = 5,
                            FirstName = "John",
                            LastName = "Travolta"
                        },
                        new
                        {
                            ActorId = 6,
                            FirstName = "Uma",
                            LastName = "Thurman"
                        });
                });

            modelBuilder.Entity("MoviesApp.Entities.Casting", b =>
                {
                    b.Property<int>("ActorId")
                        .HasColumnType("integer");

                    b.Property<int>("MovieId")
                        .HasColumnType("integer");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.HasKey("ActorId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("Castings");

                    b.HasData(
                        new
                        {
                            ActorId = 1,
                            MovieId = 1,
                            Role = "Rick Blaine"
                        },
                        new
                        {
                            ActorId = 2,
                            MovieId = 1,
                            Role = "Ilsa Lund"
                        },
                        new
                        {
                            ActorId = 3,
                            MovieId = 2,
                            Role = "Neo"
                        },
                        new
                        {
                            ActorId = 4,
                            MovieId = 2,
                            Role = "Trinity"
                        },
                        new
                        {
                            ActorId = 5,
                            MovieId = 3,
                            Role = "Vincet Vega"
                        },
                        new
                        {
                            ActorId = 6,
                            MovieId = 3,
                            Role = "Mia Wallace"
                        });
                });

            modelBuilder.Entity("MoviesApp.Entities.Endpoint", b =>
                {
                    b.Property<int>("EndpointId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EndpointId"));

                    b.Property<int>("EndpointName")
                        .HasColumnType("integer");

                    b.HasKey("EndpointId");

                    b.ToTable("Endpoints");
                });

            modelBuilder.Entity("MoviesApp.Entities.Genre", b =>
                {
                    b.Property<string>("GenreId")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            GenreId = "A",
                            Name = "Action"
                        },
                        new
                        {
                            GenreId = "C",
                            Name = "Comedy"
                        },
                        new
                        {
                            GenreId = "D",
                            Name = "Drama"
                        },
                        new
                        {
                            GenreId = "H",
                            Name = "Horror"
                        },
                        new
                        {
                            GenreId = "M",
                            Name = "Musical"
                        },
                        new
                        {
                            GenreId = "R",
                            Name = "RomCom"
                        },
                        new
                        {
                            GenreId = "S",
                            Name = "SciFi"
                        });
                });

            modelBuilder.Entity("MoviesApp.Entities.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MovieId"));

                    b.Property<string>("GenreId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("Year")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.HasKey("MovieId");

                    b.HasIndex("GenreId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            GenreId = "D",
                            Name = "Casablanca",
                            Year = 1942
                        },
                        new
                        {
                            MovieId = 2,
                            GenreId = "A",
                            Name = "The Matrix",
                            Year = 1998
                        },
                        new
                        {
                            MovieId = 3,
                            GenreId = "C",
                            Name = "Pulp Fiction",
                            Year = 1992
                        });
                });

            modelBuilder.Entity("MoviesApp.Entities.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ReviewId"));

                    b.Property<string>("Comments")
                        .HasColumnType("text");

                    b.Property<int>("MovieId")
                        .HasColumnType("integer");

                    b.Property<int?>("Rating")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.HasKey("ReviewId");

                    b.HasIndex("MovieId");

                    b.ToTable("Review");

                    b.HasData(
                        new
                        {
                            ReviewId = 1,
                            Comments = "A classic!",
                            MovieId = 1,
                            Rating = 5
                        },
                        new
                        {
                            ReviewId = 2,
                            Comments = "They should have gotten together in the end!",
                            MovieId = 1,
                            Rating = 3
                        },
                        new
                        {
                            ReviewId = 3,
                            Comments = "Too slow of a pace",
                            MovieId = 1,
                            Rating = 3
                        },
                        new
                        {
                            ReviewId = 4,
                            Comments = "Based on Descarte's \"brain in a vat\" thought experiment",
                            MovieId = 2,
                            Rating = 4
                        },
                        new
                        {
                            ReviewId = 5,
                            Comments = "Very philosophical",
                            MovieId = 2,
                            Rating = 3
                        },
                        new
                        {
                            ReviewId = 6,
                            Comments = "Very violent but also very funny and clever",
                            MovieId = 3,
                            Rating = 5
                        });
                });

            modelBuilder.Entity("MoviesApp.Entities.Casting", b =>
                {
                    b.HasOne("MoviesApp.Entities.Actor", "Actor")
                        .WithMany("Castings")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesApp.Entities.Movie", "Movie")
                        .WithMany("Castings")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MoviesApp.Entities.Movie", b =>
                {
                    b.HasOne("MoviesApp.Entities.Genre", "Genre")
                        .WithMany("Movies")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("MoviesApp.Entities.Review", b =>
                {
                    b.HasOne("MoviesApp.Entities.Movie", "Movie")
                        .WithMany("Reviews")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MoviesApp.Entities.Actor", b =>
                {
                    b.Navigation("Castings");
                });

            modelBuilder.Entity("MoviesApp.Entities.Genre", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("MoviesApp.Entities.Movie", b =>
                {
                    b.Navigation("Castings");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
