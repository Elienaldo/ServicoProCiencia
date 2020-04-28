using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.EntityFrameworkCore;
using ProCiencia.Models;

public class ProCienciaContext : DbContext
    {
        public ProCienciaContext (DbContextOptions<ProCienciaContext> options)
            : base(options)
        {
        }

        public DbSet<Instituicao> Instituicao { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<SubArea> SubArea { get; set; }
        public DbSet<Projeto> Projeto { get; set; }

        // Reescrevendo o método para poder efetuar algumas configurações relacionadas a criação das tabelas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Remove a pluralização automática do nome das tabelas
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Ignore<PluralizingTableNameConvention>();

            // Remove a deleção em cascata
            modelBuilder.Ignore<OneToManyCascadeDeleteConvention>();
            modelBuilder.Ignore<ManyToManyCascadeDeleteConvention>();

            // Determina que o tipo das colunas string será varchar
            //modelBuilder.Properties<string>().Configure(c => c.HasColumnType("varchar"));
            
            // Determina o tamanho máximo que as colunas do tipo string terão
            //modelBuilder.Properties<string>().Configure(c => c.HasMaxLength(100));

            // Informando para o contexto seguir as configurações existentes nesta classe
            //modelBuilder.Configurations.Add(new ProjetoConfiguration());
        }
    }
