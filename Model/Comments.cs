namespace Final_Project.Model
{
    public class Comments
    {
        public int Id { get; private set; }
        public int SpotId { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }
        public int Rate { get; set; }

    }
}
