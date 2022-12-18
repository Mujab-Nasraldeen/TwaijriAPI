using System.ComponentModel.DataAnnotations.Schema;
using TwaijriAPI.Dal.Enums;

namespace TwaijriAPI.Dal.Models;
public class Invoice
{
    public Invoice()
    {
        Id = Guid.NewGuid();
        InvoiceDate = DateTime.Now;
    }

    public Guid Id { get; set; }
    public DateTime InvoiceDate { get; set; }
    public decimal Value { get; set; }
    public InvoiceState State { get; set; }
    public Guid CustomerId { get; set; }
    [ForeignKey("CustomerId")]
    public Customer Customer { get; set; }
}
