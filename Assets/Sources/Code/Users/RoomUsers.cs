using System.Collections.Generic;
using UnityEngine;

namespace Sources.Code.Users
{
    public static class RoomUsers
    {
        public static List<IUser> UserList { get; set; }
        
        public static IUser RandomUser() =>
            UserList.Count == 0 ? null : UserList[Random.Range(0, UserList.Count)];

        public static IUser ActiveUser { get; set; }
    }
}
