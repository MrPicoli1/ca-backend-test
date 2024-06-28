using BackendTest.API.Shered;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace BackendTest.API.Domain.Entities
{
    public class BillingLines : Entity
    {
        public BillingLines(string invoiceNumber,
            DateTime date, DateTime dueDate,
            decimal totalAmount, string currency)
        {
            InvoiceNumber = invoiceNumber;
            Date = date;
            DueDate = dueDate;
            TotalAmount = totalAmount;
            Currency = currency;
        }
        public Guid Id { get; set; }
        public string InvoiceNumber { get; set; }
        public User? Customer { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public decimal TotalAmount { get; set; }

        public string Currency { get; set; }
        public List<Product>? Lines { get; set; }



    }
}
