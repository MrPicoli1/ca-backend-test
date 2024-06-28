using BackendTest.API.Models;
using BackendTest.API.Shered;

namespace BackendTest.API.Domain.Entities
{
    public class Billing 
    {
        public Billing(DateTime createdAt, string name,
            string invoiceAmount, string currencyCode,
            long invoiceDate, string id)
        {
            CreatedAt = createdAt;
            Name = name;
            InvoiceAmount = invoiceAmount;
            CurrencyCode = currencyCode;
            InvoiceDate = invoiceDate;
            Id = id;
        }

        public BillingLines Details { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string InvoiceAmount { get; set; }
        public string CurrencyCode { get; set; }
        public long InvoiceDate { get; set; }
        public string Id { get; set; }
    }
}
