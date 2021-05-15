using UnityEngine;

namespace Sources.Code.Messages
{
    public interface IUIMessage
    {
        Message MessageData { get; set; }
        GameObject UIRootGameObject { get; set; }
        GameObject UIMassageGo { get; set; }
        void Initialize(Message message);
        void SetNameVisibility(bool to);
        void SetImageType(UIMessageImageType to);
    }

    public enum UIMessageImageType
    {
        Root,
        Nested
    }
}