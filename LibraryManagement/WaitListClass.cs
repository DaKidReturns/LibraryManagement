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
    public class WaitListClass
    {
        private class WaitListItem
        {
            internal Book book { get; }
            internal IMember member { get; }
            internal DateTime ListJoinTime;
            internal WaitListItem(IMember member,Book book)
            {
                this.book = book;
                this.member = member;
                ListJoinTime = DateTime.Now;
            }

            /// <summary>
            /// Override the default comparator to compare two different WaitListItems
            /// </summary>
            /// <param name="obj"></param>
            /// <returns></returns>
            public override bool Equals(object? obj)
            {
                WaitListItem other = obj as WaitListItem;
                if (other == null) return false;
                if((this.book == other.book) && (this.member == other.member)) return true;
                return false;
            }
        }

        List<WaitListItem> waitList;
        
        public WaitListClass() { 
            waitList = new List<WaitListItem>();
            // TODO: Load previous wait list in case application closes and reopens

            // Use a Thread to continously update the wait list
            new Thread(UpdateList).Start(); // 
        }

        public void AddToList(IMember member, Book book) {
            lock (waitList)
            {
                waitList.Add(new WaitListItem(member,book));
            }
        }

        /// <summary>
        /// The Update List function continously monitors the list and checks if any user is in the waitlist for
        /// more than 3 days and removes them.
        /// </summary>
        public void UpdateList()
        {
            lock (waitList)
            {
                foreach (WaitListItem waitListItem in waitList)
                {
                    if ((DateTime.Now - waitListItem.ListJoinTime).TotalDays>3) {  // 
                        waitList.Remove(waitListItem);
                    }
                }
                Thread.Sleep(10000);
            }

        }

        /// <summary>
        /// Given a user and a book find the corresponding waitlistItem to remove.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="book"></param>
        public bool RemoveFromList(IMember user, Book book)
        {
            lock(waitList)
            {
                WaitListItem removeItem = waitList.Find((item) => item.Equals(new WaitListItem(user, book)));
                if (removeItem != null)
                {
                    waitList.Remove(removeItem);
                }

            }
            return false;
        }

        /// <summary>
        /// Function to find out if a member can get into a waitlist.
        /// Return false if user already has 3 wait list entries
        /// Return true otherwise
        /// </summary>
        /// <param name="member">Member that needs to enter into waitlist</param>
        /// <returns></returns>
        public bool WaitListIsAvailable(IMember member) {

            lock(waitList)
            {
                int count = 0;
                foreach(WaitListItem waitListItem in waitList)
                {
                    if (waitListItem.member == member) count++;
                    if (count >= 3) return false;

                }
            }
            return true;
        }
    }

}
