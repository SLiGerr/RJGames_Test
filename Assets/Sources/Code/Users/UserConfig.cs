using UnityEngine;

namespace Sources.Code.Users
{
    [CreateAssetMenu(menuName = "Create UserConfig", fileName = "UserConfig", order = 0)]
    public class UserConfig : ScriptableObject
    {
        [SerializeField] private Sprite userIcon;
        [SerializeField] private string userName;
        private User _user;
        public User GetUser => _user ?? (_user = new User(userIcon, userName));
    }
}