using AutoMapper;
using BackendTest.API.Data.Repositories;
using BackendTest.API.Domain.Entities;
using BackendTest.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendTest.API.Services
{
    public class BillingServices : IBillingServices
    {
        private readonly IMapper _mapper;
        private readonly MySqlContext _context;

        public BillingServices(IMapper mapper, MySqlContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Billing> AddBilling(string id)
        {

            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync
                ($"https://65c3b12439055e7482c16bca.mockapi.io/api/v1/billing/{id}");

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var options = new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var model = System.Text.Json.JsonSerializer.Deserialize<BillingModel>(jsonResponse, options);


            var billing = _mapper.Map<Billing>(model);

            if (billing.Details == null || billing.Details.Lines.Count()<0)
            {
                throw new ArgumentNullException(nameof(billing.Details) + ": Billing Lines is Mandatory");
            }
            if(billing.Details.Customer == null)
            {
                throw new ArgumentNullException(nameof(billing.Details.Customer) + ": Customer is Mandatory");
            }

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == billing.Details.Customer.Id);
            if (user == null && billing.Details.Customer.IsValid().Count()==0) 
            {
                await _context.Users.AddAsync(billing.Details.Customer); 
            }else{return null; }

            if(billing.Details.Lines.Count==0)
                throw new ArgumentNullException(nameof(billing.Details.Lines) + ": BillingLines is Mandatory");

            foreach (Product line in billing.Details.Lines)
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == line.Id);
                if (product == null)
                {
                    await _context.Products.AddAsync(line);
                }
            }
            

            await _context.Billing.AddAsync(billing);

            await _context.SaveChangesAsync();

            return billing;
        }
    }
}
