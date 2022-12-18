namespace TwaijriAPI.Pal.Contracts;
public static class ApiRoute
{
    public static class Customer
    {
        public const string GetAllCustomers = "api/Customer/getAllCustomers";
        public const string AddCustomer = "api/Customer/addCustomer";
    }

    public static class Invoice
    {
        public const string GetAllInvoices = "api/Invoice/getAllInvoices";
        public const string GetPaidInvoices = "api/Invoice/getPaidInvoices";
        public const string GetNotPaidInvoices = "api/Invoice/getNotPaidInvoices";
        public const string GetInvoiceById = "api/Invoice/getInvoiceById";
        public const string AddInvoice = "api/Invoice/addInvoice";
        public const string UpdateInvoice = "api/Invoice/updateInvoice";
        public const string DeleteInvoice = "api/Invoice/deleteInvoice";
    }
}
