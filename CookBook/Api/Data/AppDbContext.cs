using Microsoft.EntityFrameworkCore;
using Api.modelo;

namespace Api.Data;

public class AppDbContext : DbContext
{
    public DbSet<Receita> Receitas { get; set; }
    public DbSet<Ingrediente> Ingredientes { get; set; }
    public DbSet<IngredienteReceita> IngredienteReceitas { get; set; }
    public DbSet<Etapa> Etapas { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=CookBook.db");
    }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Receita>()
            .HasMany(r => r.Ingredientes)
            .WithMany(i => i.Receitas)
            .UsingEntity<IngredienteReceita>( // Usado para conectar Receita e Igredientes
                j => j.HasOne(ir => ir.Ingrediente)
                    .WithMany(i => i.IngredienteReceitas)
                    .HasForeignKey (ir => ir.IngredienteId),

                j => j.HasOne(ir => ir.Receita)
                    .WithMany(r => r.IngredienteReceitas)
                    .HasForeignKey (ir => ir.ReceitaId),
                
                // Define uma chave primária composta (ReceitaId + IngredienteId),
                // impedindo que o mesmo ingrediente seja cadastrado duas vezes na mesma receita.
                j => j.HasKey(ir => new {ir.ReceitaId, ir.IngredienteId})
            )
            .HasData(
                new Receita {
                    Id = Guid.Parse("2cb2ecf2-0bbe-4098-831c-e0868a85b3fe"),
                    Nome = "Brigadeiro",
                    Descricao = "Doce comum brasileiro"
                }
            );

        modelBuilder.Entity<Ingrediente>()
            .HasData(
                new Ingrediente {
                    Id = Guid.Parse("cf96e0a2-c665-4202-b0b8-200dbfd89d40"),
                    Nome = "Leite Consendado"
                },
                new Ingrediente {
                    Id = Guid.Parse("5ddff53a-e787-4ad9-9883-39b6cb185aff"),
                    Nome = "Chocolate em Pó"
                },
                new Ingrediente {
                    Id = Guid.Parse("84582dba-47a5-4463-9047-999374b05ef9"),
                    Nome = "Margarina sem Sal"
                },
                new Ingrediente {
                    Id = Guid.Parse("59f0d6fc-6fd6-44ad-8333-4890587b07c8"),
                    Nome = "Chocolate Granulado"
                }
            );
    }
}
