using Sources.Code.Chat;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Code.Delete
{
    public class UIDeleteMessagesModeSwitcher : MonoBehaviour
    {
        [SerializeField] private Button deleteModeButton;
        [SerializeField] private Button completeDeleteButton;

        [SerializeField] private CanvasGroup inputTextGroup, completeDeleteGroup;

        [SerializeField] private RectTransform messagesContent;

        private void Start()
        {
            deleteModeButton.onClick.AddListener(OnDeleteModeButton);
            completeDeleteButton.onClick.AddListener(OnCompleteButton);
            
            completeDeleteGroup.FadeGroupOut();
        }
        
        private void OnDeleteModeButton()
        {
            ChatAnimations.MoveChatLeft(messagesContent);
            ChatAnimations.SwapPairOfGroups(inputTextGroup, completeDeleteGroup);
        }
        
        private void OnCompleteButton()
        {
            ChatAnimations.MoveChatToCenter(messagesContent);
            ChatAnimations.SwapPairOfGroups(completeDeleteGroup, inputTextGroup);
        }
    }
}
