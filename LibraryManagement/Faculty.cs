using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class Faculty : IMember
    {
        private string name;
        private string address;
        private string email;
        private List<Book> borrowedBooks;

        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Email { get => email; set => email = value; }
        public List<Book> BorrowedBooks { get => borrowedBooks; }
    }
}
