using UnityEngine;

namespace Sources.Code.Users
{
    public interface IUser
    {
        Sprite UserAvatar { get; set; }
        string UserName { get; set; }
    }
}