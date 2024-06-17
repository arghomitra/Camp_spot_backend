namespace Final_Project.Model
{
    public class Spot
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
       
       
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Guest { get; set; }
        public string Owner_Email { get; set; }
        public string Owner_Phone { get; set; }

        public int Price { get; set; }
        public string Image_link1 { get; set; }
        public string Image_link2 { get; set; }
        public bool IsAvailable { get; set; } = true;

    }
}
