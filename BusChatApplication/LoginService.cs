using DalChatApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusChatApplication
{
    public class LoginService
    {
        public void InsertLogin(Login l)
        {
            ContextChatDB context = new ContextChatDB();
            context.Logins.Add(l);
            context.SaveChanges();
        }
        public Login FindByUser(string username, string password)
        {
            ContextChatDB context = new ContextChatDB();
            return context.Logins.FirstOrDefault(p => p.Password.Equals(password) && p.Username.Equals(username));
        }
        public Login FindAdmin(string username, string password)
        {
            ContextChatDB context = new ContextChatDB();
            return context.Logins.FirstOrDefault(p => p.Password.Equals(password) && p.Username.Equals(username) && p.IDPermission == 2);
        }
        public Login FindBanned(string username, string password)
        {
            ContextChatDB context = new ContextChatDB();
            return context.Logins.FirstOrDefault(p => p.Password.Equals(password) && p.Username.Equals(username) && p.IDPermission == 3);
        }
        public Login FindUsername(string username)
        {
            ContextChatDB context = new ContextChatDB();
            return context.Logins.FirstOrDefault(p => p.Username == username);
        }
        public List<Login> GetAll()
        {
            ContextChatDB context = new ContextChatDB();
            return context.Logins.ToList();
        }
        public int CountAll()
        {
            ContextChatDB context = new ContextChatDB();
            return context.Logins.Count();
        }
        public int StatusCount()
        {
            ContextChatDB context = new ContextChatDB();
            return context.Logins.Where(p => p.UserStatus == true).Count();
        }
    }
}
