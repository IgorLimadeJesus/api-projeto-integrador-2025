using Microsoft.EntityFrameworkCore;
using mrp_api.DTOs.Models;
using mrp_api.Objects.Models;

namespace mrp_api.Data
{
    public class MrpDBContext : DbContext
    {
        public MrpDBContext(DbContextOptions<MrpDBContext> options) : base(options)
        {

        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<MachineModel> Machines { get; set; }
        public DbSet<SetorModel> Setor { get; set; }
        public DbSet<CargoModel> Cargo { get; set; }
        public DbSet<ProdutosModel> Produto { get; set; }
        public DbSet<InsumosModel> Insumos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>()
                .HasOne(u => u.maquina)
                .WithOne(m => m.funcionario)
                .HasForeignKey<UserModel>(u => u.id_Maquina);

            base.OnModelCreating(modelBuilder);
        }
    }
}
