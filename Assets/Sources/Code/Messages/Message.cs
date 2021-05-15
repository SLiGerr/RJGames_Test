using System;
using Sources.Code.Users;

namespace Sources.Code.Messages
{
    public class Message
    {
        public IUser Author { get; }
        public IMessageContent Content { get; }
        public DateTime SendedDate { get; }
        
        public Message(DateTime sendedDate, IUser author, IMessageContent content)
        {
            SendedDate = sendedDate;
            Author = author;
            Content = content;
        }
    }
}
