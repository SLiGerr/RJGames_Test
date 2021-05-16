using System;
using Sources.Code.Users;

namespace Sources.Code.Messages
{
    public class Message
    {
        public IUser Author { get; }
        public IMessageContent Content { get; }
        public DateTime SentDate { get; }
        
        public Message(DateTime sentDate, IUser author, IMessageContent content)
        {
            SentDate = sentDate;
            Author = author;
            Content = content;
        }
    }
}
