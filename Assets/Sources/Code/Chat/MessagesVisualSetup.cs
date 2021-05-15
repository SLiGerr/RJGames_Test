using System.Collections.Generic;
using Sources.Code.Messages;
using UnityEngine;

namespace Sources.Code.Chat
{
    public static class MessagesVisualSetup
    {
        private static List<IUIMessage> _allMessages = new List<IUIMessage>();

        public static void OnMessageAppeared(IUIMessage massage)
        {
            _allMessages.Add(massage);

            UpdateMessagesStyle();
        }

        public static void DisposeMessage(IUIMessage message)
        {
            if(_allMessages.Contains(message))
                _allMessages.Remove(message);
            Object.Destroy(message.UIRootGameObject);
            
            UpdateMessagesStyle();
        }

        public static void UpdateMessagesStyle()
        {
            for (var i = 0; i < _allMessages.Count; i++)
            {
                var currentMessage = _allMessages[i];
                var typeToSet = UIMessageImageType.Root;

                if (i + 1 < _allMessages.Count)
                {
                    var currentAuthor = currentMessage.MessageData.Author;
                    var nextMassage = _allMessages[i + 1];
                    var nextAuthor = nextMassage.MessageData.Author;
                    
                    if (currentAuthor.Equals(nextAuthor))
                    {
                        typeToSet = UIMessageImageType.Nested;
                    }
                }

                currentMessage.SetNameVisibility(typeToSet == UIMessageImageType.Root);
                currentMessage.SetImageType(typeToSet);
            }
        }
    }
}