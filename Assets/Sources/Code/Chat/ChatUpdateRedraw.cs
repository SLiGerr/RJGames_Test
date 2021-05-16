using UnityEngine;
using UnityEngine.UI;

namespace Sources.Code.Chat
{
    public class ChatUpdateRedraw : MonoBehaviour
    {
        [SerializeField] private RectTransform rectToRedraw;
        private void Start()
        {
            MessagesAdjuster.OnAdjust += RedrawLayout;
        }
        private void RedrawLayout()
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(rectToRedraw);
        }
    }
}
