using Sources.Code.Chat;
using Sources.Code.Users;
using UnityEngine;

namespace Sources.Code.Messages
{
    public class UIMessageFactory : IUIMessageFactory
    {
        public IUIMessage InstantiateMessage(Message message, RectTransform root)
        {
            var config = ConfigLoader.GetConfig();
            var isActiveUser = RoomUsers.ActiveUser.Equals(message.Author);
            var massageGo = 
                Object.Instantiate(isActiveUser ? config.activeUserMessagePrefab : config.otherUsersMessagePrefab, root);
            var uiMassage = massageGo.GetComponent<IUIMessage>();
            uiMassage.Initialize(message);
            MessagesAdjuster.OnMessageAppeared(uiMassage);
            ChatAnimations.MessageAppear(uiMassage);
            return uiMassage;
        }
    }
}