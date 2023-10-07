using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    
    public class Book
    {
        private bool isIssued;
        public string Title { get; set; }
        public string Author { get; set; }
        public string YearOfPublication { get; set; }
        public IMember IssuedBy { get; set; }
        public Section BookSection { get; set; }

        public DateTime DateOfArrival { get; set; }
        

        public Book(string title, string author, string yearOfPublication, Section section ) {
            Title = title;
            Author = author;
            YearOfPublication = yearOfPublication;
            BookSection = section;
            DateOfArrival = DateTime.Now;
            isIssued = false;
        }

        public bool IsIssued
        {
            get
            {
                return isIssued;
            }
            set
            {
                isIssued = value;
            }
        }




    }
}
