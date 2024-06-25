using BackendTest.API.Shered;

namespace BackendTest.API.Domain.Entities
{
    public class Product : Entity
    {
        public Product(string name) 
        {
            Name = name;
        }

        public string Name { get; private set; }

        public void Update(string name)
        {
            Name = name;
        }

        public string IsValid()
        {

            if (Name.Length < 3)
            {
                return "Name must be at least 2 characters";
            }

            return null;
        }

    }
}
