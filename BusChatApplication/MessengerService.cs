using DalChatApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusChatApplication
{
    public class MessengerService
    {
        public void InsertMessage(Messenger m)
        {
            ContextChatDB context = new ContextChatDB();
            context.Messengers.Add(m);
            context.SaveChanges();
        }
        public List<Messenger> GetAllMessage(string username)
        {
            ContextChatDB context = new ContextChatDB();
            return context.Messengers.Where(p => p.Username1 == username || p.Username2 == username).ToList();
        }
        public int CountMessage(string username)
        {
            ContextChatDB context = new ContextChatDB();
            return context.Messengers.Where(p => p.Username1 == username || p.Username2 == username).Count();
        }
    }
}
