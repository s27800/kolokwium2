using kolokwium2.Data;
using kolokwium2.Models;
using kolokwium2.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace kolokwium2.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    
    public async Task<ICollection<Owner>> GetAllOwnersData()
    {
        return await _context.Owners
            .Include(e => e.ObjectOwners)
            .ThenInclude(e => e.Object)
            .ThenInclude(e => e.Warehouse)
            .ThenInclude(e => e.Objects)
            .ThenInclude(e => e.ObjectType)
            .ToListAsync();
    }

    public async Task<int> AddOwner(AddOwner addOwner)
    {
        Owner owner = new Owner
        {
            FirstName = addOwner.FirstName,
            LastName = addOwner.LastName,
            PhoneNumber = addOwner.PhoneNumber
        };

        await _context.AddAsync(owner);
        await _context.SaveChangesAsync();

        return owner.ID;
    }

    public async Task<bool> ObjectsExist(int[] objects)
    {
        foreach (var obj in objects)
        {
            if (!_context.Objects.Any(e => e.ID == obj))
                return false;
        }

        return true;
    }

    public async Task AddObjectOwner(int ownerID, int[] objectID)
    {
        foreach (var id in objectID)
        {
            await _context.AddAsync(new ObjectOwner
            {
                ObjectID = id,
                OwnerID = ownerID
            });
        }
        
        await _context.SaveChangesAsync();
    }
    
    
}