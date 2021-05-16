using UnityEngine;

namespace Sources.Code.Messages
{
    public interface IUIMessageFactory
    {
        IUIMessage InstantiateMessage(Message message, RectTransform root);
    }
}