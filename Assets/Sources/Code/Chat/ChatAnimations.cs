using Sources.Code.Messages;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Code.Chat
{
    public static class ChatAnimations
    {
        
        public static void MessageAppear(IUIMessage massage)
        {
            massage.UIRootGameObject.transform.localScale = new Vector3(1, 0);
            massage.UIMassageGo.transform.localScale = new Vector3(0, 0);
            massage.UIRootGameObject.LeanScale(Vector3.one, 0.1f).setEaseOutCirc().setOnComplete(() =>
            {
                massage.UIMassageGo.LeanScale(Vector3.one, 0.2f).setEaseOutCirc();
            });
            
            MessagesVisualSetup.OnMessageAppeared(massage);
        }

        public static void MoveChatLeft(RectTransform chatContent)
        {
            chatContent.LeanMoveX(-200, .2f).setEaseInOutCirc();
        }

        public static void MoveChatToCenter(RectTransform chatContent)
        {
            chatContent.LeanMoveX(0, 0.2f).setEaseInOutCirc();
        }

        public static void SwapPairOfGroups(CanvasGroup from, CanvasGroup to)
        {
            from.FadeGroupOut();
            to.FadeGroupIn();
        }
        
        public static void FadeGroupOut(this CanvasGroup group) =>
            group.LeanAlpha(0, 0.2f).setEaseInOutCirc().setOnStart(() => group.SetInteractivity(false));
        public static void FadeGroupIn(this CanvasGroup group) => 
            group.LeanAlpha(1, 0.2f).setEaseInOutCirc().setOnStart(() => group.SetInteractivity(true));

        public static void SetInteractivity(this CanvasGroup group, bool to)
        {
            group.blocksRaycasts = to;
            group.interactable = to;
        }
    }
}
