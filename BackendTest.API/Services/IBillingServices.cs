using BackendTest.API.Domain.Entities;
using BackendTest.API.Models;

namespace BackendTest.API.Services
{
    public interface IBillingServices
    {
        public Task<Billing> AddBilling (string id);
    }
}
