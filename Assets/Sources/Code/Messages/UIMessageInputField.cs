using Sources.Code.Users;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Code.Messages
{
    public class UIMessageInputField : MonoBehaviour
    {
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private RectTransform createRoot;
        [SerializeField] private Button sendButton;
        
        [Header("(Null for random)")]
        [SerializeField] private UserConfig nextUser;
        
        private void Start()
        {
            inputField.onSubmit.AddListener(InputSubmitted);
            sendButton.onClick.AddListener(ManualSendRequest);
        }

        private void ManualSendRequest()
        {
            InputSubmitted(inputField.text);
        }

        private void InputSubmitted(string text)
        {
            if (!CheckTextCanBeSend(text)) return;
            inputField.text = null;
            
            //Possible checks for multiple types of massages including images or video contents
            CreateNewTextMassage(text);
        }

        private void CreateNewTextMassage(string text)
        {
            var user = nextUser == null ? RoomUsers.RandomUser() : nextUser.GetUser;
            var message = MessageCreator.MessageFactory.PopulateNewTextMessage(text, user);
            MessageCreator.UIMessageFactory.InstantiateMessage(message, createRoot);
        }

        private bool CheckTextCanBeSend(string text)
        {
            if (text.Length == 0) return false;
            //There is can be any type of checks, like "Only spaces"
            return true;
        }
    }
}
