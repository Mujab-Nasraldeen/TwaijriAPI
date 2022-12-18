using TwaijriAPI.Dal.Models;

namespace TwaijriAPI.Dal.Repositories;
public interface ICustomerRepository : IBaseRepository<Customer>
{

}

#region Implementation
public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
{
	public CustomerRepository(ApplicationDBContext context) : base(context)
    {

	}
}
#endregion
