using BackendTest.API.Shered;
using System.Text.RegularExpressions;

namespace BackendTest.API.Domain.Entities
{
    public partial class User : Entity
    {
        private const string Pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

        public User(string name, string email, string address)
        {
            Name = name;
            Email = email;
            Address = address;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }

        public void Update(string name, string email, string address)
        {
            Name = name;
            Email = email;
            Address = address;
        }
        [GeneratedRegex(Pattern)]
        private static partial Regex EmailRegex();

        public List<string> IsValid()
        {

            List<string> errors = new List<string>();

            if(!EmailRegex().IsMatch(Email))
            {
                errors.Add("Invalid email");
            }
            if(Name.Length < 3)
            {
                errors.Add("Name must be at least 2 characters");
            }
            if(Address.Length < 3)
            {
                errors.Add("Address must be at least 2 characters");
            }

            return errors;
        }
    }
}
