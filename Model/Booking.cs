namespace Final_Project.Model
{
    public class Booking
    {
        public int Id { get; private set; }
        
        public string SpotName { get; set; }
        public string Location { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public int Guests { get; set; }
        public float Price { get; set; }
        public int UserId { get; set; }
        public int SpotId { get; set; }
        public bool IsConfirmation { get; set; } = true;




    }
}
