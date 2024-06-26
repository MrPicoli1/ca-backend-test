using BackendTest.API.Shered;

namespace BackendTest.API.Models
{
    public class ProductModel
    {

        public string? Name { get; set; }


        public bool IsNull() { return Name == null; }
    }
}
