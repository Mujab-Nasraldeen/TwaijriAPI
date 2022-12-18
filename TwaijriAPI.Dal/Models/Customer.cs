namespace TwaijriAPI.Dal.Models;
public class Customer
{
	public Customer()
	{
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public List<Invoice> Invoices { get; set; }
}
