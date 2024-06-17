using Final_Project.Model;
using Final_Project.data;
namespace Final_Project.Model
{
    public class Admin
    {
        public int Id { get; private set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
    }
}
