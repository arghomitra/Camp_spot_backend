using Final_Project.Controllers;
using Final_Project.Model;
namespace Final_Project.data
{
    public interface dataContext
    {
        void AddUser(User user);
        

        IEnumerable<User> GetUsers();
        void DeleteUser(int id);
        void DeleteBooking(int id);
        void DeleteSpot(int id);
        IEnumerable<Comments> GetComments();
        IEnumerable<User> GetUserByName(string name);
        IEnumerable<User> GetUserByEmail(string email);
        User GetUserByEmailPassword(string email, string password);

        void AddSpot(Spot spot);
        void AddAdmin(Admin admin);
        void AddBooking(Booking booking);
        void AddComment( Comments comment);
        IEnumerable<Spot> GetSpots();
        IEnumerable<Message> GetMessage();
        void AddMessage(Message message);
        IEnumerable<Admin> GetAdmins();
        IEnumerable<Spot> GetSpotByLocation(string city);
        IEnumerable<Spot> GetSpotByLocationAndPrice(string city, int minPrice, int maxPrice);
        IEnumerable<Spot> GetSpotByfilter(string city,DateTime startdate, DateTime enddate, int guest);
        IEnumerable<Booking> GetBookings();
        
        User GetUserById(int id);
        Spot GetSpotById(int id);
        //Comments GetCommentsById(int id);
        IEnumerable<Comments> GetCommentsBySpotId(int id);
        void SaveChanges(int id, User existingUser);
        void SaveChanges(int id, Spot existingSpot);


        void UpdateUserPassword(string email, string newPassword);
    }

    
}
