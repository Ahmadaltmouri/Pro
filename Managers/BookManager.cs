using Pro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro.Managers
{
    public class BookManager
    {
        private List<Book> books = new List<Book>();

     
        public void AddBook(string title, string author)
        {
            if (books.Exists(b => b.Title == title))
            {
                throw new ArgumentException("The book already exists");
            }
            books.Add(new Book { Title = title, Author = author });
        }

      
        public bool BorrowBook(User user, string title)
        {
            var book = books.Find(b => b.Title == title && b.IsAvailable);
            if (book == null) return false; 

     
            book.IsAvailable = false;
            user.BorrowedBooks.Add(book); 
            return true;
        }


        public bool ReturnBook(User user, string title)
        {
            var book = user.BorrowedBooks.Find(b => b.Title == title);
            if (book == null) return false; 

     
            book.IsAvailable = true;
            user.BorrowedBooks.Remove(book); 
            return true;
        }

       
        public void RemoveBook(string title)
        {
            var book = books.Find(b => b.Title == title);
            if (book == null)
            {
                throw new ArgumentException("Book not found.");
            }
            books.Remove(book);
        }

        public List<Book> GetAllBooks()
        {
            return books;
        }
    }
}
