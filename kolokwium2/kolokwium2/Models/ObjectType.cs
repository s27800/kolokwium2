using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolokwium2.Models;

[Table("Object_Type")]
public class ObjectType
{
    [Key]
    public int ID { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }

    public ICollection<Object> Objects { get; set; } = new HashSet<Object>();
}