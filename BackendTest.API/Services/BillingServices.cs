using AutoMapper;
using BackendTest.API.Data.Repositories;
using BackendTest.API.Domain.Entities;
using BackendTest.API.Models;

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

        public Billing AddBilling(string id)
        {

            var httpClient = new HttpClient();
            HttpResponseMessage response = null;
            try
            {
                 response = httpClient.GetAsync
                    ($"https://65c3b12439055e7482c16bca.mockapi.io/api/v1/billing/{id}").Result;
            }
            catch { return null; }
            var jsonResponse = response.Content.ReadAsStringAsync().Result;
            var options = new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var model = System.Text.Json.JsonSerializer.Deserialize<BillingModel>(jsonResponse, options);

            if(_context.Billing.FirstOrDefault(x=>x.Id == id) != null)
            {
                throw new Exception($"Billing ID {id} already exists in the database");
            }

            var billing = _mapper.Map<Billing>(model);

            if (billing.Details == null || billing.Details.Lines.Count()<0)
            {
                throw new ArgumentNullException(nameof(billing.Details) + ": Billing Lines is Mandatory");
            }
            if(billing.Details.Customer == null)
            {
                throw new ArgumentNullException(nameof(billing.Details.Customer) + ": Customer is Mandatory");
            }

            var user = _context.Users.FirstOrDefault(x => x.Id == billing.Details.Customer.Id);
            if (user == null && billing.Details.Customer.IsValid().Count()==0) 
            {
                _context.Users.Add(billing.Details.Customer); 
            }else{return billing; }

            if(billing.Details.Lines.Count==0)
                throw new ArgumentNullException(nameof(billing.Details.Lines) + ": BillingLines is Mandatory");

            foreach (Product line in billing.Details.Lines)
            {

                line.SetId(new Guid());
                 _context.Products.Add(line);
            }
            

            _context.Billing.Add(billing);

           _context.SaveChanges();

            return billing;
        }
    }
}
