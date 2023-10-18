using DalChatApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusChatApplication
{
    public class AddFriendService
    {
        public AddFriend AddFriendTrue(string user1, string user2)
        {
            ContextChatDB context = new ContextChatDB();
            return context.AddFriends.FirstOrDefault(p => p.User2 == user1 && p.User1 == user2 && p.FriendRequestFlag == true || p.User1 == user1 && p.User2 == user2 && p.FriendRequestFlag == true);
        }
        public AddFriend AddFriendFalse(string user1, string user2)
        {
            ContextChatDB context = new ContextChatDB();
            return context.AddFriends.FirstOrDefault(p => p.User2 == user1 && p.User1 == user2 && p.FriendRequestFlag == false || p.User1 == user1 && p.User2 == user2 && p.FriendRequestFlag == false);
        }
        public List<AddFriend> GetAll()
        {
            ContextChatDB context = new ContextChatDB();
            return context.AddFriends.ToList();
        }
        public AddFriend CheckAddFriendUser(string user)
        {
            ContextChatDB context = new ContextChatDB();
            return context.AddFriends.FirstOrDefault(q => q.User1 == user);
        }
        public void InsertAddFriend(AddFriend b)
        {
            ContextChatDB context = new ContextChatDB();
            context.AddFriends.Add(b);
            context.SaveChanges();
        }
        public AddFriend CheckFriendRequest(string friend, string user)
        {
            ContextChatDB context = new ContextChatDB();
            return context.AddFriends.FirstOrDefault(p => p.User1 == friend && p.User2 == user);
        }
    }
}
