using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tutorial.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Character> Characters => Set<Character>();

        public DbSet<Skill> Skills => Set<Skill>();

        public DbSet<Article> Articles { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Article>()
            .HasMany(x => x.Tags)
            .WithMany(y => y.Articles)
            .UsingEntity(z => z.ToTable("ArticleTag"));
        }

    }
}