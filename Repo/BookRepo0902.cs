using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Repo
{
    public interface IBookREpo0902
    {
        void AddNewBook(BookModel0902 book);
        void AddBulkBooks(List<BookModel0902> books);
        void RemoveBookById(int id);
        BookModel0902 GetBookById(int id);
        List<BookModel0902> GetAllBooksByGenre(string genre);
        List<BookModel0902> DisplayBooksSortedByPrice();
        List<string> GetAllAuthors();
        List<BookModel0902> GetAllBooksByPublisher(string publisher);
        void RemoveAllBooksByPublisher(string publisher);
        List<BookModel0902> DisplayBooksSortedByYearOfPublishing();
        void UpdateBookById(int id, JsonPatchDocument p);
    }
    public class BookRepo0902
    {
        private List<BookModel0902> _b;
        public BookRepo0902()
        {
            _b = new List<BookModel0902>();
        }
        public void AddNewBook(BookModel0902 book)
        {
            _b.Add(book);
        }

        public void AddBulkBooks(List<BookModel0902> books)
        {
            foreach (BookModel0902 book in books) _b.Add(book);
        }

        public void RemoveBookById(int id)
        {
            for (int i = 0; i < _b.Count; i++)
            {
                if (_b[i].BookId == id) _b.Remove(_b[i]);
            }
        }

        public BookModel0902 GetBookById(int id)
        {
            for (int i = 0; i < _b.Count; i++)
            {
                if (_b[i].BookId == id) return _b[i];
            }
            return null;
        }

        public List<BookModel0902> GetAllBooksByGenre(string genre)
        {
            List<BookModel0902> li = new List<BookModel0902>();
            foreach (BookModel0902 book in _b)
            {
                if (book.Genre == genre) li.Add(book);
            }
            return li;
        }

        public List<BookModel0902> DisplayBooksSortedByPrice()
        {
            List<BookModel0902> sorted = new List<BookModel0902>(_b);
            sorted.Sort((b1, b2) => b1.Price.CompareTo(b2.Price));
            return sorted;
        }

        public List<string> GetAllAuthors()
        {
            List<string> authors = new List<string>();
            foreach (BookModel0902 book in _b)
            {
                authors.Add(book.Author);
            }
            return authors;
        }

        public List<BookModel0902> GetAllBooksByPublisher(string publisher)
        {
            List<BookModel0902> pubList = new List<BookModel0902>();
            foreach (BookModel0902 book in _b)
            {
                if (book.Publisher == publisher)
                {
                    pubList.Add(book);
                }
            }
            return pubList;
        }

        public void RemoveAllBooksByPublisher(string publisher)
        {
            foreach (BookModel0902 book in _b)
            {
                if (book.Publisher == publisher)
                {
                    _b.Remove(book);
                }
            }
        }

        public List<BookModel0902> DisplayBooksSortedByYearOfPublishing()
        {
            List<BookModel0902> sorted = new List<BookModel0902>(_b);
            sorted.Sort((b1, b2) => b1.Year - b2.Year);
            return sorted;
        }

        public void UpdateBookById(int id, JsonPatchDocument p)
        {
            foreach (var book in _b)
            {
                if (book.BookId == id)
                {
                    p.ApplyTo(book);
                }
            }
        }
    }
}
