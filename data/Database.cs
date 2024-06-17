using LiteDB;
using Final_Project.Model;
using Final_Project.Controllers;

namespace Final_Project.data
{
    public class Database : dataContext
    {
        LiteDatabase db = new LiteDatabase(@"data.db");
        //private const string _USERS = "Users";
        
        public void AddUser(User user)
        {
            db.GetCollection<User>("User").Insert(user);
        }
        public void AddAdmin(Admin admin)
        {
            db.GetCollection<Admin>("Admin").Insert(admin);
        }
        public IEnumerable<Admin> GetAdmins()
        {
            return db.GetCollection<Admin>("Admin").FindAll();
        }

        public IEnumerable<User> GetUsers()
        {
            return db.GetCollection<User>("User").FindAll();
        }

        public void DeleteUser(int id)
        {
            db.GetCollection<User>("User").Delete(id);
        }
        public void DeleteBooking(int id)
        {
            db.GetCollection<Booking>("Booking").Delete(id);
        }
        public void DeleteSpot(int id)
        {
            db.GetCollection<Spot>("Spot").Delete(id);
        }
        public IEnumerable<User> GetUserByName(string name)
        {
            return db.GetCollection<User>("User").Find(user => user.Firstname == name);
        }
        //public IEnumerable<User> GetUserById(int id)
        //{
        //    return db.GetCollection<User>("User").Find(user => user.Id == id);
        //}
        public IEnumerable<User> GetUserByEmail(string email)
        {
            return db.GetCollection<User>("User").Find(user => user.Email == email);
        }

        // user login
        public User GetUserByEmailPassword(string email, string password)
        {
            return db.GetCollection<User>("User")
                         .Find(user => user.Email == email && user.Password == password)
                         .SingleOrDefault();
        }

        public void AddSpot(Spot spot)
        {
            db.GetCollection<Spot>("Spot").Insert(spot);
        }
        public IEnumerable<Spot> GetSpots()
        {
            return db.GetCollection<Spot>("spot").FindAll();
        }
        


        IEnumerable<Spot> dataContext.GetSpotByLocation(string city)
        {
            return db.GetCollection<Spot>("Spot").Find(spot => spot.City == city);
        }
        IEnumerable<Spot> dataContext.GetSpotByLocationAndPrice(string city, int minPrice, int maxPrice)
        {
            return db.GetCollection<Spot>("Spot").Find(spot => (spot.City == city)&&(spot.Price >= minPrice && spot.Price <= maxPrice));
        }
        IEnumerable<Spot> dataContext.GetSpotByfilter(string city,DateTime startdate, DateTime enddate, int guest)
        {
            return db.GetCollection<Spot>("Spot").Find(spot => (spot.StartDate <= startdate) && (spot.EndDate >= enddate)&& (spot.City == city) && (spot.Guest >= guest) );
        }

        public IEnumerable<Booking> GetBookings()
        {
            return db.GetCollection<Booking>("booking").FindAll();
        }
        public IEnumerable<Message> GetMessage()
        {
            return db.GetCollection<Message>("message").FindAll();
        }
        public void AddMessage(Message message)
        {
            db.GetCollection<Message>("message").Insert(message);
        }

        public void SaveChanges(int id, User updatedUser)
        {
            var usersCollection = db.GetCollection<User>("User");
            var existingUser = usersCollection.FindById(id);
            if (existingUser != null)
            {
                existingUser.Firstname = updatedUser.Firstname;
                existingUser.Lastname = updatedUser.Lastname;
                existingUser.Email = updatedUser.Email;
                existingUser.Phone = updatedUser.Phone;
                existingUser.Gender = updatedUser.Gender;
                existingUser.UserAddress.Street = updatedUser.UserAddress.Street;
                existingUser.UserAddress.Housenumber = updatedUser.UserAddress.Housenumber;
                existingUser.UserAddress.Postalcode = updatedUser.UserAddress.Postalcode;
                existingUser.UserAddress.City = updatedUser.UserAddress.City;

                usersCollection.Update(existingUser);
            }
            
        }

        

        public User GetUserById(int id)
        {
            return db.GetCollection<User>("User").FindById(id);
        }
        public Spot GetSpotById(int id)
        {
            return db.GetCollection<Spot>("Spot").FindById(id);
        }
        //public Comments GetCommentsById(int id)
        //{
        //    return db.GetCollection<Comments>("Comments").FindById(id);
        //}
        public IEnumerable<Comments> GetCommentsBySpotId(int id)
        {
            return db.GetCollection<Comments>("Comments").Find(comment => comment.SpotId == id);

            
        }

        public void SaveChanges(int id, Spot spot)
        {
            var spotsCollection = db.GetCollection<Spot>("Spot");
            var existingspot = spotsCollection.FindById(id);
            if (existingspot != null)
            {
                existingspot.Name = spot.Name;
                existingspot.Location = spot.Location;
                existingspot.Price = spot.Price;
                existingspot.City = spot.City;
                existingspot.StartDate = spot.StartDate;
                existingspot.EndDate = spot.EndDate;
                existingspot.Owner_Email = spot.Owner_Email;
                existingspot.Owner_Phone = spot.Owner_Phone;
                existingspot.Image_link1 = spot.Image_link1;
                existingspot.Image_link2 = spot.Image_link2;
                existingspot.Guest = spot.Guest;


                spotsCollection.Update(existingspot);
            }
        }
        public void AddBooking(Booking booking) 
        {
            db.GetCollection<Booking>("Booking").Insert(booking);
        }
        public IEnumerable<Comments> GetComments()
        {
            return db.GetCollection<Comments>("Comments").FindAll();
        }
        public void AddComment( Comments comment)
        {
            db.GetCollection<Comments>("Comments").Insert(comment);
            
        }


        public void UpdateUserPassword(string email, string newPassword)
        {
            
            var usersCollection = db.GetCollection<User>("User");
            var existUser = usersCollection.FindOne(user => user.Email == email);
            if (existUser != null)
            {
                existUser.Password = newPassword;
                usersCollection.Update(existUser);
            }
        }


    }
}
