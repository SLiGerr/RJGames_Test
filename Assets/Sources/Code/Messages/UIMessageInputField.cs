using System;
using Sources.Code.Chat;
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
        
        [Space]
        [SerializeField] private GameObject activeUserMessagePrefab;
        [SerializeField] private GameObject otherUsersMessagePrefab;

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
            CreateNewMassage(text);
            LayoutRebuilder.ForceRebuildLayoutImmediate(createRoot);
        }

        private void CreateNewMassage(string text)
        {
            var user = nextUser == null ? RoomUsers.RandomUser() : nextUser.GetUser;

            var massage = new Message(DateTime.Now, user, new MessageTextContent(text));
            
            var isActiveUser = RoomUsers.ActiveUser.Equals(user);
            var massageGo = Instantiate(isActiveUser ? activeUserMessagePrefab : otherUsersMessagePrefab, createRoot);
            var uiMassage = massageGo.GetComponent<IUIMessage>();
            uiMassage.Initialize(massage);
            ChatAnimations.MessageAppear(uiMassage);
        }

        private bool CheckTextCanBeSend(string text)
        {
            //There is can be any type of checks, like "Only spaces"
            
            if (text.Length == 0) return false;
            return true;
        }
    }
}
