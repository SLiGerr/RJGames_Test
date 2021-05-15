using System;
using Sources.Code.Chat;
using Sources.Code.Users;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Code.Massages
{
    public class UIMassageInputField : MonoBehaviour
    {
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private RectTransform createRoot;
        [SerializeField] private Button sendButton;

        [SerializeField] private GameObject 
            activeUserMassagePrefab, 
            otherUsersMassagePrefab;

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
            var user = RoomUsers.RandomUser();

            var massage = new Massage(DateTime.Now, user, new MassageTextContent(text));
            
            var isActiveUser = RoomUsers.ActiveUser.Equals(user);
            var massageGo = Instantiate(isActiveUser ? activeUserMassagePrefab : otherUsersMassagePrefab, createRoot);
            var uiMassage = massageGo.GetComponent<IUIMassage>();
            uiMassage.Initialize(massage);
            UIChatAnimations.MassageAppear(uiMassage);
        }

        private bool CheckTextCanBeSend(string text)
        {
            //There is can be any type of checks, like "Only spaces"
            
            if (text.Length == 0) return false;
            return true;
        }
    }
}
