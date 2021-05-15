using System.Collections;
using Sources.Code.Chat;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Code.Messages
{
    public class UITextMessageDeletable : UITextMessage
    {
        [SerializeField] private Button deleteButton;

        protected override void OnInitialize(Message message)
        {
            deleteButton.onClick.AddListener(OnDeleteButton);
        }

        private void OnDeleteButton()
        {
            MessagesVisualSetup.DisposeMessage(this);
        }
    }
}