using UnityEngine;

namespace Sources.Code.Users
{
    public class User : IUser
    {
        public Sprite UserAvatar { get; set; }
        public string UserName { get; set; }

        public User(Sprite avatar, string name)
        {
            UserAvatar = avatar;
            UserName = name;
        }
    }
}