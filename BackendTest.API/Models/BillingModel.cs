using BackendTest.API.Domain.Entities;
using System.Text.Json.Serialization;

namespace BackendTest.API.Models
{
    public class BillingModel
    {
        [JsonPropertyName("0")]
        public BillingLinesModel? Details { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? Name { get; set; }
        public string? InvoiceAmount { get; set; }
        public string? CurrencyCode { get; set; }
        public long? InvoiceDate { get; set; }
        public string? Id { get; set; }
    }
}
