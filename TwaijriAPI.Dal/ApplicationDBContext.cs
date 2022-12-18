using Microsoft.EntityFrameworkCore;
using TwaijriAPI.Dal.Models;

namespace TwaijriAPI.Dal;
public class ApplicationDBContext : DbContext
{
	public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
	{

	}

	public DbSet<Customer> Customers { get; set; }
	public DbSet<Invoice> Invoices { get; set; }
}
