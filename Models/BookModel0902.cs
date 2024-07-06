namespace WebApplication1.Models
{
    public class BookModel0902
    {
        public int BookId {  get; set; }
        public string Title { get; set; }
        public string Author {  get; set; }
        public string Publisher { get; set; }
        public int Isbn { get; set; }
        public double Price { get; set; }
        public string Genre { get; set; }
        public int Edition { get; set; }
        public int Year { get; set; }
        public int Rating { get; set; }

        public BookModel0902(int bookId, string title, string author, string publisher, int isbn, double price, string genre, int edition, int year, int rating)
        {
            BookId = bookId;
            Title = title;
            Author = author;
            Publisher = publisher;
            Isbn = isbn;
            Price = price;
            Genre = genre;
            Edition = edition;
            Year = year;
            Rating = rating;          
        }
    }
}
