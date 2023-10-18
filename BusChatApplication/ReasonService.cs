using DalChatApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusChatApplication
{
    public class ReasonService
    {
        public List<Reason> GetAll()
        {
            ContextChatDB context = new ContextChatDB();
            return context.Reasons.OrderBy(p => p.ReportReasonID).ToList();
        }
    }
}
