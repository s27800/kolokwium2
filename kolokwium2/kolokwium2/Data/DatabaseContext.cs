using kolokwium2.Models;
using Microsoft.EntityFrameworkCore;
using Object = kolokwium2.Models.Object;

namespace kolokwium2.Data;

public class DatabaseContext : DbContext
{
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Object> Objects { get; set; }
    public DbSet<ObjectOwner> ObjectOwners { get; set; }
    public DbSet<ObjectType> ObjectTypes { get; set; }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Warehouse>().HasData(new List<Warehouse>
        {
            new Warehouse()
            {
                ID = 1,
                Name = "xyz"
            },
            new Warehouse()
            {
                ID = 2,
                Name = "mno"
            }
        });

        modelBuilder.Entity<ObjectType>().HasData(new List<ObjectType>
        {
            new ObjectType()
            {
                ID = 1,
                Name = "abcd"
            },
            new ObjectType()
            {
                ID = 2,
                Name = "efgh"
            }
        });
        
        modelBuilder.Entity<Owner>().HasData(new List<Owner>
        {
            new Owner()
            {
                ID = 1,
                FirstName = "Andrzej",
                LastName = "Kowalski",
                PhoneNumber = "123456789"
            },
            new Owner()
            {
                ID = 2,
                FirstName = "Jan",
                LastName = "Kowalski",
                PhoneNumber = "987654321"
            } 
        });
        
        modelBuilder.Entity<Object>().HasData(new List<Object>
        {
            new Object()
            {
                ID = 1,
                Width = 1,
                Height = 2,
                WarehouseID = 1,
                ObjectTypeID = 1
            },
            new Object()
            {
                ID = 2,
                Width = 2,
                Height = 3,
                WarehouseID = 2,
                ObjectTypeID = 2
            }
        });
        
        modelBuilder.Entity<ObjectOwner>().HasData(new List<ObjectOwner>
        {
            new ObjectOwner()
            {
                ObjectID = 1,
                OwnerID = 1
            },
            new ObjectOwner()
            {
                ObjectID = 2,
                OwnerID = 2
            }
        });
    }

}