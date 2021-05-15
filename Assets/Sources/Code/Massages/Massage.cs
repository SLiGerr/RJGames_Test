using System;
using Sources.Code.Users;

namespace Sources.Code.Massages
{
    public class Massage
    {
        public IUser Author { get; }
        public IMassageContent Content { get; }
        public DateTime SendedDate { get; }
        
        public Massage(DateTime sendedDate, IUser author, IMassageContent content)
        {
            SendedDate = sendedDate;
            Author = author;
            Content = content;
        }
    }
}
