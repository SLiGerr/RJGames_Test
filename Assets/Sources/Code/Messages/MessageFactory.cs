using System;
using Sources.Code.Users;

namespace Sources.Code.Messages
{
    public class MessageFactory : IMessageFactory
    {
        public Message PopulateNewTextMessage(string text, IUser author)
        {
            return new Message(DateTime.Now, author, new MessageTextContent(text));
        }
    }
}