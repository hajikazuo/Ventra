using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ventra.Domain.Entities;
using Ventra.Domain.Entities.Users;

namespace Ventra.Infrastructure.Context
{
    public class VentraDbContext : IdentityDbContext<User, Role, Guid>
    {
        public VentraDbContext(DbContextOptions<VentraDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }  
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>()
                .HasOne(c => c.User)
                .WithOne(u => u.Client)
                .HasForeignKey<User>(u => u.ClientId);

            //restringe a exclusão de clientes que possuem pedidos
            modelBuilder.Entity<Order>()
                .HasOne<Client>(p => p.Client)
                .WithMany(c => c.Orders)
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            //exclui automaticamento os itens de um pedido quando um pedido é excluído
            modelBuilder.Entity<OrderItem>()
                .HasOne<Order>(ip => ip.Order)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(p => p.Id)
                .OnDelete(DeleteBehavior.Cascade);

            //restringe exclusão de produtos que possuem itens pedidos
            modelBuilder.Entity<OrderItem>()
                .HasOne<Product>(ip => ip.Product)
                .WithMany()
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Photo>()
                .HasOne(p => p.Product)
                .WithMany(p => p.Photos)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
