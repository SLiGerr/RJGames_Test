using UnityEngine;

namespace Sources.Code.Chat
{
    [CreateAssetMenu(menuName = "Create ChatConfiguration", fileName = "ChatConfig", order = 0)]
    public class ChatConfiguration : ScriptableObject
    {
        [Header("Settings")] 
        public int deleteModeChatX = -150;
        public int regularModeChatX = 0;
        public float deleteModeSwitchTime = 0.2f;
        public float fadeSwitchGroupsTime = 0.2f;
        public float messageSpawnAppearLogoTime = 0.1f;
        public float messageSpawnAppearMessageTime = 0.2f;
        public float messageDisposeTime = 0.2f;
        
        [Header("Prefabs")]
        public GameObject activeUserMessagePrefab;
        public GameObject otherUsersMessagePrefab;
    }
}
