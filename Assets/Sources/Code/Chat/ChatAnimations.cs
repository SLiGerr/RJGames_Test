using System;
using Sources.Code.Messages;
using UnityEngine;

namespace Sources.Code.Chat
{
    public static class ChatAnimations
    {
        public static void MessageAppear(IUIMessage message)
        {
            var logoTime = ConfigLoader.GetConfig().messageSpawnAppearLogoTime;
            var messageTime = ConfigLoader.GetConfig().messageSpawnAppearMessageTime;
            
            message.UIRootGameObject.transform.localScale = new Vector3(1, 0);
            message.UIMassageGo.transform.localScale = new Vector3(0, 0);
            
            message.UIRootGameObject.LeanScale(Vector3.one, logoTime).setEaseOutCirc().setOnComplete(() =>
            {
                message.UIMassageGo.LeanScale(Vector3.one, messageTime).setEaseOutCirc();
            });
        }

        public static void MessageDisappear(IUIMessage message, Action endAction)
        {
            var messageTime = ConfigLoader.GetConfig().messageDisposeTime;
            message.UIMassageGo.LeanScale(Vector3.zero, messageTime).setEaseOutCirc().setOnComplete(endAction);
        }

        public static void MoveChatLeft(RectTransform chatContent)
        {
            var config = ConfigLoader.GetConfig();
            var moveTo = config.deleteModeChatX;
            var withTime = config.deleteModeSwitchTime;
            
            chatContent.LeanMoveX(moveTo, withTime).setEaseInOutCirc();
        }

        public static void MoveChatToCenter(RectTransform chatContent)
        {
            var config = ConfigLoader.GetConfig();
            var moveTo = config.regularModeChatX;
            var withTime = config.deleteModeSwitchTime;
            
            chatContent.LeanMoveX(moveTo, withTime).setEaseInOutCirc();
        }

        public static void SwapPairOfGroups(CanvasGroup from, CanvasGroup to)
        {
            from.FadeGroupOut();
            to.FadeGroupIn();
        }
        
        public static void FadeGroupOut(this CanvasGroup group) =>
            group.LeanAlpha(0, FadeTime()).setEaseInOutCirc().setOnStart(() => group.SetInteractivity(false));
        public static void FadeGroupIn(this CanvasGroup group) => 
            group.LeanAlpha(1, FadeTime()).setEaseInOutCirc().setOnStart(() => group.SetInteractivity(true));

        private static float FadeTime() => ConfigLoader.GetConfig().fadeSwitchGroupsTime;
        
        public static void SetInteractivity(this CanvasGroup group, bool to)
        {
            group.blocksRaycasts = to;
            group.interactable = to;
        }
    }
}
