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
            ); 
    }
}