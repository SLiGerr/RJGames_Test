using Sources.Code.Users;
using UnityEngine;

namespace Sources.Code.Messages
{
    public interface IMessageFactory
    {
        Message PopulateNewTextMessage(string text, IUser author);
    }
}