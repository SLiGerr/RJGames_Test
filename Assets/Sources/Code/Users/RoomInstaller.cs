using System.Collections.Generic;
using UnityEngine;

namespace Sources.Code.Users
{
    public class RoomInstaller : MonoBehaviour
    {
        [SerializeField] private List<UserConfig> userConfigs;
        [SerializeField] private UserConfig activeUser; 

        private void Awake()
        {
            RoomUsers.UserList = GetUserList();
            RoomUsers.ActiveUser = activeUser.GetUser;
        }

        private List<IUser> GetUserList()
        {
            var list = new List<IUser>();
            userConfigs.ForEach(o => list.Add(o.GetUser));
            return list;
        }
    }
}
