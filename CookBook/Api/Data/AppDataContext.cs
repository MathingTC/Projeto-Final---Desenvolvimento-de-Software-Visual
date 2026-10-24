using Microsoft.EntityFrameworkCore;

public class AppDataContext : DbContext
{
    public required DbSet<Receita> Receitas { get; set; }
    public required DbSet<Ingrediente> Ingredientes { get; set; }
    public required DbSet<IngredienteReceita> IngredienteReceitas { get; set; }
    public required DbSet<Etapa> Etapas { get; set; }
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
            .UsingEntity<IngredienteReceita>();

        modelBuilder.Entity<Receita>()
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
                    Nome = "Leite Condensado"
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

        modelBuilder.Entity<Etapa>()
            .HasData(
                new Etapa {
                    Id = Guid.Parse("7e3f9a1c-5b24-4d68-9c07-a2f1d84b6e35"),
                    Descricao = "Adicione o leite condensado, a margarina e o chocolate em pó numa panela funda",
                    Ordem = 1,
                    ReceitaId = Guid.Parse("2cb2ecf2-0bbe-4098-831c-e0868a85b3fe")
                },
                new Etapa {
                    Id = Guid.Parse("c8a05d72-1f9e-4b3a-8e46-0d7b93f2a1c8"),
                    Descricao = "Cozinhe em fogo médio até o brigadeiro se soltar do fundo da panela",
                    Ordem = 2,
                    ReceitaId = Guid.Parse("2cb2ecf2-0bbe-4098-831c-e0868a85b3fe")
                },
                new Etapa {
                    Id = Guid.Parse("3b6d1e94-a7c2-4f05-b18d-e5c90a47d263"),
                    Descricao = "Resfrie e prepare no formato de pequenas bolas, cobrindo com o chocolate granulado",
                    Ordem = 3,
                    ReceitaId = Guid.Parse("2cb2ecf2-0bbe-4098-831c-e0868a85b3fe")
                }
            );

        modelBuilder.Entity<IngredienteReceita>()
            .HasData(
                    new IngredienteReceita {
                        IngredienteId = Guid.Parse("cf96e0a2-c665-4202-b0b8-200dbfd89d40"),
                        ReceitaId = Guid.Parse("2cb2ecf2-0bbe-4098-831c-e0868a85b3fe"),
                        Quantidade = 1,
                        UnidadeMedida = "lata"
                    },
                    new IngredienteReceita {
                        IngredienteId = Guid.Parse("5ddff53a-e787-4ad9-9883-39b6cb185aff"),
                        ReceitaId = Guid.Parse("2cb2ecf2-0bbe-4098-831c-e0868a85b3fe"),
                        Quantidade = 4,
                        UnidadeMedida = "colheres de sopa"
                    },
                    new IngredienteReceita {
                        IngredienteId = Guid.Parse("84582dba-47a5-4463-9047-999374b05ef9"),
                        ReceitaId = Guid.Parse("2cb2ecf2-0bbe-4098-831c-e0868a85b3fe"),
                        Quantidade = 1,
                        UnidadeMedida = "colher de sopa"
                    },
                    new IngredienteReceita {
                        IngredienteId = Guid.Parse("59f0d6fc-6fd6-44ad-8333-4890587b07c8"),
                        ReceitaId = Guid.Parse("2cb2ecf2-0bbe-4098-831c-e0868a85b3fe"),
                    }
            );
    }
}
