using kolokwium2.Models;
using kolokwium2.Models.DTOs;

namespace kolokwium2.Services;

public interface IDbService
{
    Task<ICollection<Owner>> GetAllOwnersData();
    Task<int> AddOwner(AddOwner addOwner);
    Task<bool> ObjectsExist(int[] objects);
    Task AddObjectOwner(int ownerID, int[] objectID);
}