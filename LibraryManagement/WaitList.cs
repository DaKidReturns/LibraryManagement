using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{

    /// <summary>
    /// The WaitList class Maintains a waiting list for books.
    /// 
    /// </summary>
    public class WaitList
    {
        private class WaitListItem
        {
            Book book;
            DateTime ListJoinTime;
            internal WaitListItem(Book book)
            {
                this.book = book;
                ListJoinTime = DateTime.Now;
            }

        }

        List<WaitListItem> waitList;
        
        public WaitList() { 
            waitList = new List<WaitListItem>();
            // TODO: Load previous wait list in case application closes and reopens
        }

        public void AddToList(IMember member, Book book) {
            waitList.Add(new WaitListItem(book));
        }

    }
    
}
