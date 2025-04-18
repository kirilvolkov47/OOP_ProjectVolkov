namespace OOP_Project
{
    public class Review
    {
        public Passenger Author { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

        public Review(Passenger author, int rating, string comment)
        {
            Author = author;
            Rating = rating;
            Comment = comment;
        }
    }
}