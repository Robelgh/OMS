using Application.Repository;
using Domain;
using Domain.common;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityTypeConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class OMSDbContext : DbContext
    {
        public readonly DbContextOptions<OMSDbContext> _context;
        private readonly IAccountRepository _account;

        public OMSDbContext(DbContextOptions<OMSDbContext> options) : base(options)
        {
            _context = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            modelBuilder.ApplyConfiguration(new OrderProductETC());
            //modelBuilder.ApplyConfiguration(new ProductProductTypeETC());

            modelBuilder.Entity<Users>().HasData(
            new Users
            {
                ID = Guid.NewGuid(),
                Name = "Robel",
                LastName = "Doe",
                PhoneNumber = "123-456-7890",
                Email = "john.doe@example.com",
                Role = "Admin",
                Passworded = BCrypt.Net.BCrypt.HashPassword("password123"),
                Status = 1,
                CreatedBy="Robel",
            },
            new Users
            {
                ID = Guid.NewGuid(),
                Name = "Jane",
                LastName = "Smith",
                PhoneNumber = "987-654-3210",
                Email = "jane.smith@example.com",
                Role = "User",
                Passworded = BCrypt.Net.BCrypt.HashPassword("password456"), 
                Status = 1,
                CreatedBy = "Robel",
            },
            new Users
            {
                ID = Guid.NewGuid(),
                Name = "Robert",
                LastName = "Brown",
                PhoneNumber = "555-666-7777",
                Email = "robert.brown@example.com",
                Role = "Manager",
                Passworded = BCrypt.Net.BCrypt.HashPassword("password789"),
                Status = 1,
                CreatedBy = "Robel",
            });



            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseDomainEntity).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .Property(nameof(BaseDomainEntity.CreatedDate))
                        .HasDefaultValue(DateTime.UtcNow);

                    modelBuilder.Entity(entityType.ClrType)
                        .Property(nameof(BaseDomainEntity.UpdatedDate))
                        .HasDefaultValue(DateTime.UtcNow);
                }
            }
         


        }


        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entity in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entity.Entity.UpdatedDate = DateTime.Now;
                if (entity.State == EntityState.Added)
                {
                    entity.Entity.CreatedDate = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }


        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductTypes> Products { get; set; }
        //public DbSet<ProductTypes> ProductTypes { get; set; }
        public DbSet<Users> Users { get; set; }

    }


}
