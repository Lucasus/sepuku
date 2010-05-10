using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seppuku.Domain
{
    public class Message
    {
        public int MessageId { get; set; }
        public int MainUserId { get; set; }
        public int SecondaryUserId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime SendDate { get; set; }
        public bool isRead { get; set; }
    }
}