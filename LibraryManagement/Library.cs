using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    /// <summary>
    ///
    /// The list of students, faculties, books are stored in the library class.
    /// </summary>
    public class Library
    {
        List<Book> books = new List<Book>();
        List<Student> students = new List<Student>();
        List<Faculty> faculties = new List<Faculty>();

        public List<Book> Books{ get { return books; } }
        public List<Student> Students{ get { return students; } }
        public List<Faculty> Faculties{ get { return faculties; } }

        public List<(IMember, Book)> BookAvailableMemberToNotify { get; }

        /// <summary>
        /// A member of the library can issue a book
        /// Returns true if book is issued and the process is successful
        ///         false if failure
        /// </summary>
        /// <param name="member">The member that </param>
        /// <param name="bookToBeIssued"></param>
        /// <returns></returns>
        public bool IssueBook(IMember member, Book bookToBeIssued) {
            if (bookToBeIssued.IsIssued)
            {
                BookAvailableMemberToNotify.Add((member, bookToBeIssued));
                return false;
            }

            if ((bookToBeIssued.DateOfArrival - DateTime.Now).TotalDays < 7) {
                return false;
            }

            member.BorrowedBooks.Add(bookToBeIssued);
            bookToBeIssued.IsIssued = true;
            bookToBeIssued.IssuedBy = member;
            return true;
        }

        public bool RegisterWaitList(IMember member, Book bookToBeIssued) { 
            
        
        }
    }
}
