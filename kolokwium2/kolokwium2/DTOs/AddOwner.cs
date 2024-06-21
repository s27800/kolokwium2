namespace kolokwium2.Models.DTOs;

public class AddOwner
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public int[] OwnerObjects { get; set; }
}