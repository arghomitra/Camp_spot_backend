using Final_Project.Model;
using Final_Project.data;

namespace Final_Project.Model
{
    public class User
    {
        public int Id { get; private set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public Address UserAddress { get; set; } 

        
        public User()
        {
            UserAddress = new Address();
        }

        
        public class Address
        {
            public string Street { get; set; }
            public string Housenumber { get; set; }
            public string Postalcode { get; set; }
            public string City { get; set; }
        }
    }
}
