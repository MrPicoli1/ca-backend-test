using BackendTest.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace BackendTest.API.Models
{
    public class BillingLinesModel
    {
        [JsonPropertyName("invoice_number")]
        public string? InvoiceNumber { get; set; }

        public UserModel? Customer { get; set; }
        public DateTime? Date { get; set; }

        [JsonPropertyName("due_date")]
        public DateTime DueDate { get; set; }

        [JsonPropertyName("total_amount")]
        public decimal TotalAmount { get; set; }

        public string? Currency { get; set; }
        public List<ProductModel>? Lines { get; set; }


    }
}
