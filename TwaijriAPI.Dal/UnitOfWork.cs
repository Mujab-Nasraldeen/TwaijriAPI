using TwaijriAPI.Dal.Repositories;

namespace TwaijriAPI.Dal;
public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDBContext _dbcontext;

    private ICustomerRepository _customer;
    private IInvoiceRepository _invoice;

    public UnitOfWork(ApplicationDBContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    #region Invoice Section
    public ICustomerRepository Customer
    {
        get
        {
            _customer ??= new CustomerRepository(_dbcontext);
            return _customer;
        }
    }

    public IInvoiceRepository Invoice
    {
        get
        {
            _invoice ??= new InvoiceRepository(_dbcontext);
            return _invoice;
        }
    }
    #endregion

    #region Commit
    public async Task Commit()
    {
        await _dbcontext.SaveChangesAsync();
    }
    #endregion
}
