using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class GoPokerDbContext : DbContext
    {
        public GoPokerDbContext(DbContextOptions<GoPokerDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // required one-to-one Game and Shoe
            modelBuilder.Entity<Game>()
                .HasOne(e => e.Shoe)
                .WithOne(e => e.Game)
                .HasForeignKey<Shoe>(e => e.GameId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            // optional one-to-many Game and Player
            modelBuilder.Entity<Game>()
                .HasMany(e => e.Players)
                .WithOne(e => e.Game)
                .HasForeignKey(e => e.GameId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            // required one-to-many Player and PlayerCard
            modelBuilder.Entity<Player>()
                .HasMany(e => e.Cards)
                .WithOne(e => e.Player)
                .HasForeignKey(e => e.PlayerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            // required one-to-many Shoe and ShoeCard
            modelBuilder.Entity<Shoe>()
                .HasMany(e => e.Cards)
                .WithOne(e => e.Shoe)
                .HasForeignKey(e => e.ShoeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<PlayerCard> PlayerCards { get; set; }
        public DbSet<ShoeCard> ShoeCards { get; set; }
    }
}
