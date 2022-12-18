using TwaijriAPI.Dal.Models;

namespace TwaijriAPI.Dal.Repositories;
public interface IInvoiceRepository : IBaseRepository<Invoice>
{

}

#region Implementation
public class InvoiceRepository : BaseRepository<Invoice>, IInvoiceRepository
{
	public InvoiceRepository(ApplicationDBContext context) : base(context)
    {

	}
}
#endregion
