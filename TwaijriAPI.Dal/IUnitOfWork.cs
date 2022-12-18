using TwaijriAPI.Dal.Repositories;

namespace TwaijriAPI.Dal;
public interface IUnitOfWork
{
    #region Invoice Section
    ICustomerRepository Customer { get; }
    IInvoiceRepository Invoice { get; }
    #endregion

    #region Commit
    Task Commit();
    #endregion
}
