using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{

    /// <summary>
    /// Interface for Members of the library
    /// those who can access the functions of the 
    /// Library.
    /// </summary>
    public interface IMember
    {
        public event EventHandler<BookRelasedArgs> BookReleased;
        string Name { get; set; }
        string Address { get; set; }
        string Email { get; set; }
        List<Book> IssuedList { get; }

        /// <summary>
        /// This function implements the querying books functionality for the members of the library
        /// </summary>
        /// <param name="lib">The library object that contains list of books</param>
        /// <param name="section">The required Section of the library to query</param>
        /// <returns>List of book ordered by title and Year of publicataion of a particular section</returns>
        List<Book> QueryBookFromLibrary(Library lib, Section section)
        {
            return (from Book book in lib.Books
                    where book.BookSection == section
                    orderby book.Title
                    orderby book.YearOfPublication
                    select book).ToList();
        }

        public bool ReturnBook(Book book) {
            if (IssuedList.Remove(book))
            {
                // Notify all the subscribers that book has been released
                BookRelasedArgs e = new BookRelasedArgs(book);
                BookRelasedEvent(e);
                return true;
                
            }
            else {
                return false;
            }
        
        }

        void BookRelasedEvent(BookRelasedArgs e) {
            if (BookReleased != null)
            {
                BookReleased(this, e);
            }
        }

        

    }
    public class BookRelasedArgs : EventArgs
    {
        public Book book { get; set; }

        public BookRelasedArgs(Book book) { this.book = book; }
    }
}
