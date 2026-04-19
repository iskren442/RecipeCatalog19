using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecipeCatalog.Data.Models;

namespace RecipeCatalog.Data
{
    /// <summary>
    /// Main database context for the Recipe Catalog application.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Ingredient> Ingredients { get; set; } = null!;
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; } = null!;
        public DbSet<RecipeCategory> RecipeCategories { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<RecipeIngredient>()
                .HasKey(ri => new { ri.RecipeId, ri.IngredientId });

            builder.Entity<RecipeCategory>()
                .HasKey(rc => new { rc.RecipeId, rc.CategoryId });

            builder.Entity<RecipeIngredient>()
                .HasOne(ri => ri.Recipe)
                .WithMany(r => r.RecipeIngredients)
                .HasForeignKey(ri => ri.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<RecipeIngredient>()
                .HasOne(ri => ri.Ingredient)
                .WithMany(i => i.RecipeIngredients)
                .HasForeignKey(ri => ri.IngredientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<RecipeCategory>()
                .HasOne(rc => rc.Recipe)
                .WithMany(r => r.RecipeCategories)
                .HasForeignKey(rc => rc.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<RecipeCategory>()
                .HasOne(rc => rc.Category)
                .WithMany(c => c.RecipeCategories)
                .HasForeignKey(rc => rc.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Comment>()
                .HasOne(c => c.Author)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed начални категории
            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Супи",          Description = "Топли и студени супи" },
                new Category { Id = 2, Name = "Салати",        Description = "Зелени и зеленчукови салати" },
                new Category { Id = 3, Name = "Основни ястия", Description = "Основни ястия за обяд и вечеря" },
                new Category { Id = 4, Name = "Десерти",       Description = "Торти, сладкиши и други десерти" },
                new Category { Id = 5, Name = "Закуски",       Description = "Бързи и лесни закуски" },
                new Category { Id = 6, Name = "Напитки",       Description = "Смутита, сокове и коктейли" }
            );

            // Seed начални съставки
            builder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1,  Name = "Брашно",        Unit = "г" },
                new Ingredient { Id = 2,  Name = "Захар",         Unit = "г" },
                new Ingredient { Id = 3,  Name = "Сол",           Unit = "ч.л." },
                new Ingredient { Id = 4,  Name = "Яйца",          Unit = "бр." },
                new Ingredient { Id = 5,  Name = "Мляко",         Unit = "мл" },
                new Ingredient { Id = 6,  Name = "Масло",         Unit = "г" },
                new Ingredient { Id = 7,  Name = "Олио",          Unit = "мл" },
                new Ingredient { Id = 8,  Name = "Вода",          Unit = "мл" },
                new Ingredient { Id = 9,  Name = "Домати",        Unit = "бр." },
                new Ingredient { Id = 10, Name = "Доматен сос",   Unit = "г" },
                new Ingredient { Id = 11, Name = "Лук",           Unit = "бр." },
                new Ingredient { Id = 12, Name = "Чесън",         Unit = "скилидки" },
                new Ingredient { Id = 13, Name = "Картофи",       Unit = "бр." },
                new Ingredient { Id = 14, Name = "Моркови",       Unit = "бр." },
                new Ingredient { Id = 15, Name = "Пилешко месо",  Unit = "г" },
                new Ingredient { Id = 16, Name = "Телешко месо",  Unit = "г" },
                new Ingredient { Id = 17, Name = "Свинско месо",  Unit = "г" },
                new Ingredient { Id = 18, Name = "Ориз",          Unit = "г" },
                new Ingredient { Id = 19, Name = "Макарони",      Unit = "г" },
                new Ingredient { Id = 20, Name = "Сирене",        Unit = "г" },
                new Ingredient { Id = 21, Name = "Кашкавал",      Unit = "г" },
                new Ingredient { Id = 22, Name = "Кисело мляко",  Unit = "г" },
                new Ingredient { Id = 23, Name = "Черен пипер",   Unit = "ч.л." },
                new Ingredient { Id = 24, Name = "Червен пипер",  Unit = "ч.л." },
                new Ingredient { Id = 25, Name = "Мая",           Unit = "г" },
                new Ingredient { Id = 26, Name = "Бакпулвер",     Unit = "ч.л." },
                new Ingredient { Id = 27, Name = "Ванилия",       Unit = "пак." },
                new Ingredient { Id = 28, Name = "Какао",         Unit = "г" },
                new Ingredient { Id = 29, Name = "Краставици",    Unit = "бр." },
                new Ingredient { Id = 30, Name = "Зелена салата", Unit = "г" }
            );
        }
    }
}
