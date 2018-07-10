using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyWay3.Models
{
    public partial class MywayDbContext : DbContext
    {
        public MywayDbContext()
        {
        }

        public MywayDbContext(DbContextOptions<MywayDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Resumo> Resumo { get; set; }
        public virtual DbSet<Slas> Slas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resumo>(entity =>
            {
                entity.HasKey(e => e.IdResumo);

                entity.ToTable("resumo");

                entity.HasIndex(e => e.DataResumo)
                    .HasName("IX_resumo")
                    .IsUnique();

                entity.Property(e => e.IdResumo).HasColumnName("id_resumo");

                entity.Property(e => e.AtrasosAceites).HasColumnName("atrasos_aceites");

                entity.Property(e => e.AtrasosImputados).HasColumnName("atrasos_imputados");

                entity.Property(e => e.DataResumo)
                    .HasColumnName("data_resumo")
                    .HasColumnType("date");

                entity.Property(e => e.EquipamentosInopAmbulift).HasColumnName("equipamentos_inop_ambulift");

                entity.Property(e => e.EquipamentosInopVta).HasColumnName("equipamentos_inop_vta");

                entity.Property(e => e.EquipamentosOkAmbulift).HasColumnName("equipamentos_ok_ambulift");

                entity.Property(e => e.EquipamentosOkVta).HasColumnName("equipamentos_ok_vta");

                entity.Property(e => e.IncumprimentosSla).HasColumnName("incumprimentos_sla");

                entity.Property(e => e.StaffDuty).HasColumnName("staff_duty");

                entity.Property(e => e.StaffEscala).HasColumnName("staff_escala");

                entity.Property(e => e.TotalAssistencias).HasColumnName("total_assistencias");

                entity.Property(e => e.TotalVoos).HasColumnName("total_voos");
            });

            modelBuilder.Entity<Slas>(entity =>
            {
                entity.HasKey(e => e.IdSla);

                entity.ToTable("SLAs");

                entity.HasIndex(e => e.DataSla)
                    .HasName("IX_SLAs")
                    .IsUnique();

                entity.Property(e => e.IdSla).HasColumnName("id_sla");

                entity.Property(e => e.C90Maior15MenorIgual20).HasColumnName("c90_maior_15_menor_igual_20");

                entity.Property(e => e.C90Maior20MenorIgual30).HasColumnName("c90_maior_20_menor_igual_30");

                entity.Property(e => e.C90Maior30).HasColumnName("c90_maior_30");

                entity.Property(e => e.C90MenorIgual15).HasColumnName("c90_menor_igual_15");

                entity.Property(e => e.CcMaior10MenorIgual20).HasColumnName("cc_maior_10_menor_igual_20");

                entity.Property(e => e.CcMaior20).HasColumnName("cc_maior_20");

                entity.Property(e => e.CcMaior5MenorIgual10).HasColumnName("cc_maior_5_menor_igual_10");

                entity.Property(e => e.CcMenorIgual5).HasColumnName("cc_menor_igual_5");

                entity.Property(e => e.CsMaior25MenorIgual35).HasColumnName("cs_maior_25_menor_igual_35");

                entity.Property(e => e.CsMaior35MenorIgual45).HasColumnName("cs_maior_35_menor_igual_45");

                entity.Property(e => e.CsMaior45).HasColumnName("cs_maior_45");

                entity.Property(e => e.CsMenorIgual25).HasColumnName("cs_menor_igual_25");

                entity.Property(e => e.DataSla)
                    .HasColumnName("data_sla")
                    .HasColumnType("date");

                entity.Property(e => e.PcMaior10MenorIgual20).HasColumnName("pc_maior_10_menor_igual_20");

                entity.Property(e => e.PcMaior20MenorIgual30).HasColumnName("pc_maior_20_menor_igual_30");

                entity.Property(e => e.PcMaior30).HasColumnName("pc_maior_30");

                entity.Property(e => e.PcMenorIgual10).HasColumnName("pc_menor_igual_10");

                entity.Property(e => e.PsMaior25MenorIgual35).HasColumnName("ps_maior_25_menor_igual_35");

                entity.Property(e => e.PsMaior35MenorIgual45).HasColumnName("ps_maior_35_menor_igual_45");

                entity.Property(e => e.PsMaior45).HasColumnName("ps_maior_45");

                entity.Property(e => e.PsMenorIgual25).HasColumnName("ps_menor_igual_25");
            });
        }
    }
}
