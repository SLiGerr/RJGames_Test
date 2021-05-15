using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Code.Messages
{
    public class UITextMessage : MonoBehaviour, IUIMessage
    {
        [SerializeField] private Image userLogo;
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI contentText;
        [SerializeField] private TextMeshProUGUI dateText;

        [SerializeField] private Image messageImage;
        [SerializeField] private Sprite rootImage;
        [SerializeField] private Sprite nestedImage;

        [SerializeField] private VerticalLayoutGroup messageTextContent;
        [SerializeField] private VerticalLayoutGroup messageBodyContent;

        [SerializeField] private StyleLayoutCorrections layoutCorrections;

        public Message MessageData { get; set; }
        public GameObject UIRootGameObject { get; set; }
        public GameObject UIMassageGo { get; set; }


        public void Initialize(Message message)
        {
            MessageData = message;

            UIRootGameObject = gameObject;
            UIMassageGo = messageImage.gameObject;

            OnInitialize(MessageData);
            if (MessageData == null) return;

            nameText.SetText(MessageData.Author.UserName);
            userLogo.sprite = MessageData.Author.UserAvatar;
            contentText.SetText(MessageData.Content.Content as string);
            var dayPassed = DateTime.Now > MessageData.SendedDate.AddDays(1);
            dateText.SetText(MessageData.SendedDate.ToString(dayPassed ? "M/d/yy" : "HH:mm"));
        }

        protected virtual void OnInitialize(Message message) { }


        public void SetNameVisibility(bool to)
        {
            nameText.gameObject?.SetActive(to);
            userLogo.gameObject?.SetActive(to);
        }

        public void SetImageType(UIMessageImageType to)
        {
            switch (to)
            {
                default: //Root
                    messageImage.sprite = rootImage;
                    layoutCorrections.SetLayoutRoot(messageTextContent, messageBodyContent);
                    break;
                case UIMessageImageType.Nested:
                    messageImage.sprite = nestedImage;
                    layoutCorrections.SetLayoutNested(messageTextContent, messageBodyContent);
                    break;
            }
        }
    }
    
        
    [Serializable]
    public class StyleLayoutCorrections
    {
        public RectOffset textContentNested;
        public RectOffset textContentRoot;
        public RectOffset messageBodyNested;
        public RectOffset messageBodyRoot;
        public void SetLayoutNested(VerticalLayoutGroup textContent, VerticalLayoutGroup messageBody)
        {
            textContent.padding = textContentNested;
            messageBody.padding = messageBodyNested;
        }
        public void SetLayoutRoot(VerticalLayoutGroup textContent, VerticalLayoutGroup messageBody)
        {
            textContent.padding = textContentRoot;
            messageBody.padding = messageBodyRoot;
        }
    }
}