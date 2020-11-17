using System;
using System.Collections.Generic;
using System.Text;
using BurnBuilder.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BurnBuilder.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Card> Card { get; set; }
        public DbSet<CardSet> CardSet { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Deck> Deck { get; set; }
        public DbSet<DeckCard> DeckCard { get; set; }
    }
}
