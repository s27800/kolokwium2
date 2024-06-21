using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace kolokwium2.Models;

public class Object
{
    [Key]
    public int ID { get; set; }
    [DataType("decimal")]
    [Precision(4, 2)]    
    public decimal Width { get; set; }
    [DataType("decimal")]
    [Precision(4, 2)]
    public decimal Height { get; set; }
    
    public int WarehouseID { get; set; }
    public int ObjectTypeID { get; set; }
    
    [ForeignKey(nameof(WarehouseID))] 
    public Warehouse Warehouse { get; set; } = null!;
    
    [ForeignKey(nameof(ObjectTypeID))] 
    public ObjectType ObjectType { get; set; } = null!;

    public ICollection<ObjectOwner> ObjectOwners { get; set; } = new HashSet<ObjectOwner>();
}